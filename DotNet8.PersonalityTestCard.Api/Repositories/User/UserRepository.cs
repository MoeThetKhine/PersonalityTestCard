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

	#region CreateUserAsync

	public async Task<int> CreateUserAsync(UserRequestModel requestModel)
	{
		try
		{
			await _context.TblUsers.AddAsync(requestModel.Change());
			return await _context.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	#endregion

	#region GetUserByIdAsync

	public async Task<UserModel> GetUserByIdAsync(int id)
	{
		try
		{
			var item = await _context.TblUsers
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.UserId == id)
				?? throw new Exception("No data found");

			return item.Change();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<int> UpdateUserAsync(UserRequestModel requestModel, int id)
	{
		try
		{
			var item = await _context.TblUsers
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.UserId == id) ?? throw new Exception("Blog Id cannot be empty.");

			if (!string.IsNullOrEmpty(requestModel.Username))
			{
				item.Username = requestModel.Username;
			}
			if (!string.IsNullOrEmpty(requestModel.Email))
			{
				item.Email = requestModel.Email;
			}

			_context.Entry(item).State = EntityState.Modified;
			return await _context.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}

	}

	#endregion
}
