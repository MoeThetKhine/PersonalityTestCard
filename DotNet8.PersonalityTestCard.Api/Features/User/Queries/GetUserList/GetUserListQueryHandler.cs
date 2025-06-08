using DotNet8.PersonalityTestCard.Api.Repositories.User;
using DotNet8.PersonalityTestCard.Models.Setup.User;

namespace DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserList
{
	public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListResponseModel>
	{
		private readonly IUserRepository _userRepository;

		public GetUserListQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserListResponseModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
		{
			return await _userRepository.GetUserListAsync();
		}
	}
}
