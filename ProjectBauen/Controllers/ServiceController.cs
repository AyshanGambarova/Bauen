using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectBauen.DAL;
using ProjectBauen.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ConnectToDb db;
        public ServiceController(ConnectToDb _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Service service = db.Services.Include(x => x.ServicesImages).FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(service);
        }
    }
}
