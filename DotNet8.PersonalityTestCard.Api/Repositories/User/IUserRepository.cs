namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

#region IUserRepository

public interface IUserRepository
{
	Task<UserListResponseModel> GetUserListAsync();
	Task<UserModel> GetUserByIdAsync(int id);
	Task<int> CreateUserAsync(UserRequestModel requestModel);
	Task<int> UpdateUserAsync(UserRequestModel requestModel, int id);
}

#endregion