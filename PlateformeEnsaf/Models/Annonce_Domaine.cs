using System;
using System.ComponentModel.DataAnnotations;

namespace PlateformeEnsaf.Models
{
	public class Annonce_Domaine
	{
		[Key]
		public int Id { get; set; }

		public int AnnonceId { get; set; }

		public Annonce Annonce { get; set; }

		public int DomaineId { get; set; }

		public Domaine Domaine { get; set; }

	}
}

