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

        [Required]
        [ForeignKey("Filiere")]
        [Display(Name = "Filiere")]
        public int Id_Filiere { get; set; }
        
        public virtual Filiere Filiere { get; set; }

        [Required]
        [Display(Name = "Niveau")]
        public string Niveau { get; set; }

        public bool IsInBlacklist { get; set; }

        public double Note { get; set; }

        public int NbrVotes { get; set; }

        public virtual List<ApplicationUser> Abonnés { get; set; }

        public virtual List<ApplicationUser> Abonnements { get; set; }
    }

}
