using System;
using System.Collections.Generic;

namespace AdminDashboard.Models;

public partial class VwSalesDetail
{
    public int Id { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public string CustomerTypeName { get; set; } = null!;


    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public double UnitPrice { get; set; }

    public int Quantity { get; set; }

    public double Tax { get; set; }

    public decimal? TotalSalesAmount { get; set; }

    public DateOnly OrderDate { get; set; }

    public TimeOnly OrderTime { get; set; }

    public string PaymentTypeName { get; set; } = null!;

    public decimal? Cogs { get; set; }

    public decimal? GrossMarginper { get; set; }

    public decimal? GrossIncome { get; set; }

    public string? Rating { get; set; }

    public string TimeOfDay { get; set; } = null!;

    public string? DayName { get; set; }

    public string? MonthName { get; set; }
    
    public string? OrderYear { get; set; }
}
