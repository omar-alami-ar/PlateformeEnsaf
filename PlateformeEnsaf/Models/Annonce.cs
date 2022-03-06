using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public abstract class  Annonce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Titre { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        
        public virtual  ApplicationUser User { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; } = DateTime.Now;

        public int Note { get; set; }

        public string Statut { get; set; }

        public virtual List<Domaine> Domaines { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual List<Commentaire> Commentaires { get; set; }


    }
}
