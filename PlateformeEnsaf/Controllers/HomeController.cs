using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

            

            ViewBag.User = currentUser;
            //var follows = _context.Users.Include(x => x.Followers).ThenInclude(x => x.FollowedUser).Include(x => x.Followers).ThenInclude(x => x.FollowingUser).Where(x => !x.Followers.Select(t=>t.FollowedUser).Contains(currentUser)).ToList();
            //var fl = follows;
            //var currentUserId = await User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            //ViewBag.People =  userManager.Users.Where(a => a.Id != currentUser.Id ).OrderBy(a => a.Note).Take(3);

            ViewBag.People = _context.Users.Include(x => x.Followers).ThenInclude(x => x.FollowedUser).Include(x => x.Followers).ThenInclude(x => x.FollowingUser).Where(x => !x.Followers.Select(t => t.FollowingUser).Contains(currentUser) && x != currentUser).OrderByDescending(x=>x.Note).Take(3);


            GenericAnnoces ga = new GenericAnnoces();
            var user = await GetCurrentUser();

            foreach (var offre in await _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).ThenInclude(r=>r.User).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d=>d.Domaine).Include(a => a.User).Where(a => a.User != currentUser).ToListAsync())
            {
                ga.Offres.Add(offre);
            }

            ViewBag.annonces = ga.Offres;
            var annonces = ga.Offres;
            ViewData["domaines"] = new SelectList(_context.Domaines, "Id", "Nom");
            var villes = _context.Offres.Select(p => p.Ville).Distinct().ToList();
            ViewData["villes"] = villes;
            return View(annonces);
        }

        public async Task<PartialViewResult> Listing(int SelectedDomaine, string selectedCity, string selectedFilter)
        {
            var currentUser = await GetCurrentUser();
            ViewBag.User = currentUser;
            GenericAnnoces ga = new GenericAnnoces();
            
            if (SelectedDomaine == 0 && selectedCity == "0")
            {
                ga.Offres.Clear();
                foreach (var offre in  _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser)) 
                {
                    ga.Offres.Add(offre);
                }
               // var res = _context.Offres.Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser);
                if (selectedFilter == "rating-desc")
                    return PartialView( ga.Offres.OrderByDescending(a => a.Note));
                else if (selectedFilter == "date-asc")
                    return PartialView( ga.Offres.OrderBy(a => a.DatePublication));
                else if (selectedFilter == "date-desc")
                    return PartialView( ga.Offres.OrderByDescending(a => a.DatePublication));
                return PartialView( ga.Offres);
            }
            else if (SelectedDomaine == 0 && selectedCity != "0")
            {
                ga.Offres.Clear();
                foreach (var offre in _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Where(a => a.Ville == selectedCity).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser))
                {
                    ga.Offres.Add(offre);
                }
               // var res = _context.Offres.Where(a=>a.Ville=="selectedCity").Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser);
                if (selectedFilter == "rating-desc")
                    return PartialView( ga.Offres.OrderByDescending(a => a.Note));
                else if (selectedFilter == "date-asc")
                    return PartialView(ga.Offres.OrderBy(a => a.DatePublication));
                else if (selectedFilter == "date-desc")
                    return PartialView(ga.Offres.OrderByDescending(a => a.DatePublication));
                return PartialView( ga.Offres);
            }
            else if (SelectedDomaine != 0 && selectedCity == "0")
            {
                ga.Offres.Clear();
                // Annonce_Domaine d = new Annonce_Domaine();
                List<Offre> offres = null;
                //if (SelectedDomaine == 999)
                //{
                //    var interets = currentUser.User_Domaines.Select(a => a.Domaine).ToList();
                //    var res = _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser).ToList();
                //    foreach (var o in res)
                //    {
                //        foreach (var d in interets)
                //        {
                //            if (o.Annonce_Domaines.Select(a => a.Domaine).ToList().Contains(d))
                //            {
                //                offres.Add(o);
                //            }
                //        }

                //    }
                //}
                
                    offres = _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Where(a => a.Annonce_Domaines.Any(d => d.DomaineId == SelectedDomaine)).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser).ToList();
                
                foreach (var offre in _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Where(a => a.Annonce_Domaines.Any(d=>d.DomaineId==SelectedDomaine)).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser))
                {
                    ga.Offres.Add(offre);
                }
               // var res = _context.Offres.Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser);
                if (selectedFilter == "rating-desc")
                    return PartialView(ga.Offres.OrderByDescending(a => a.Note));
                else if (selectedFilter == "date-asc")
                    return PartialView(ga.Offres.OrderBy(a => a.DatePublication));
                else if (selectedFilter == "date-desc")
                    return PartialView(ga.Offres.OrderByDescending(a => a.DatePublication));
                return PartialView(ga.Offres);
            }
            else
            {
                ga.Offres.Clear();
                foreach (var offre in _context.Offres.Include(a => a.EnregistrePar).Include(a => a.Rated_By).Where(a => a.Annonce_Domaines.Any(d => d.DomaineId == SelectedDomaine)).Where(a => a.Ville == selectedCity).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User != currentUser))
                {
                    ga.Offres.Add(offre);
                }
                if (selectedFilter == "rating-desc")
                    return PartialView(ga.Offres.OrderByDescending(a => a.Note));
                else if (selectedFilter == "date-asc")
                    return PartialView(ga.Offres.OrderBy(a => a.DatePublication));
                else if (selectedFilter == "date-desc")
                    return PartialView(ga.Offres.OrderByDescending(a => a.DatePublication));
                return PartialView(ga.Offres);
            }

        }

        [Authorize]
        public async Task<string> Save(int id)
        {
            var currentUser = await GetCurrentUser();
            var annonce = _context.Annonce.Find(id);
            var existingSave = _context.Enregistrements.Find(currentUser.Id, annonce.Id);
            if (existingSave != null)
            {
                _context.Enregistrements.Remove(existingSave);
                await _context.SaveChangesAsync();
                return null;
            }
                //ViewBag.ExistingSave = false;
                Enregistrement e = new Enregistrement()
            {
                User = currentUser,
                Annonce = annonce,
            };
            _context.Enregistrements.Add(e);

            await _context.SaveChangesAsync();
            
    
            return null;

        }

        [HttpPost]
        public async Task<string> Annonce( string title, string message)
        {

           
            if (title != null && message != null)
            {
                var sourceUser = await GetCurrentUser();

                Question question = new Question();

                question.Titre = title;
                question.Description = message;
                question.User = sourceUser;

                _context.Annonce.Add(question);
                _context.SaveChanges();

                return "added";


            }
            else
                return "refused";
            


        }

        public IActionResult Report()
        {
            var test = _context.Users;
            ViewBag.tests = test;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult IndexAdmin()
        {
            ViewBag.one = _context.Users.Where(a => a.Niveau == "1ère Année").Count();
            ViewBag.two = _context.Users.Where(a => a.Niveau == "2éme Année").Count();
            ViewBag.three = _context.Users.Where(a => a.Niveau == "3éme Année").Count();
            ViewBag.L = _context.Users.Where(a => a.Niveau == "Laureat").Count();
            ViewBag.domaines = _context.Domaines.Select(d=>d.Nom).ToList();
            var domaines = _context.Domaines.ToList();
            List<int> nbrParDomaine = new List<int>();
;            foreach(var domaine in domaines)
            {
                var nbr = _context.Offres.Where(a=>a.Annonce_Domaines.Select(d=>d.Domaine).Contains(domaine)).Count();
                
                nbrParDomaine.Add(nbr);
            }
            ViewBag.nbrParDomaine = nbrParDomaine;
            ViewBag.nbrStage = _context.Offres.Where(a => a.Categorie == CategorieOffre.Stage).Count(); 
            ViewBag.nbrEmploi = _context.Offres.Where(a => a.Categorie == CategorieOffre.Emploi).Count();
            ViewBag.Utilisateurs = _context.Users.Count();
            ViewBag.AnnoncesEnLigne = _context.Annonce.Where(a=>a.Statut=="Approuvé").Count();
            ViewBag.AnnoncesEnAttente = _context.Annonce.Where(a => a.Statut == "En Attente").Count();
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
