namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
{
	private readonly IUserRepository _userRepository;

	public UpdateUserCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Result<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		if (request.UserId <= 0)
			return Result<int>.Failure("User ID must be greater than zero.");

		return await _userRepository.UpdateUserAsync(request.userRequestModel, request.UserId);
	}
}
