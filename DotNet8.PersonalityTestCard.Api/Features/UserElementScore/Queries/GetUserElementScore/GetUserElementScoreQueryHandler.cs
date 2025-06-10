namespace DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScore;

public class GetUserElementScoreQueryHandler : IRequestHandler<GetUserElementScoreQuery, UserElementScoreRequestModel>
{
	private readonly IUserElementScoreRepository _userElementScoreRepository;

	public GetUserElementScoreQueryHandler(IUserElementScoreRepository userElementScoreRepository)
	{
		_userElementScoreRepository = userElementScoreRepository;
	}

	#region Handle

	public async Task<UserElementScoreRequestModel> Handle(GetUserElementScoreQuery request, CancellationToken cancellationToken)
	{
		return await _userElementScoreRepository.GetUserElementScoreAsync();
	}

	#endregion
}
