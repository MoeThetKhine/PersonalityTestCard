namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

#region TblUser

public partial class TblUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TblUserCard> TblUserCards { get; set; } = new List<TblUserCard>();

    public virtual ICollection<TblUserElementScore> TblUserElementScores { get; set; } = new List<TblUserElementScore>();
}

#endregion