namespace DotNet8.PersonalityTestCard.Api.Repositories.Card;

public interface ICardRepository
{
	Task<CardListResponseModel> GetCardsAsync();
}
