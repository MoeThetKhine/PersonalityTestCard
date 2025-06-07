using DotNet8.PersonalityTestCard.Models.Setup.Card;
using MediatR;

namespace DotNet8.PersonalityTestCard.Api.Features.Card.Queries.GetCardList;

public class GetCardListQuery : IRequest<CardListResponseModel>
{
}
