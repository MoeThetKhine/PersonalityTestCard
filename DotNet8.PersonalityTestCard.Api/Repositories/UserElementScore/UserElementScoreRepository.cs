namespace DotNet8.PersonalityTestCard.Api.Repositories.UserElementScore;

public class UserElementScoreRepository : IUserElementScoreRepository
{
	private readonly AppDbContext _appDbContext;

	public UserElementScoreRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetUserElementScoreAsync

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

	#endregion


	public async Task<UserElementScoreResponseModel> GetUserElementScoreByUserIdAsync(int id)
	{
		try
		{
			var item = await _appDbContext.TblUserElementScores
				.Include(x => x.User) // Include user navigation property
				.Include(x => x.Element) // Include element navigation property
				.AsNoTracking()
				.Where(x => x.UserId == id)
				.OrderByDescending(x => x.Score) // Optional: get top score
				.FirstOrDefaultAsync()
				?? throw new Exception("No data found");

			return item.ElementScoreChange(); // your mapper
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
