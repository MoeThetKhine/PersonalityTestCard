using DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScoreByUserId;

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

	#region GetUserElementScoreAsync

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

	#endregion

	[HttpGet("{userId}")]

	public async Task<IActionResult> GetUserElementScoreByUserIdAsync(int userId)
	{
		try
		{
			var query = new GetUserElementScoreByUserIdQuery()
			{
				UserId = userId
			};

			var item = await _mediator.Send(query);

			return Content(item);
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}
}
