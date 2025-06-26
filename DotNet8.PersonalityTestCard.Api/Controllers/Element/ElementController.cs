namespace DotNet8.PersonalityTestCard.Api.Controllers.Element;

[Route("api/[controller]")]
[ApiController]
public class ElementController : BaseController
{
	private readonly IMediator _mediator;

	public ElementController(IMediator mediator)
	{
		_mediator = mediator;
	}

	#region GetElementAsync

	[HttpGet]
	public async Task<IActionResult> GetElementAsync()
	{
		try
		{
			var query = new GetElementListQuery();
			var result = await _mediator.Send(query);

			if (result.IsSuccess)
				return Content(result);

			return StatusCode((int)result.StatusCode, result);
		}
		catch (Exception ex)
		{
			var errorResult = Result<ElementListResponseModel>.Failure(ex);
			return StatusCode((int)errorResult.StatusCode, errorResult);
		}
	}

	#endregion
}
