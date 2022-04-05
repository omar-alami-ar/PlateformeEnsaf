using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class Enregistrement
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int AnnonceId { get; set; }
        public Annonce Annonce { get; set; }
    }
}
