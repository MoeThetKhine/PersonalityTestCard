using System;
using System.Collections.Generic;

namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

public partial class TblUserElementScore
{
    public int UserElementId { get; set; }

    public int UserId { get; set; }

    public int ElementId { get; set; }

    public int Score { get; set; }

    public virtual TblElement Element { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
