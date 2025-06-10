namespace DotNet8.PersonalityTestCard.Api.Repositories.UserElementScore;

public class UserElementScoreRepository : IUserElementScoreRepository
{
	private readonly AppDbContext _appDbContext;

	public UserElementScoreRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<UserElementScoreRequestModel> GetUserElementScoreAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblUserElementScores
					.Include(x => x.Element)
					.AsNoTracking()
					.OrderByDescending(x => x.UserElementId)
					.ToListAsync();


			var lst = dataLst.Select(x => x.Change()).ToList();

			UserElementScoreRequestModel responseModel = new()
			{
				DataLst = lst
			};

			return responseModel;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
