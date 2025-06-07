using DotNet8.PersonalityTestCard.Api.Features.Card.Queries.GetCardList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.PersonalityTestCard.Api.Controllers.Card
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardController : BaseController
	{
		private readonly IMediator _mediator;

		public CardController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCardAsync()
		{
			try
			{
				var query = new GetCardListQuery();
				var lst = await _mediator.Send(query);

				return Content(lst);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
