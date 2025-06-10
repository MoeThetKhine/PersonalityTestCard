using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PersonalityTestCard.Models.Setup.UserElementScore
{
	public class UserElementScoreResponseModel
	{
		public int UserId { get; set; }
		public string Username {  get; set; }
		public string ElementName { get; set; }
		public int Score { get; set; }
	}
}
