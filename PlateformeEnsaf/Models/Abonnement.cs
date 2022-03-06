using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class Abonnement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("Users")]
        public string Id_Following_User { get; set; }
        public virtual ApplicationUser FollowingUser { get; set; }

        
        [ForeignKey("Users")]
        public string Id_Followed_User { get; set; }
        public virtual ApplicationUser FollowedUser { get; set; }
    }
}
