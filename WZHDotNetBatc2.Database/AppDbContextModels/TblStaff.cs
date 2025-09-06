using System;
using System.Collections.Generic;

namespace WZHDotNetBatc2.Database.AppDbContextModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string StaffCode { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}
