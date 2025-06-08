using DotNet8.PersonalityTestCard.Api.Features.User.Command.CreateUser;

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

	#region GetUserListAsync

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

	#endregion

	#region CreateUserAsync

	[HttpPost]
	public async Task<IActionResult> CreateUserAsync([FromBody] UserRequestModel requestModel)
	{
		try
		{
			var command = new CreateUserCommand()
			{
				userRequest = requestModel
			};
			int result = await _mediator.Send(command);

			return result > 0 ? Created("Register Successful") : BadRequest("Creating Fail.");
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

}
