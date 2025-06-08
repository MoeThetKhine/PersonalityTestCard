namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

public interface IUserRepository
{
	Task<UserListResponseModel> GetUserListAsync();
	Task<UserModel> GetUserByIdAsync(int id);
	Task<int> CreateUserAsync(UserRequestModel requestModel);
}
