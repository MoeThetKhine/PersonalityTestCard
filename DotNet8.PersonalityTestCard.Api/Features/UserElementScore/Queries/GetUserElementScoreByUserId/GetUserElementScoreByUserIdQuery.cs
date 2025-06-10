namespace DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScoreByUserId
{
	public class GetUserElementScoreByUserIdQuery : IRequest<UserElementScoreResponseModel>
	{
		public int UserId {  get; set; }
	}
}
