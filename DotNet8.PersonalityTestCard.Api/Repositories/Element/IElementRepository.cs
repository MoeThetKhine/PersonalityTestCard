namespace DotNet8.PersonalityTestCard.Api.Repositories.Element;

public interface IElementRepository
{
	Task<ElementListResponseModel> GetCardsAsync();
}
