using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBauen.DAL;
using ProjectBauen.Models;
using System;
using Phantom.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ProjectBauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {
        private readonly ConnectToDb db;
        private readonly IWebHostEnvironment env;
        public BannerController(ConnectToDb _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Banners.ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Banner");
            }
            Banner banner = await db.Banners.FindAsync(id);
            if (banner == null)
            {
                return RedirectToAction("Index", "Banner");
            }
            return View(banner);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!banner.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir.");
                return View(banner);
            }

            if (!banner.ImageFile.IsValidSize(500))
            {
                ModelState.AddModelError("ImageFile", "Fayl maksimum 500kb ola biler.");
                return View(banner);
            }

            banner.Image = await banner.ImageFile.Upload(env.WebRootPath, @"img\slider");

            await db.Banners.AddAsync(banner);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Banner");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Banner");
            }
            Banner banner = await db.Banners.FindAsync(id);
            if (banner == null)
            {
                return RedirectToAction("Index", "Banner");
            }
            return View(banner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (banner.ImageFile != null)
            {
                if (!banner.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir.");
                    return View(banner);
                }

                if (!banner.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("ImageFile", "Fayl maksimum 500kb ola biler.");
                    return View(banner);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img\slider", banner.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

            }
            banner.Image = await banner.ImageFile.Upload(env.WebRootPath, @"img\slider");
            db.Banners.Update(banner);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Banner");
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await db.Banners.FindAsync(id));
        }
        public async Task<IActionResult> Permanentlydelete(int id)
        {
            Banner bannerToDelete = await db.Banners.FindAsync(id);
            string filePath = Path.Combine(env.WebRootPath, @"img\slider", bannerToDelete.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            db.Banners.Remove(bannerToDelete);
            await db.SaveChangesAsync();
            return RedirectToAction("index", "Blog");

        }
    }
}

