using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PersonalityTestCard.Models.Setup.UserCard
{
	public class UserCardRequestModel
	{
		
		public int UserId { get; set; }
		public List<int> CardIds { get; set; }

	}
}
