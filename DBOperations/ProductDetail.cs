using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboard.Data;
using AdminDashboard.Models.ViewModel;
using Microsoft.Data.SqlClient;

namespace AdminDashboard.DBOperations
{
    public class ProductDetail
    {
        Utility Utility = null;
        public List<ProductCategorySale> GetProductCategorySalesDetail(string column,string fromDate, string toDate)
        {
            Utility = new Utility();
            using (var context = new ApplicationDBContext())
            {
                string sql = $@"select {column} as name,
                                COALESCE(sum(TotalSalesAmount), 0) as totalSale,
                                COALESCE(max(TotalSalesAmount), 0) as maxSale,
                                COALESCE(min(TotalSalesAmount), 0) as minSale,
                                COALESCE(AVG(TotalSalesAmount), 0) as avgSale
                        from VW_SalesDetail
                        where OrderDate between '{fromDate}' and '{toDate}'                        
                        group by {column} order by {column}";
                List<ProductCategorySale> result = Utility.GetList<ProductCategorySale>(sql, MapToBranchSales);
                return result;
            }
        }

        private ProductCategorySale MapToBranchSales(SqlDataReader reader)
        {
            return new ProductCategorySale
            {                
                ProductCategory = reader["name"].ToString(),
                totalSale = Convert.ToInt64(reader["totalSale"]),
                maxSale = Convert.ToInt64(reader["maxSale"]),
                minSale = Convert.ToInt64(reader["minSale"]),
                avgSale = Convert.ToInt64(reader["avgSale"])
            };
        }
    }
}