using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBauen.Areas.Admin.Models;
using ProjectBauen.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ConnectToDb db;
        public DashboardController(ConnectToDb _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.BannerCount = await db.Banners.CountAsync();
            dvm.ProjectCount = await db.Projects.CountAsync();
            return View(dvm);
        }
    }
}
