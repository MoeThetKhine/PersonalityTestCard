
namespace DotNet8.PersonalityTestCard.Api.Repositories.Card;

public class CardRepository : ICardRepository
{

	private readonly AppDbContext _appDbContext;

	public CardRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetCardsAsync

	public async Task<CardListResponseModel> GetCardsAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblCards
				 .AsNoTracking()
				 .OrderBy(x => x.CardName)
				 .ToListAsync();

			var lst = dataLst.Select(x => x.Change()).ToList();

			CardListResponseModel responseModel = new()
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
