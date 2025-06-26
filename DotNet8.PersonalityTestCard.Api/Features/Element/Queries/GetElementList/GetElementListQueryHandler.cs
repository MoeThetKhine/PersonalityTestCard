namespace DotNet8.PersonalityTestCard.Api.Features.Element.Queries.GetElementList;

#region GetElementListQueryHandler

public class GetElementListQueryHandler : IRequestHandler<GetElementListQuery, Result<ElementListResponseModel>>
{
	private readonly IElementRepository _elementRepository;

	public GetElementListQueryHandler(IElementRepository elementRepository)
	{
		_elementRepository = elementRepository;
	}

	public async Task<Result<ElementListResponseModel>> Handle(GetElementListQuery request, CancellationToken cancellationToken)
	{
		return await _elementRepository.GetElementAsync();
	}
}

#endregion
