using DotNet8.PersonalityTestCard.DbService.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PersonalityTestCard.Models.Setup.Card
{
	public class CardListModel
	{
		public int CardId { get; set; }

		public string CardName { get; set; } = null!;

		public int ElementId { get; set; }


	}
}
