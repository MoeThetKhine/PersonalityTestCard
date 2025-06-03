namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

#region TblUserCard

public partial class TblUserCard
{
    public int UserCardId { get; set; }

    public int UserId { get; set; }

    public int CardId { get; set; }

    public virtual TblCard Card { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}

#endregion