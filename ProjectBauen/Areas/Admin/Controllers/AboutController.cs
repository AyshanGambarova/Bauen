using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Phantom.Utils;
using ProjectBauen.DAL;
using ProjectBauen.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly ConnectToDb db;
        private readonly IWebHostEnvironment env;
        public AboutController(ConnectToDb _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public IActionResult Index()
        {
            return View(db.Abouts.FirstOrDefault());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "About");
            }
            About about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return RedirectToAction("Index", "About");
            }
            return View(about);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "About");
            }
            About about = await db.Abouts.FindAsync(id);
            if (about == null)
            {
                return RedirectToAction("Index", "About");
            }
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About about)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (about.ImageFile != null)
            {
                if (!about.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir.");
                    return View(about);
                }

                if (!about.ImageFile.IsValidSize(500))
                {
                    ModelState.AddModelError("ImageFile", "Fayl maksimum 500kb ola biler.");
                    return View(about);
                }

                string filePath = Path.Combine(env.WebRootPath, @"img", about.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                about.Image = await about.ImageFile.Upload(env.WebRootPath, @"img");
            }
            db.Abouts.Update(about);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "About");
        }
     
    }
}
