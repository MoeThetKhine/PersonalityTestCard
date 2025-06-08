namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
	private readonly IUserRepository _userRepository;

	public CreateUserCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	#region Handle

	public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		if(string.IsNullOrEmpty(request.userRequest.Username))
		{
			throw new Exception("Username cannot be empty");
		}
		if (string.IsNullOrEmpty(request.userRequest.Email))
		{
			throw new Exception("Email cannot be empty");
		}

		return await _userRepository.CreateUserAsync(request.userRequest);
	}

	#endregion

}
