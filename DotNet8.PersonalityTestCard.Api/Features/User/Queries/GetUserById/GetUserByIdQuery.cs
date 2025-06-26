namespace DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserById;

#region GetUserByIdQuery

public class GetUserByIdQuery : IRequest<Result<UserModel>>
{
	public int UserId { get; set; }
}

#endregion