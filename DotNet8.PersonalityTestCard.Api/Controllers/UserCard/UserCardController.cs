namespace DotNet8.PersonalityTestCard.Api.Controllers.UserCard;

[Route("api/[controller]")]
[ApiController]
public class UserCardController : BaseController
{
	private readonly IMediator _mediator;

	public UserCardController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region CreateUserCardAsync

	[HttpPost("{userId}")]
	public async Task<IActionResult> CreateUserCardAsync(int userId, [FromBody] List<int> cardIds)
	{
		try
		{
			var command = new CreateUserCardCommand
			{
				UserId = userId,
				CardIds = cardIds
			};

			var result = await _mediator.Send(command);

			return result > 0
				? Ok(new { Message = "User cards saved and scores updated successfully." })
				: BadRequest("Failed to assign cards.");
		}
		catch (Exception ex)
		{
			return InternalServerError(ex);
		}
	}

	#endregion
}
