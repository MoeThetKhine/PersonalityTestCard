namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
	private readonly IUserRepository _userRepository;

	public CreateUserCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrEmpty(request.userRequest.Username))
			return Result<int>.Failure("Username cannot be empty.");

		if (string.IsNullOrEmpty(request.userRequest.Email))
			return Result<int>.Failure("Email cannot be empty.");

		return await _userRepository.CreateUserAsync(request.userRequest);
	}
}

