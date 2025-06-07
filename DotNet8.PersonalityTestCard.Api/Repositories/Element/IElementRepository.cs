using DotNet8.PersonalityTestCard.Models.Setup.Element;

namespace DotNet8.PersonalityTestCard.Api.Repositories.Element
{
	public interface IElementRepository
	{
		Task<ElementListResponseModel> GetCardsAsync();
	}
}
