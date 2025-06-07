﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet8.PersonalityTestCard.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{

	#region Content

	protected IActionResult Content(object? obj)
	{
		return Content(JsonConvert.SerializeObject(obj), "application/json"); 
	}

	#endregion

	#region InternalServerError

	protected IActionResult InternalServerError(Exception ex)
	{
		return StatusCode(500, ex.Message);
	}

	#endregion

	#region Created

	protected IActionResult Created(string message)
	{
		return StatusCode(201, message);
	}

	#endregion

	protected IActionResult Accepted(string message)
	{
		return StatusCode(202, message);
	}

}
