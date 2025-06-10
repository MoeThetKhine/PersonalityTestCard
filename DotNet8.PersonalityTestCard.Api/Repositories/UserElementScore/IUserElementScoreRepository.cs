namespace DotNet8.PersonalityTestCard.Api.Repositories.UserElementScore;

#region IUserElementScoreRepository

public interface IUserElementScoreRepository
{
	Task<UserElementScoreRequestModel> GetUserElementScoreAsync();
}

#endregion