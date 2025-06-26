namespace DotNet8.PersonalityTestCard.Api.Repositories.User;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	#region GetUserListAsync

	public async Task<Result<UserListResponseModel>> GetUserListAsync()
	{
		try
		{
			var dataLst = await _context.TblUsers
				.AsNoTracking()
				.OrderByDescending(x => x.UserId)
				.ToListAsync();

			if (!dataLst.Any())
				return Result<UserListResponseModel>.NotFound("No users found.");

			var lst = dataLst.Select(x => x.Change()).ToList();

			var responseModel = new UserListResponseModel { DataLst = lst };

			return Result<UserListResponseModel>.Success(responseModel);
		}
		catch (Exception ex)
		{
			return Result<UserListResponseModel>.Failure(ex);
		}
	}

	#endregion

	#region CreateUserAsync

	public async Task<Result<int>> CreateUserAsync(UserRequestModel requestModel)
	{
		try
		{
			await _context.TblUsers.AddAsync(requestModel.Change());
			var result = await _context.SaveChangesAsync();

			return result > 0
				? Result<int>.Success(result, "User created successfully.")
				: Result<int>.Failure("Creating user failed.");
		}
		catch (Exception ex)
		{
			return Result<int>.Failure(ex);
		}
	}

	#endregion

	#region GetUserByIdAsync

	public async Task<Result<UserModel>> GetUserByIdAsync(int id)
	{
		try
		{
			var item = await _context.TblUsers
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.UserId == id);

			if (item == null)
				return Result<UserModel>.NotFound("User not found.");

			return Result<UserModel>.Success(item.Change());
		}
		catch (Exception ex)
		{
			return Result<UserModel>.Failure(ex);
		}
	}

	#endregion

	#region UpdateUserAsync

	public async Task<Result<int>> UpdateUserAsync(UserRequestModel requestModel, int id)
	{
		try
		{
			var item = await _context.TblUsers
				.FirstOrDefaultAsync(x => x.UserId == id);

			if (item == null)
				return Result<int>.NotFound($"User with ID {id} not found.");

			if (!string.IsNullOrEmpty(requestModel.Username))
				item.Username = requestModel.Username;

			_context.Entry(item).State = EntityState.Modified;
			var result = await _context.SaveChangesAsync();

			return Result<int>.Success(result, "User updated successfully.");
		}
		catch (Exception ex)
		{
			return Result<int>.Failure(ex);
		}
	}

	#endregion

}
