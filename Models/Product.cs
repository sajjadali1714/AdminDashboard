using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public double UnitPrice { get; set; }

    public int TaxPercentage { get; set; }

    public string? Rating { get; set; }

    public int? ProductCategoryid { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
