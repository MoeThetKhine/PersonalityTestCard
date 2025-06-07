namespace DotNet8.PersonalityTestCard.Models;

public static class ChangeModel
{

	public static CardListModel Change(this CardListModel dataModel)
	{
		return new CardListModel
		{
			CardId = dataModel.CardId,
			CardName = dataModel.CardName,
			ElementId = dataModel.ElementId,
		};
	}


}
