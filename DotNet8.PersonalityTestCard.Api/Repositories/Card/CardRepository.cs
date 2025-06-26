using DotNet8.PersonalityTestCard.Models.Resources;

namespace DotNet8.PersonalityTestCard.Api.Repositories.Card;

public class CardRepository : ICardRepository
{

	private readonly AppDbContext _appDbContext;

	public CardRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetCardsAsync

	public async Task<Result<CardListResponseModel>> GetCardsAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblCards
				.AsNoTracking()
				.OrderBy(x => x.CardName)
				.ToListAsync();

			if (!dataLst.Any())
				return Result<CardListResponseModel>.NotFound(MessageResource.NotFound);

			var lst = dataLst.Select(x => x.Change()).ToList();

			CardListResponseModel responseModel = new()
			{
				DataLst = lst
			};

			return Result<CardListResponseModel>.Success(responseModel, MessageResource.Success);
		}
		catch (Exception ex)
		{
			return Result<CardListResponseModel>.Failure(ex);
		}
	}


	#endregion
}
