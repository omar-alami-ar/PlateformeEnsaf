using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public enum CategorieOffre
    {
        [Display(Name = "Offre d'emploi")]
        Emploi,
        [Display(Name = "Offre de stage")]
        Stage
    }
}
