using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string PaymentTypeName { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
