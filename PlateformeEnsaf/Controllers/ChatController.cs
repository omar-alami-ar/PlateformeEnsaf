using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlateformeEnsaf.Data;
using PlateformeEnsaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public ChatController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {

            this.userManager = userManager;
            this._context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.number = ApplicationUser.Ids;
            ViewBag.user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            var sender = await GetCurrentUser();
            ViewBag.senderId = sender.Id;
            var currentUser = await userManager.Users.Include(u => u.Follows).Include(u => u.Followers).FirstOrDefaultAsync(u => u.Id == sender.Id);
            ViewBag.senderName = sender.FirstName + " "+ sender.LastName;
            ViewBag.contacts = currentUser.Follows;
            return View();
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }
    }
}
