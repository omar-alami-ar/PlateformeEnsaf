using System;
using System.ComponentModel.DataAnnotations;

namespace PlateformeEnsaf.Models
{
	public class Vote
	{
		[Key]
		public int Id { get; set; }

		public string VotantId { get; set; }

		public ApplicationUser Votant { get; set; }

		public string VoteeId { get; set; }

		public ApplicationUser Votee { get; set; }

		public int Value { get; set; }

		public DateTime Date { get; set; }

	}
}
	


