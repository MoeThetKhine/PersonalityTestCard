using DotNet8.PersonalityTestCard.Models.Setup.Card;

namespace DotNet8.PersonalityTestCard.Api.Repositories.Card
{
	public interface ICardRepository
	{
		Task<CardListResponseModel> GetCardsAsync();
	}
}
