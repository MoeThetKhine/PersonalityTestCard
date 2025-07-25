﻿namespace DotNet8.PersonalityTestCard.Api.Repositories.UserCard;

#region IUserCardRepository

public interface IUserCardRepository
{
	Task<List<TblUserCard>> GetUserCardsAsync(int userId);
	Task RemoveUserCardsAsync(List<TblUserCard> userCards);
	Task AddUserCardsAsync(List<TblUserCard> userCards);
	Task SaveChangesAsync();
}

#endregion
