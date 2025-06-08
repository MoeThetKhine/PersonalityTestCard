namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

public interface IUserRepository
{
	Task<UserListResponseModel> GetUserListAsync();
}
