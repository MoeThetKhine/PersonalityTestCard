namespace DotNet8.PersonalityTestCard.Api.Repositories.UserCard;

public class UserCardRepository : IUserCardRepository
{
	private readonly AppDbContext _context;

	public UserCardRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<TblUserCard>> GetUserCardsAsync(int userId)
	{
		return await _context.TblUserCards
			.Where(x => x.UserId == userId)
			.ToListAsync();
	}

	public async Task RemoveUserCardsAsync(List<TblUserCard> userCards)
	{
		_context.TblUserCards.RemoveRange(userCards);
		await Task.CompletedTask;
	}

	public async Task AddUserCardsAsync(List<TblUserCard> userCards)
	{
		await _context.TblUserCards.AddRangeAsync(userCards);
	}

	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}
}
