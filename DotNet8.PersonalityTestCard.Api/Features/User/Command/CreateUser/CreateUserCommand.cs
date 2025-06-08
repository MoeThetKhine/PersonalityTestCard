namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.CreateUser;

public class CreateUserCommand : IRequest<int>
{
	public UserRequestModel userRequest {  get; set; }
}
