using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models.ViewModel
{

    public abstract class CustomerBase
{
    // Common properties, if any
}
    public class CustomerPurchase : CustomerBase{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Int64? price { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategoryName { get; set; }
    }

    public class CustomerDetails : CustomerBase
    {
        public string? FirstName { get; set; }
        public string? CustomerTypeName { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public Int64? TotalQuantityPurchased { get; set; }
        public double? TopRating { get; set; }
}
}