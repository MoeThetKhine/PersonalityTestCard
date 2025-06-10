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

	#region UserElementScoreModel

	public static UserElementScoreModel Change(this TblUserElementScore dataModel)
	{
		return new UserElementScoreModel
		{
			UserElementId = dataModel.UserElementId,
			UserId = dataModel.UserId,
			ElementId = dataModel.ElementId,
			Score = dataModel.Score,
			ElementName = dataModel.Element?.ElementName!
		};
	}

	#endregion

	public static UserElementScoreResponseModel ElementScoreChange(this TblUserElementScore dataModel)
	{
		return new UserElementScoreResponseModel
		{
			UserId = dataModel.UserId,
			Username = dataModel.User?.Username!,
			ElementName = dataModel.Element?.ElementName!,
			Score = dataModel.Score,
		};
	}

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

	#region TblUser

	public static TblUser Change(this UserRequestModel requestModel)
	{
		return new TblUser
		{
			Username = requestModel.Username,
			Email = requestModel.Email,
		};
	}

	#endregion

}
