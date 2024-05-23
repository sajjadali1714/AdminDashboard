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

        public Int64[]? SixMonthSales { get; set; }
        public Int64[]? pastSixMonthSales{ get; set; }
        public Int64[]? branchSales{ get; set; }

        public Int64 dailySales { get; set; }
        public Int64 monthSales { get; set; }
        public Int64 yearSales { get; set; }
        public List<TopCustomers>? TopCustomer { get; set; }


        public salesViewModel()
        {
            TopCustomer = new List<TopCustomers>();
        }

    }

    public class TopCustomers
    {
        public string? FirstName { get; set; }
        public string? LastNamme { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Int64? Qty { get; set; }
        public Int64? Amount { get; set; }
    }
}


