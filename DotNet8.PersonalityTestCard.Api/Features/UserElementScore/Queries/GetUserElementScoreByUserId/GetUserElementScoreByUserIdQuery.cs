namespace DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScoreByUserId;

#region GetUserElementScoreByUserIdQuery

public class GetUserElementScoreByUserIdQuery : IRequest<UserElementScoreResponseModel>
{
	public int UserId {  get; set; }
}

#endregion