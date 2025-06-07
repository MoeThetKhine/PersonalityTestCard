using DotNet8.PersonalityTestCard.Models.Setup.Element;

namespace DotNet8.PersonalityTestCard.Models;

public static class ChangeModel
{

	#region CardListModel

	public static CardListModel Change(this TblCard dataModel)
	{
		return new CardListModel
		{
			CardId = dataModel.CardId,
			CardName = dataModel.CardName,
			//ElementId = dataModel.ElementId,
		};
	}

	#endregion

	public static ElementListModel Change(this TblElement dataModel)
	{
		return new ElementListModel
		{
			ElementId = dataModel.ElementId,
			ElementName = dataModel.ElementName,
		};
	}
}
