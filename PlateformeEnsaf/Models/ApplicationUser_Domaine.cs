using System;
using System.ComponentModel.DataAnnotations;

namespace PlateformeEnsaf.Models
{
	public class ApplicationUser_Domaine
	{
		[Key]
		public int Id { get; set; }

		public String UserId { get; set; }

		public ApplicationUser User { get; set; }

		public int DomaineId { get; set; }

		public Domaine Domaine { get; set; }
	}
}

