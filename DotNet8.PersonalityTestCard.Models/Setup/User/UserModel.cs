﻿namespace DotNet8.PersonalityTestCard.Models.Setup.User;

#region UserModel

public class UserModel
{
	public int UserId { get; set; }

	public string Username { get; set; } = null!;

	public string Email { get; set; } = null!;

	public DateTime CreatedAt { get; set; }
}

#endregion