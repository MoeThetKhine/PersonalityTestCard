namespace DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserModel>
{
	public int UserId {  get; set; }
}
