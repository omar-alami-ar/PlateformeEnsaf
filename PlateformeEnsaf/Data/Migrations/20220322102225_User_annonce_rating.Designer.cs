﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlateformeEnsaf.Data;

namespace PlateformeEnsaf.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220322102225_User_annonce_rating")]
    partial class User_annonce_rating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Abonnement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Id_Followed_User")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Following_User")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Followed_User");

                    b.HasIndex("Id_Following_User");

                    b.ToTable("Abonnements");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Annonce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Annonce");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Annonce");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Annonce_Domaine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnonceId")
                        .HasColumnType("int");

                    b.Property<int>("DomaineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnonceId");

                    b.HasIndex("DomaineId");

                    b.ToTable("Annonce_Domaines");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Biographie")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CIN")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("FiliereId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsInBlacklist")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Note")
                        .HasColumnType("float");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("FiliereId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.ApplicationUser_Domaine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DomaineId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DomaineId");

                    b.HasIndex("UserId");

                    b.ToTable("user_Domaines");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnnonceId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnnonceId");

                    b.HasIndex("UserId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Domaine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Domaines");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Filiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnnonceId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Contenu")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnnonceId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DateEnvoi")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.User_Annonce_Rating", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AnnonceId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "AnnonceId");

                    b.HasIndex("AnnonceId");

                    b.ToTable("User_Annonce_Rating");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("VotantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VoteeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VotantId");

                    b.HasIndex("VoteeId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Offre", b =>
                {
                    b.HasBaseType("PlateformeEnsaf.Models.Annonce");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<string>("Entreprise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Offre");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Question", b =>
                {
                    b.HasBaseType("PlateformeEnsaf.Models.Annonce");

                    b.HasDiscriminator().HasValue("Question");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Abonnement", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "FollowedUser")
                        .WithMany("Followers")
                        .HasForeignKey("Id_Followed_User");

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "FollowingUser")
                        .WithMany("Follows")
                        .HasForeignKey("Id_Following_User");

                    b.Navigation("FollowedUser");

                    b.Navigation("FollowingUser");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Annonce", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "User")
                        .WithMany("Annonces")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Annonce_Domaine", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Annonce", "Annonce")
                        .WithMany("Annonce_Domaines")
                        .HasForeignKey("AnnonceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlateformeEnsaf.Models.Domaine", "Domaine")
                        .WithMany("Annonce_Domaines")
                        .HasForeignKey("DomaineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annonce");

                    b.Navigation("Domaine");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.ApplicationUser", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Filiere", "Filiere")
                        .WithMany()
                        .HasForeignKey("FiliereId");

                    b.Navigation("Filiere");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.ApplicationUser_Domaine", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Domaine", "Domaine")
                        .WithMany("User_Domaines")
                        .HasForeignKey("DomaineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "User")
                        .WithMany("User_Domaines")
                        .HasForeignKey("UserId");

                    b.Navigation("Domaine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Commentaire", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Annonce", "Annonce")
                        .WithMany("Commentaires")
                        .HasForeignKey("AnnonceId");

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Annonce");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Image", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Annonce", "Annonce")
                        .WithMany("Images")
                        .HasForeignKey("AnnonceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Annonce");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Message", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.User_Annonce_Rating", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.Annonce", "Annonce")
                        .WithMany("Rated_By")
                        .HasForeignKey("AnnonceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "User")
                        .WithMany("Rated_Annonces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annonce");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Vote", b =>
                {
                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "Votant")
                        .WithMany("Votes")
                        .HasForeignKey("VotantId");

                    b.HasOne("PlateformeEnsaf.Models.ApplicationUser", "Votee")
                        .WithMany("Voted")
                        .HasForeignKey("VoteeId");

                    b.Navigation("Votant");

                    b.Navigation("Votee");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Annonce", b =>
                {
                    b.Navigation("Annonce_Domaines");

                    b.Navigation("Commentaires");

                    b.Navigation("Images");

                    b.Navigation("Rated_By");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.ApplicationUser", b =>
                {
                    b.Navigation("Annonces");

                    b.Navigation("Followers");

                    b.Navigation("Follows");

                    b.Navigation("Rated_Annonces");

                    b.Navigation("User_Domaines");

                    b.Navigation("Voted");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("PlateformeEnsaf.Models.Domaine", b =>
                {
                    b.Navigation("Annonce_Domaines");

                    b.Navigation("User_Domaines");
                });
#pragma warning restore 612, 618
        }
    }
}
