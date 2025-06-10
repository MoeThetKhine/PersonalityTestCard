
namespace DotNet8.PersonalityTestCard.Api.Features.UserElementScore.Queries.GetUserElementScoreByUserId
{
	public class GetUserElementScoreByUserIdQueryHandler : IRequestHandler<GetUserElementScoreByUserIdQuery, UserElementScoreResponseModel>
	{
		private readonly IUserElementScoreRepository _userElementScoreRepository;

		public GetUserElementScoreByUserIdQueryHandler(IUserElementScoreRepository userElementScoreRepository)
		{
			_userElementScoreRepository = userElementScoreRepository;
		}

		public async Task<UserElementScoreResponseModel> Handle(GetUserElementScoreByUserIdQuery request, CancellationToken cancellationToken)
		{
			if (request.UserId <= 0)
				throw new Exception("User Id cannot be empty");

			return await _userElementScoreRepository.GetUserElementScoreByUserIdAsync(request.UserId);
		}
	}
}
