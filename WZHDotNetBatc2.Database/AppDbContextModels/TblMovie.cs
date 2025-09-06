using System;
using System.Collections.Generic;

namespace WZHDotNetBatc2.Database.AppDbContextModels;

public partial class TblMovie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }

    public bool DeleteFlag { get; set; }
}
