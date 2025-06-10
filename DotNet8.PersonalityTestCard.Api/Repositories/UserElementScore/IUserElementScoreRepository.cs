namespace DotNet8.PersonalityTestCard.Api.Repositories.UserElementScore;

public interface IUserElementScoreRepository
{
	Task<UserElementScoreRequestModel> GetUserElementScoreAsync();
}
