using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectBauen.DAL;
using ProjectBauen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBauen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ConnectToDb db;
        public UserController(ConnectToDb _db)
        {
            db = _db;
        }
        public UserController(UserManager<AppUser> _userManager, ConnectToDb _db)
        {
            userManager = _userManager;
            db = _db;

        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = userManager.Users.ToList();
            List<UserDTO> dTOs = new List<UserDTO>();
            foreach (AppUser item in users)
            {
                UserDTO dTO = new UserDTO
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    UserName = item.UserName,
                    IsActive = item.IsActive,
                    Email = item.Email,
                    Role = (await userManager.GetRolesAsync(item))[0]

                };
                dTOs.Add(dTO);
            }


            return View(dTOs);
        }
        public async Task<IActionResult> ChangeStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "User");
            }
            AppUser user = await userManager.FindByIdAsync(id);
            return View(user);

        }
        public async Task<IActionResult> ChangeStatusConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "User");
            }
            AppUser user = await userManager.FindByIdAsync(id);
            if (user.IsActive)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
          await  db.SaveChangesAsync();
            return RedirectToAction("Index", "User");

        }
    }
}