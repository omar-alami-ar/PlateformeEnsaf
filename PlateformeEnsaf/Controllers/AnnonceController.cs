using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlateformeEnsaf.Data;
using PlateformeEnsaf.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;
using Image = PlateformeEnsaf.Models.Image;
using Microsoft.AspNetCore.Authorization;

namespace PlateformeEnsaf.Controllers
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class AnnonceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        public AnnonceController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            this.userManager = userManager;
            _context = context;
        }

        // GET: Annonce
        public async Task<IActionResult> Index()
        {
            GenericAnnoces ga = new GenericAnnoces();

            foreach (var offre in await _context.Offres.ToListAsync())
            {
                ga.Offres.Add(offre);
            }
            foreach (var question in await _context.Questions.ToListAsync())
            {
                ga.Questions.Add(question);
            }

            return View(ga);
        }

        // GET: Annonce/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.Include(x=>x.Annonce_Domaines).ThenInclude(x=>x.Domaine).FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        public async Task<IActionResult> DetailsOff(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.currentUser =await GetCurrentUser();
            var offre = await _context.Offres.Include(x => x.EnregistrePar).ThenInclude(x => x.User).Include(x => x.User).Include(x => x.Commentaires).ThenInclude(x => x.User).Include(x => x.Images).Include(x => x.Annonce_Domaines).ThenInclude(x => x.Domaine).FirstOrDefaultAsync(m => m.Id == id);
            if (offre == null)
            {
                return NotFound();
            }

            return View(offre);
        }


        // GET: Annonce/Create
        public IActionResult CreateOff(string type)
        {
            ViewBag.domaines = _context.Domaines.ToList();
            return View();
        }

        // POST: Annonce/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOff(Offre offre)
        {

            if (ModelState.IsValid)
            {
                
                ApplicationUser tst = await GetCurrentUser();
                offre.User = tst;
                var test = Request.Form["doms"];
                foreach (var domaineId in test)
                {
                    var dom = _context.Domaines.Find(int.Parse(domaineId));
                    Annonce_Domaine ad = new Annonce_Domaine()
                    {
                        AnnonceId = offre.Id,
                        Annonce = offre,
                        DomaineId = dom.Id,
                        Domaine = dom,
                    };
                    offre.Annonce_Domaines.Add(ad);
                }

                //TODO: Upload Image here
                if (offre.ImageFiles != null)
                {
                    offre.Images = new List<Image>();
                    foreach (var file in offre.ImageFiles)
                    {

                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            Image image = new Image()
                            {
                                Contenu = dataStream.ToArray()
                            };
                            offre.Images.Add(image);
                        }

                    }

                }
               
                _context.Add(offre);
                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }


        // GET: Annonce/Create
        public IActionResult Create(string type)
        {
            ViewBag.domaines = _context.Domaines.ToList();
            return View();
        }

        // POST: Annonce/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question annonce)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser tst = await GetCurrentUser();
                annonce.User = tst;
                var test = Request.Form["doms"];
                foreach (var domaineId in test)
                {
                    var dom = _context.Domaines.Find(int.Parse(domaineId));
                    Annonce_Domaine ad = new Annonce_Domaine()
                    {
                        AnnonceId = annonce.Id,
                        Annonce = annonce,
                        DomaineId = dom.Id,
                        Domaine = dom,
                    };
                    annonce.Annonce_Domaines.Add(ad);
                }


                //TODO: Upload Image here

                //long size = photos.Sum(f => f.Length);

                //foreach (var photo in photos)
                //{


                //    if (file.Length > 0)
                //    {
                //        var filePath = Path.GetTempFileName();

                //        using (var stream = System.IO.File.Create(filePath))
                //        {
                //            await file.CopyToAsync(stream);
                //        }
                //    }
                //}


                _context.Add(annonce);
                await _context.SaveChangesAsync();





                return RedirectToAction(nameof(Index));
            }
            return View(annonce);
        }

        // GET: Annonce/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.domaines = _context.Domaines.ToList();
            var annonce = await _context.Questions.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }

        // POST: Annonce/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,DatePublication,Note,Statut")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    foreach (var ad in _context.Annonce_Domaines.Where(x=>x.AnnonceId==question.Id))
                        _context.Annonce_Domaines.Remove(ad);

                    question.Annonce_Domaines.Clear();

                    var test = Request.Form["doms"];
                    foreach (var domaineId in test)
                    {
                        var dom = _context.Domaines.Find(int.Parse(domaineId));
                        Annonce_Domaine ad = new Annonce_Domaine()
                        {
                            AnnonceId = question.Id,
                            Annonce = question,
                            DomaineId = dom.Id,
                            Domaine = dom,
                        };
                        question.Annonce_Domaines.Add(ad);
                    }

                    

                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnonceExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }



        public async Task<IActionResult> EditOff(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.domaines = _context.Domaines.ToList();
            var annonce = await _context.Offres.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }

        // POST: Annonce/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOff(int id, Offre offre)
        {
            if (id != offre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var ad in offre.Annonce_Domaines.ToList())
                        _context.Annonce_Domaines.Remove(ad);
                    offre.Annonce_Domaines.Clear();

                    var test = Request.Form["doms"];
                    foreach (var domaineId in test)
                    {
                        var dom = _context.Domaines.Find(int.Parse(domaineId));
                        Annonce_Domaine ad = new Annonce_Domaine()
                        {
                            AnnonceId = offre.Id,
                            Annonce = offre,
                            DomaineId = dom.Id,
                            Domaine = dom,
                        };
                        offre.Annonce_Domaines.Add(ad);
                    }
                    
                    _context.Update(offre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnonceExists(offre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(offre);
        }

        // GET: Annonce/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Questions.Include(x => x.Annonce_Domaines).ThenInclude(x => x.Domaine).FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }

            return View(annonce);
        }

        // POST: Annonce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annonce = await _context.Annonce.FindAsync(id);
            _context.Annonce.Remove(annonce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteOff(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Offres.Include(x => x.Annonce_Domaines).ThenInclude(x => x.Domaine).FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }

            return View(annonce);
        }

        // POST: Annonce/Delete/5
        [HttpPost, ActionName("DeleteOff")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOffConfirmed(int id)
        {
            var annonce = await _context.Annonce.FindAsync(id);
            _context.Annonce.Remove(annonce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<string> Commenter(int id,string content)
        {
            var currentUser = await GetCurrentUser();
            var annonce = _context.Annonce.Find(id);

            Commentaire comment = new Commentaire();
            comment.Contenu = content;
            comment.DatePublication = DateTime.Now;
            comment.User = currentUser;
            comment.Annonce = annonce;

            _context.Commentaires.Add(comment);
            await _context.SaveChangesAsync();

            return "commented";

        }

        [Authorize]
        public async Task<string> Upvote(int id)
        {
            var currentUser = await GetCurrentUser();
            var annonce = _context.Annonce.Find(id);
            var existingRating = _context.User_Annonce_Rating.Find(currentUser.Id, annonce.Id);
            if (existingRating != null)
            {
                if (existingRating.Type == "upvote")
                {
                    _context.User_Annonce_Rating.Remove(existingRating);
                    annonce.Note -= 1;
                    await _context.SaveChangesAsync();
                    return "cancelledUpvote";
                }
                _context.User_Annonce_Rating.Remove(existingRating);
                annonce.Note += 1;
            }
            _context.Annonce.Attach(annonce);
            _context.Attach(annonce);
            annonce.Note += 1;
            
            _context.Entry(annonce).Property(a => a.Note).IsModified = true;
            
            User_Annonce_Rating rating = new User_Annonce_Rating()
            {
                User = currentUser,
                Annonce = annonce,
                Type = "upvote"
            };
            _context.User_Annonce_Rating.Add(rating);

            await _context.SaveChangesAsync();
           
            return "upvoted";
            
        }

        [Authorize]
        public async Task<string> Downvote(int id)
        {
            var currentUser = await GetCurrentUser();
            var annonce = _context.Annonce.Find(id);
            var existingRating = _context.User_Annonce_Rating.Find(currentUser.Id, annonce.Id);
            if (existingRating != null)
            {
                if (existingRating.Type == "downvote")
                {
                    _context.User_Annonce_Rating.Remove(existingRating);
                    annonce.Note += 1;
                    await _context.SaveChangesAsync();
                    return "cancelledDownvote";
                }
                _context.User_Annonce_Rating.Remove(existingRating);
                annonce.Note -= 1;
            }
            _context.Annonce.Attach(annonce);
            _context.Attach(annonce);
            annonce.Note -= 1;

            User_Annonce_Rating rating = new User_Annonce_Rating()
            {
                User = currentUser,
                Annonce = annonce,
                Type = "downvote"
            };
            _context.Entry(annonce).Property(a => a.Note).IsModified = true;
            _context.User_Annonce_Rating.Add(rating);
            await _context.SaveChangesAsync();

            return "downvoted";

        }

        private bool AnnonceExists(int id)
        {
            return _context.Annonce.Any(e => e.Id == id);
        }




        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }

    }
}
