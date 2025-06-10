using DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScore;

namespace DotNet8.PersonalityTestCard.Api.Controllers.UserElementScore;

[Route("api/[controller]")]
[ApiController]
public class UserElementScoreController : BaseController
{
	private readonly IMediator _mediator;

	public UserElementScoreController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetUserElementScoreAsync()
	{
		try
		{
			var query = new GetUserElementScoreQuery();
			var lst = await _mediator.Send(query);

			return Content(lst);
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}
}
