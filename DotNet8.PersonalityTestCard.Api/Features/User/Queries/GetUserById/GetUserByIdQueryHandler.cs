
namespace DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
{

	private readonly IUserRepository _userRepository;

	public GetUserByIdQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		if (request.UserId <= 0)
			throw new Exception("Id cannot be empty");

		return await _userRepository.GetUserByIdAsync(request.UserId);
	}
}
