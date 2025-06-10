using DotNet8.PersonalityTestCard.Models.Setup.UserElementScore;

namespace DotNet8.PersonalityTestCard.Api.Repositories.UserElementScore;

public interface IUserElementScoreRepository
{
	Task<UserElementScoreRequestModel> GetUserElementScoreAsync();
}
