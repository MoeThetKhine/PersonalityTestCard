namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

#region TblCard

public partial class TblCard
{
    public int CardId { get; set; }

    public string CardName { get; set; } = null!;

    public int ElementId { get; set; }

    public virtual TblElement Element { get; set; } = null!;

    public virtual ICollection<TblUserCard> TblUserCards { get; set; } = new List<TblUserCard>();
}

#endregion