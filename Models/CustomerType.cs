using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string CustomerTypeName { get; set; } = null!;
}
