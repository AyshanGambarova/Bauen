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
    public class ProjectController : Controller
    {
        private readonly ConnectToDb db;
        public ProjectController(ConnectToDb _db)
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
            Project project = db.Projects.Include(x => x.ProjectImages).FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(project);
        }

    }
}
