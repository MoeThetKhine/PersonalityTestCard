
namespace DotNet8.PersonalityTestCard.Api.Controllers.Card;

[Route("api/[controller]")]
[ApiController]
public class CardController : BaseController
{
	private readonly IMediator _mediator;

	public CardController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region GetCardAsync

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

	#endregion
}
