using DotNet8.PersonalityTestCard.Models.Resources;

namespace DotNet8.PersonalityTestCard.Api.Repositories.Element;

public class ElementRepository : IElementRepository
{
	private readonly AppDbContext _appDbContext;

	public ElementRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetElementAsync

	public async Task<Result<ElementListResponseModel>> GetElementAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblElements
				.AsNoTracking()
				.OrderByDescending(x => x.ElementId)
				.ToListAsync();

			if (!dataLst.Any())
				return Result<ElementListResponseModel>.NotFound(MessageResource.NotFound);

			var lst = dataLst.Select(x => x.Change()).ToList();

			ElementListResponseModel responseModel = new()
			{
				DataLst = lst
			};

			return Result<ElementListResponseModel>.Success(responseModel, MessageResource.Success);
		}
		catch (Exception ex)
		{
			return Result<ElementListResponseModel>.Failure(ex);
		}
	}

	#endregion
}
