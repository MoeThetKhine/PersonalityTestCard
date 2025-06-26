namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.CreateUser;

#region CreateUserCommand

public class CreateUserCommand : IRequest<Result<int>>
{
	public UserRequestModel userRequest { get; set; }
}

#endregion
