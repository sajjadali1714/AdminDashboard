using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string BranchName { get; set; } = null!;

    public int? Cityid { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
