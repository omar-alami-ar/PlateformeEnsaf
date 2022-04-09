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
            var receiver = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            ViewBag.user = receiver;
            var sender = await GetCurrentUser();
            
            ViewBag.senderId = sender.Id;
            var currentUser = await userManager.Users.Include(u => u.Follows).ThenInclude(x => x.FollowedUser).Include(u => u.Followers).FirstOrDefaultAsync(u => u.Id == sender.Id);
            ViewBag.senderName = sender.FirstName + " "+ sender.LastName;
            ViewBag.contacts = currentUser.Follows;

            var messages = _context.Messages.Where(r => (r.Sender == sender && r.Receiver == receiver) || (r.Sender == receiver && r.Receiver == sender)).Include(u=>u.Sender).Include(u => u.Receiver).OrderBy(u=>u.DateEnvoi).ToList();
            ViewBag.messages = messages;
            return View();
        }

        public async Task<IActionResult> Start()
        {
           
            var sender = await GetCurrentUser();

            ViewBag.senderId = sender.Id;
            var currentUser = await userManager.Users.Include(u => u.Follows).ThenInclude(x => x.FollowedUser).Include(u => u.Followers).FirstOrDefaultAsync(u => u.Id == sender.Id);
           
            ViewBag.contacts = currentUser.Follows;

           
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> StoreMessage(string content,string senderId, string receiverId)
        {
            Message message = new Message();
            message.Content = content;
            message.Sender = await _context.Users.FindAsync(senderId);
            message.Receiver = await _context.Users.FindAsync(receiverId);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return null;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }
    }
}
