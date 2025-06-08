using DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserList;

namespace DotNet8.PersonalityTestCard.Api.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
	private readonly IMediator _mediator;

	public UserController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> GetUserListAsync()
	{
		try
		{
			var query = new GetUserListQuery();
			var lst = await _mediator.Send(query);

			return Content(lst);
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}
}
