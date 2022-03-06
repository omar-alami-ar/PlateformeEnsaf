using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlateformeEnsaf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PlateformeEnsaf.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
           
            this.userManager = userManager;
        }
        public async Task<IActionResult> Profile(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentUser = await GetCurrentUser();
            ViewBag.CurrentUserId = currentUser.Id;
            var user = await userManager.Users.Include(u=> u.Filiere).FirstOrDefaultAsync(u=> u.Id==id);
            if (user == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(user);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }

        
    }
}
