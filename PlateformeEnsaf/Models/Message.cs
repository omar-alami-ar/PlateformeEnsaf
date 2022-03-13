using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        [Required, MaxLength(500)]
        [Display(Name ="Contenu")]
        public string Content { get; set; }

        public DateTime DateEnvoi { get; set; } = DateTime.Now;

        public bool IsSeen { get; set; } = false;
    }
}
