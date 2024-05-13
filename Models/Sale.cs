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

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual PaymentType? PaymentType { get; set; }

    public virtual Product? Product { get; set; }
}

/*
1 Cost of Goods Sold (COGS):
COGS = Unit Price × Quantity

Value Added Tax (VAT):
VAT=0.05×COGS

Total Gross Sales (Total Revenue):
Total Gross Sales=VAT+COGS

Gross Profit (Gross Income):
Gross Profit=Total Gross Sales−COGS

Gross Margin:
Gross Margin (%)=( Gross Profit / Total Gross Sales)×100

*/
