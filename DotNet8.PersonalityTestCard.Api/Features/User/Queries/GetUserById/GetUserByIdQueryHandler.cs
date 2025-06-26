namespace DotNet8.PersonalityTestCard.Api.Features.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserModel>>
{
	private readonly IUserRepository _userRepository;

	public GetUserByIdQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Result<UserModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		if (request.UserId <= 0)
			return Result<UserModel>.Failure("User ID must be greater than zero.");

		return await _userRepository.GetUserByIdAsync(request.UserId);
	}
}

