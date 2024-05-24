using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models.ViewModel
{
    public class salesViewModel
    {
        public Int64 totalOrders { get; set; }
        public Int64 monthOrders { get; set; }
        
        public Int64 totalProductSales { get; set; }
        public Int64 monthlyProductSales { get; set; }

        public Int64 totalRevenue { get; set; }
        public Int64 monthRevenue { get; set; }

        public Int64 totalProfit { get; set; }
        public Int64 monthProfit{ get; set; }

        public decimal[]? FiveMonthSales { get; set; }
        public decimal[]? pastFiveMonthSales{ get; set; }
        public decimal[]? branchSales{ get; set; }

        public Int64 dailySales { get; set; }
        public Int64 monthSales { get; set; }
        public Int64 yearSales { get; set; }
        public List<BranchSales>? BranchSales { get; set; }


        public salesViewModel()
        {
            BranchSales = new List<BranchSales>();
        }

    }

    public class BranchSales
    {
        public string? orderMonth { get; set; }
        public string? BranchName { get; set; }
        public Int64? totalSale { get; set; }
        public Int64? maxSale { get; set; }
        public Int64? minSale { get; set; }
        public Int64? avgSale { get; set; }
    }
}


