namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	#region GetUserListAsync

	public async Task<UserListResponseModel> GetUserListAsync()
	{
		try
		{
			var dataLst = await _context.TblUsers
				.AsNoTracking()
				.OrderByDescending(x => x.UserId)
				.ToListAsync();

			var lst = dataLst.Select(x => x.Change()).ToList();

			UserListResponseModel responseModel = new()
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
}
