using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlateformeEnsaf.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlateformeEnsaf.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ApplicationUser_Domaine> user_Domaines { get; set; }
        public DbSet<Annonce_Domaine> Annonce_Domaines { get; set; }

        public DbSet<Abonnement> Abonnements { get; set; }

        public DbSet<Domaine> Domaines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Annonce>()
            .HasMany(l => l.Images)
            .WithOne(a=> a.Annonce)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Annonce_Domaine>()
            .HasOne(l => l.Annonce)
            .WithMany(a => a.Annonce_Domaines)
            .HasForeignKey(l => l.AnnonceId);

            builder.Entity<Annonce_Domaine>()
                   .HasOne(l => l.Domaine)
                   .WithMany(a => a.Annonce_Domaines)
                   .HasForeignKey(l => l.DomaineId);

            builder.Entity<ApplicationUser_Domaine>()
            .HasOne(l => l.User)
            .WithMany(a => a.User_Domaines)
            .HasForeignKey(l => l.UserId);

            builder.Entity<ApplicationUser_Domaine>()
                   .HasOne(l => l.Domaine)
                   .WithMany(a => a.User_Domaines)
                   .HasForeignKey(l => l.DomaineId);

            builder.Entity<Abonnement>()
            .HasOne(l => l.FollowingUser)
            .WithMany(a => a.Follows)
            .HasForeignKey(l => l.Id_Following_User);

            builder.Entity<Abonnement>()
                   .HasOne(l => l.FollowedUser)
                   .WithMany(a => a.Followers)
                   .HasForeignKey(l => l.Id_Followed_User);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

          
        }

        public DbSet<PlateformeEnsaf.Models.Annonce> Annonce { get; set; }
    }
}
