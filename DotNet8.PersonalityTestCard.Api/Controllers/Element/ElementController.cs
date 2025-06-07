using DotNet8.PersonalityTestCard.Api.Features.Element.Queries.GetElementList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.PersonalityTestCard.Api.Controllers.Element
{
	[Route("api/[controller]")]
	[ApiController]
	public class ElementController : BaseController
	{
		private readonly IMediator _mediator;

		public ElementController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetElementAsync()
		{
			try
			{
				var query = new GetElementListQuery();
				var lst = await _mediator.Send(query);

				return Content(lst);
			}

			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
