using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models.ViewModel
{
    public class ProductDashboardViewModel
    {
        public decimal[]? TotalRevenueProductCategory { get; set; }
        public decimal[]? PastTotalRevenueProductCategory { get; set; }
        public int[]? TotalOrdersProductCategory{ get; set; }
        public decimal[]? ProductCategoryByMale{ get; set; }
        public decimal[]? ProductCategoryByFemale{ get; set; }

        public decimal[]? CommonPaymentMethod { get; set; }
        public decimal[]? AverageRatingProductCategory{ get; set; }
        public decimal[]? CaliforniaBranchProductCategoryRevenue{ get; set; }
        public decimal[]? FloridaBranchProductCategoryRevenue{ get; set; }
        public decimal[]? TexasBranchProductCategoryRevenue{ get; set; }
    }
}