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
		var result = await _mediator.Send(new GetUserListQuery());

		if (result.IsSuccess)
			return Content(result);

		return StatusCode((int)result.StatusCode, result);
	}

	#endregion

	#region GetUserByIdAsync

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserByIdAsync(int id)
	{
		var result = await _mediator.Send(new GetUserByIdQuery { UserId = id });

		if (result.IsSuccess)
			return Content(result);

		return StatusCode((int)result.StatusCode, result);
	}

	#endregion

	#region CreateUserAsync

	[HttpPost]
	public async Task<IActionResult> CreateUserAsync([FromBody] UserRequestModel requestModel)
	{
		var result = await _mediator.Send(new CreateUserCommand { userRequest = requestModel });

		if (result.IsSuccess)
			return Created(result.Message);

		return StatusCode((int)result.StatusCode, result);
	}

	#endregion

	#region UpdateUserAsync

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUserAsync([FromBody] UserRequestModel userRequestModel, int id)
	{
		var result = await _mediator.Send(new UpdateUserCommand
		{
			userRequestModel = userRequestModel,
			UserId = id
		});

		if (result.IsSuccess)
			return Ok(result);

		return StatusCode((int)result.StatusCode, result);
	}

	#endregion

}
