using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MimeKit;
using PlateformeEnsaf.Data;
using PlateformeEnsaf.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            this.userManager = userManager;
            _context = context;
        }

        [Authorize]
        public async  Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUser();
            //var currentUserId = await User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            ViewBag.People =  userManager.Users.Where(a => a.Id != currentUser.Id ).Take(3);
            return View();
        }


        public IActionResult Report()
        {
            var test = _context.Users;
            ViewBag.tests = test;
            return View();
        }

        [HttpPost]
        public IActionResult Report(String id)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ensaf Plateforme", "plateformensaf492@gmail.com"));
            message.To.Add(new MailboxAddress("", _context.Users.Find(id).Email));
            message.Subject = "this is a report";

            message.Body = new TextPart("plain")
            {
                Text = Request.Form["body"]
            };
            //{
            //    Text ="hello we are so happy to see you in this invitation class you will be so close to zaghoura or maybe akora legend so dont talk about it",

                //};

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.CheckCertificateRevocation = false;
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("plateformensaf492@gmail.com", "plateformensaf492!!");
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }

        public IActionResult PageNotFound()
        {
            return View();
        }


    }
}
