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
			var result = await _mediator.Send(query);

			if (result.IsSuccess)
				return Content(result);

			return StatusCode((int)result.StatusCode, result);
		}
		catch (Exception ex)
		{
			var errorResult = Result<CardListResponseModel>.Failure(ex);
			return StatusCode((int)errorResult.StatusCode, errorResult);
		}
	}

	#endregion



}
