namespace DotNet8.PersonalityTestCard.Api.Features.User.Command.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand , int>
{
	private readonly IUserRepository _userRepository;

	public UpdateUserCommandHandler(IUserRepository userRepository)
	{
		this._userRepository = userRepository;
	}

	public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		if(request.UserId <= 0)
		{
			throw new Exception("Blog Id cannot be empty.");
		}

		return await _userRepository.UpdateUserAsync(request.userRequestModel, request.UserId);
	}
}
