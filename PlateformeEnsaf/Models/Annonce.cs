using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlateformeEnsaf.Models
{
    public class  Annonce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Titre { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }


        public virtual ApplicationUser User { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; } = DateTime.Now;

        public int Note { get; set; } = 0;

        public string Statut { get; set; } = "En attente";

        public virtual List<Annonce_Domaine> Annonce_Domaines { get; set; } = new List<Annonce_Domaine>();

        [NotMapped]
        public virtual IFormFileCollection ImageFiles { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<User_Annonce_Rating> Rated_By { get; set; }

        public virtual List<Commentaire> Commentaires { get; set; }


    }
}
