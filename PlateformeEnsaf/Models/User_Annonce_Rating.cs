using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class User_Annonce_Rating
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int AnnonceId { get; set; }
        public Annonce Annonce { get; set; }

        public string Type { get; set; } //Upvote or downvote
    }
}
