namespace DotNet8.PersonalityTestCard.Api.Repositories.Element;

#region IElementRepository

public interface IElementRepository
{
	Task<Result<ElementListResponseModel>> GetElementAsync();
}

#endregion