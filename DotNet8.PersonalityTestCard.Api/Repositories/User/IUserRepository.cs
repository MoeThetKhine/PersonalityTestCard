namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

#region IUserRepository

public interface IUserRepository
{
	Task<Result<UserListResponseModel>> GetUserListAsync();
	Task<Result<UserModel>> GetUserByIdAsync(int id);
	Task<Result<int>> CreateUserAsync(UserRequestModel requestModel);
	Task<Result<int>> UpdateUserAsync(UserRequestModel requestModel, int id);
}

#endregion