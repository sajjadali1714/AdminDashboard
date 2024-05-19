using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class Sale
{
    public int Id { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public int? BranchId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int? PaymentTypeId { get; set; }

    public string Gender { get; set; } = null!;

    public int Quantity { get; set; }

    public double Tax { get; set; }

    public DateOnly OrderDate { get; set; }

    public TimeOnly OrderTime { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual PaymentType? PaymentType { get; set; }

    public virtual Product? Product { get; set; }
}
