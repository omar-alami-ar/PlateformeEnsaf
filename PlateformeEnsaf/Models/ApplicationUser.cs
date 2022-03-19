using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required,MaxLength(100)]
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }

        [MaxLength(10)]
        public string CIN { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Adresse { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Biographie { get; set; }

        //[ForeignKey("Filieres")]
        //[Required]
        //[Display(Name ="Filiere")]
        //public int Id_Filiere { get; set; }

        //[NotMapped]
        public virtual Filiere Filiere { get; set; }

        [Required]
        [Display(Name = "Niveau")]
        public string Niveau { get; set; }

        public bool IsInBlacklist { get; set; }

        public double Note { get; set; }

        //public int NbrVotes { get; set; }

        public  virtual ICollection<Abonnement> Followers { get; set; }
        public  virtual ICollection<Abonnement> Follows { get; set; }

        public virtual List<Annonce> Annonces { get; set; }

        public virtual List<ApplicationUser_Domaine> User_Domaines { get; set; }

        //public virtual List<Commentaire> Commentaires { get; set; }
        public List<Vote> Votes { get; set; }
        public List<Vote> Voted { get; set; }

        [NotMapped]
        public static List<string> Ids = new List<string>();

    }

}
