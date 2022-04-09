using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlateformeEnsaf.Data;
using PlateformeEnsaf.Models;

namespace PlateformeEnsaf.Controllers
{
    public class AdminUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

       
        // GET: AdminUs/Delete/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.isBlack = "Remove from Black List";
            ViewBag.isBlackClass = "btn btn-success";
            ViewBag.notBlack = "Add him to the Black List";
            ViewBag.notBlackClass = "btn btn-danger";

            var applicationUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        

        [HttpPost]
        public string Black(string id)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            if (user.IsInBlacklist)
                user.IsInBlacklist = false;
            else
                user.IsInBlacklist = true;

            _context.Users.Update(user);
            _context.SaveChanges();

            return "done";

        }



    }
}
