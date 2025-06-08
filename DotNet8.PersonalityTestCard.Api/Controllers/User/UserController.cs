using DotNet8.PersonalityTestCard.Api.Features.User.Command.UpdateUser;

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

	#region GetBlogByIdAsync

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBlogByIdAsync(int id)
	{
		try
		{
			var query = new GetUserByIdQuery() { UserId = id };
			var item = await _mediator.Send(query);

			return Content(item);
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

	#region UpdateUserAsync

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUserAsync([FromBody] UserRequestModel userRequestModel, int id)
	{
		try
		{
			var command = new UpdateUserCommand()
			{
				userRequestModel = userRequestModel,
				UserId = id,
			};

			int result = await _mediator.Send(command);

			if (result > 0)
			{
				return Ok(new
				{
					Message = "User updated successfully",
					UserId = id
				});
			}
			else
			{
				return NotFound(new
				{
					Message = $"User with ID {id} not found or update failed"
				});
			}
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion

}
