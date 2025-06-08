namespace DotNet8.PersonalityTestCard.Api.Repositories.Element;

public class ElementRepository : IElementRepository
{
	private readonly AppDbContext _appDbContext;

	public ElementRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	#region GetElementAsync

	public async Task<ElementListResponseModel> GetElementAsync()
	{
		try
		{
			var dataLst = await _appDbContext.TblElements
				.AsNoTracking()
				.OrderByDescending(x => x.ElementId)
				.ToListAsync();

			var lst = dataLst.Select(x => x.Change()).ToList();

			ElementListResponseModel responseModel = new()
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
