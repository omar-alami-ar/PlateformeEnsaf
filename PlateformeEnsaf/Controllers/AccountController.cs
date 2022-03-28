﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlateformeEnsaf.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using PlateformeEnsaf.Data;

namespace PlateformeEnsaf.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
           
            this.userManager = userManager;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Historique()
        {
            var user = await GetCurrentUser();
            GenericAnnoces ga = new GenericAnnoces();

            foreach (var offre in await _context.Offres.Where(o=>o.User==user).ToListAsync())
            {
                ga.Offres.Add(offre);
            }
            //var annonces = user.Annonces.Where(a=>a.).ToList();
            return View(ga);
        }

        [HttpGet]
        public async Task<IActionResult> Interets()
        {
            ViewBag.Domaines = _context.Domaines.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveInterets()
        {
            var domaines = Request.Form["foo"];
            var user = await GetCurrentUser();
            foreach (var domaineId in domaines)
            {
                var dom = _context.Domaines.Find(int.Parse(domaineId));
                ApplicationUser_Domaine ad = new ApplicationUser_Domaine()
                {
                    UserId = user.Id,
                    User = user,
                    DomaineId = dom.Id,
                    Domaine = dom,
                };
                _context.user_Domaines.Add(ad);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Profile(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentUser = await GetCurrentUser();
            ViewBag.CurrentUserId = currentUser.Id;
            var user = await userManager.Users.Include(u => u.Annonces).Include(u=> u.Filiere).Include(u => u.Follows).Include(u => u.Followers).FirstOrDefaultAsync(u=> u.Id==id);
            if (user == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            ViewBag.checkFollow = _context.Abonnements.Where(a => a.Id_Following_User == currentUser.Id && a.Id_Followed_User == user.Id).FirstOrDefault();



            var lastvote = _context.Votes.Where(a => a.Votant == currentUser && a.VoteeId == id).FirstOrDefault();
            if(lastvote != null)
            ViewBag.lastVote = lastvote.Value;

            var votes = _context.Votes.Where(a => a.Votee == user).ToList();
            var nbrVotes = votes.Count;
            ViewBag.NbrVotes = nbrVotes;
            
            int test = votes.Sum(x => x.Value);
            ViewBag.NoteSum = test;
            GenericAnnoces ga = new GenericAnnoces();
        

            foreach (var offre in await _context.Offres.Include(u => u.Rated_By).Include(a => a.Images).Include(a => a.Annonce_Domaines).ThenInclude(d => d.Domaine).Include(a => a.User).Where(a => a.User == user).ToListAsync())
            {
                ga.Offres.Add(offre);
            }
            ViewBag.userAnnonces = ga.Offres;
            return View(user);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
        }

        [HttpPost]
        public async Task Follow(string id)
        {
          
            var sourceUser = await GetCurrentUser();
            var targetUser = await userManager.FindByIdAsync(id);
            Abonnement abonnement = new Abonnement();
            abonnement.FollowingUser = sourceUser;
            abonnement.FollowedUser = targetUser;
            _context.Abonnements.Add(abonnement);
            _context.SaveChanges();


        }

        [HttpPost]
        public async Task Unfollow(string id)
        {

            var sourceUser = await GetCurrentUser();
            var targetUser = await userManager.FindByIdAsync(id);
            Abonnement abonnement = _context.Abonnements.Where(a => a.Id_Following_User == sourceUser.Id && a.Id_Followed_User == targetUser.Id).FirstOrDefault();
            _context.Abonnements.Remove(abonnement);
            _context.SaveChanges();


        }

        [HttpPost]
        public async Task<string> FollowUnfollow(string id)
        {

            var sourceUser = await GetCurrentUser();
            var targetUser = await userManager.FindByIdAsync(id);
            Abonnement abonnement = _context.Abonnements.Where(a => a.Id_Following_User == sourceUser.Id && a.Id_Followed_User == targetUser.Id).FirstOrDefault();
            if (abonnement == null)
            {
                Abonnement newAbonnement = new Abonnement();
                newAbonnement.FollowingUser = sourceUser;
                newAbonnement.FollowedUser = targetUser;
                _context.Abonnements.Add(newAbonnement);
                _context.SaveChanges();
                return "followed";

            }
            else
            {
                _context.Abonnements.Remove(abonnement);
                _context.SaveChanges();
                return "unfollowed";
            }



        }

        [HttpPost]
        public async Task<string> Vote(string id, int stars)
        {

            var sourceUser = await GetCurrentUser();
            var targetUser = await userManager.FindByIdAsync(id);
            Vote vote = _context.Votes.Include(x => x.Votee).Include(x=>x.Votant).Where(a => a.Votant == sourceUser && a.Votee == targetUser).FirstOrDefault();

            if(vote != null)
            {
                vote.Value = stars;
                vote.Date = DateTime.Now;

                _context.SaveChanges();

                return "update";


            }
            else
            {
                Vote newVote = new Vote()
                {
                    Votant = sourceUser,
                    VotantId = sourceUser.Id,
                    Votee = targetUser,
                    VoteeId = targetUser.Id,
                    Value = stars ,
                    Date = DateTime.Now
                };

                _context.Votes.Add(newVote);
                _context.SaveChanges();

                return "add";
            }
            

        }



    }
}
