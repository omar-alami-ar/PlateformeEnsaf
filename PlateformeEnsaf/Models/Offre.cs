using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    
    public class Offre : Annonce
    {

        [Required]
        public CategorieOffre Categorie { get; set; } 

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Entreprise { get; set; }
    }
}
