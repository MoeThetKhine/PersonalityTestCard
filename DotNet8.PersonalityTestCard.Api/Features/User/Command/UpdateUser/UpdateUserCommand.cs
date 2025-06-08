namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.UpdateUser;

public class UpdateUserCommand : IRequest<int>
{
	public UserRequestModel userRequestModel { get; set; }
	public int UserId {  get; set; }
}
