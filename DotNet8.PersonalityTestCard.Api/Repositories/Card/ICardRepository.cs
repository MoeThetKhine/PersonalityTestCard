namespace DotNet8.PersonalityTestCard.Api.Repositories.Card;

#region ICardRepository

public interface ICardRepository
{
	Task<CardListResponseModel> GetCardsAsync();
}

#endregion