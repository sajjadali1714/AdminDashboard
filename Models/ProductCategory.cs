using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
