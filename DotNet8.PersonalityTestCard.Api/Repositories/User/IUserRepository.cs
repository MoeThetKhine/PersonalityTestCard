using DotNet8.PersonalityTestCard.Models.Setup.User;

namespace DotNet8.PersonalityTestCard.Api.Repositories.User
{
	public interface IUserRepository
	{
		Task<UserListResponseModel> GetUserListAsync();
	}
}
