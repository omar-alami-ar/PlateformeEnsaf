using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class Commentaire
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        
        public virtual ApplicationUser User { get; set; }

       
        public virtual Annonce Annonce { get; set; }

        [Required,MaxLength(500)]
        public string Contenu { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; } = DateTime.Now;
    }
}
