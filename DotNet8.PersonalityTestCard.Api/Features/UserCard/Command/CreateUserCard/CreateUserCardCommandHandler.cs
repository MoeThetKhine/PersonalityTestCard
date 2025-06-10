namespace DotNet8.PersonalityTestCard.Api.Features.UserCard.Command.CreateUserCard;

public class CreateUserCardCommandHandler : IRequestHandler<CreateUserCardCommand, int>
{
	private readonly IUserCardRepository _userCardRepository;
	private readonly AppDbContext _context;

	public CreateUserCardCommandHandler(IUserCardRepository userCardRepository, AppDbContext context)
	{
		_userCardRepository = userCardRepository;
		_context = context;
	}

	#region Handle

	public async Task<int> Handle(CreateUserCardCommand request, CancellationToken cancellationToken)
	{
		if (request.CardIds == null || request.CardIds.Count != 13)
			throw new Exception("You must select exactly 13 cards.");

		// Delete existing cards
		var existingCards = await _userCardRepository.GetUserCardsAsync(request.UserId);
		await _userCardRepository.RemoveUserCardsAsync(existingCards);

		// Add new cards
		var userCards = request.CardIds.Select(cardId => new TblUserCard
		{
			UserId = request.UserId,
			CardId = cardId
		}).ToList();

		await _userCardRepository.AddUserCardsAsync(userCards);
		await _userCardRepository.SaveChangesAsync();

		// Get ElementId from selected cards
		var cardElementPairs = await _context.TblCards
			.Where(x => request.CardIds.Contains(x.CardId))
			.Select(x => new { x.ElementId })
			.ToListAsync();

		var elementScore = cardElementPairs
			.GroupBy(x => x.ElementId)
			.ToDictionary(g => g.Key, g => g.Count());

		// Remove existing scores
		var existingScores = await _context.TblUserElementScores
			.Where(x => x.UserId == request.UserId)
			.ToListAsync();

		_context.TblUserElementScores.RemoveRange(existingScores);

		// Save new scores
		var scoresToAdd = elementScore.Select(x => new TblUserElementScore
		{
			UserId = request.UserId,
			ElementId = x.Key,
			Score = x.Value
		}).ToList();

		await _context.TblUserElementScores.AddRangeAsync(scoresToAdd);
		await _context.SaveChangesAsync();

		return 1;

	}

	#endregion
}
