using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PersonalityTestCard.Models.Setup.UserElementScore
{
	public class UserElementScoreModel
	{
		public int UserElementId { get; set; }

		public int UserId { get; set; }

		public int ElementId { get; set; }

		public int Score { get; set; }

		public string ElementName { get; set; } 

	}
}
