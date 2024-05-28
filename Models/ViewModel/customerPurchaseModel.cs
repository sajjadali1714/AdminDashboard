using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models.ViewModel
{
    public class CustomerPurchase {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Int64? price { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}