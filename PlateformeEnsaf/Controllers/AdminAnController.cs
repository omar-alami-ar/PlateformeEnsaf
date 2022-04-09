using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PlateformeEnsaf.Data;

using PlateformeEnsaf.Models;

namespace PlateformeEnsaf.Controllers
{
    public class AdminAnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminAnController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: AdminAn
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Annonce.Include(x=>x.User).Where(x=>x.Statut == "En attente").ToListAsync());
        }

        public async Task<IActionResult> AnOnline()
        {
            return View(await _context.Annonce.Include(x => x.User).Where(x => x.Statut == "Approuvé").ToListAsync());
        }



        // GET: AdminAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Annonce.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id ==id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }



        // POST: AdminAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {

            Annonce annonce = _context.Annonce.Where(x => x.Id == id).FirstOrDefault();
            annonce.Statut = "Approuvé";
            _context.Annonce.Update(annonce);
            _context.SaveChanges();


            
            

            return RedirectToAction(nameof(Index));
        }

        // GET: AdminAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Annonce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }

            return View(annonce);
        }

        // POST: AdminAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annonce = await _context.Annonce.FindAsync(id);
            _context.Annonce.Remove(annonce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnonceExists(int id)
        {
            return _context.Annonce.Any(e => e.Id == id);
        }
    }
}
