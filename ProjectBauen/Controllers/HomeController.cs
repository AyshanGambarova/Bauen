using Microsoft.AspNetCore.Mvc;
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
    public class HomeController : Controller
    {
        private readonly ConnectToDb db;
        public HomeController(ConnectToDb _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                Banners = db.Banners.ToList(),
                About = db.Abouts.FirstOrDefault(),
                Projects = db.Projects.ToList(),
                Services = db.Services.Take(3).ToList(),
                News = db.News.ToList(),
                Contact = db.Contacts.FirstOrDefault(),
                Testimonials = db.Testimonials.ToList(),
                Clients = db.Clients.ToList(),
            };
            return View(hvm);
        }
        public async Task<IActionResult> AddMessage(Message message)
        {
            await db.Messages.AddAsync(message);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
