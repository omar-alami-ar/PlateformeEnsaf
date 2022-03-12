using System;
using System.Collections.Generic;

namespace PlateformeEnsaf.Models
{
	public class GenericAnnoces
	{
		public List<Offre> Offres { get; set; } = new List<Offre>();
		public List<Question> Questions { get; set; } = new List<Question>();
	}
}

