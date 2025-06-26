namespace DotNet8.PersonalityTestCard.Api.Features.Card.Queries.GetCardList;

#region GetCardListQueryHandler

public class GetCardListQueryHandler : IRequestHandler<GetCardListQuery, Result<CardListResponseModel>>
{
	private readonly ICardRepository _cardRepository;

	public GetCardListQueryHandler(ICardRepository cardRepository)
	{
		_cardRepository = cardRepository;
	}

	public async Task<Result<CardListResponseModel>> Handle(GetCardListQuery request, CancellationToken cancellationToken)
	{
		return await _cardRepository.GetCardsAsync();
	}
}


#endregion
