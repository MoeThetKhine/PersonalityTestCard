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

	#region ElementListModel

	public static ElementListModel Change(this TblElement dataModel)
	{
		return new ElementListModel
		{
			ElementId = dataModel.ElementId,
			ElementName = dataModel.ElementName,
		};
	}

	#endregion

	#region UserModel

	public static UserModel Change(this TblUser dataModel)
	{
		return new UserModel
		{
			UserId = dataModel.UserId,
			Username = dataModel.Username,
			Email = dataModel.Email,
			CreatedAt = dataModel.CreatedAt,
		};
	}

	#endregion
}
