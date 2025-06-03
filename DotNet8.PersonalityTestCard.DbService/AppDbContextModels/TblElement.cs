namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

public partial class TblElement
{
    public int ElementId { get; set; }

    public string ElementName { get; set; } = null!;

    public virtual ICollection<TblCard> TblCards { get; set; } = new List<TblCard>();

    public virtual ICollection<TblUserElementScore> TblUserElementScores { get; set; } = new List<TblUserElementScore>();
}
