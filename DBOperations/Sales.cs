using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AdminDashboard.Models;
using AdminDashboard.Models.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AdminDashboard.DBOperations
{
    public class Sales
    {
        Utility Utility = null;
        
        public Int64 GetSalesDetail(String column, string operation)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE({operation}({column}), 0) as {column}
                        from VW_SalesDetail ";
            var result = Utility.GetDataFromDB<int>(Sql, column);
            return result;
        }

        public Int64 GetMonthSalesDetail(String column, string operation, string month_name, int year)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE({operation}({column}), 0) as {column}
                        from VW_SalesDetail 
                        where month_name in ({month_name})
                        and order_year = {year}";
            var result = Utility.GetDataFromDB<int>(Sql, column);
            return result;
        }

        public Int64 GetDateWiseSalesDetail(String column, string operation, string fromDate, string toDate)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE({operation}({column}), 0) as {column}
                        from VW_SalesDetail 
                        where OrderDate  between  {fromDate} and  {toDate}";
            var result = Utility.GetDataFromDB<int>(Sql, column);
            return result;
        }

        public decimal[] GetFiveMonthSales(String column,string fromDate, string toDate,int year)
        {
            Utility = new Utility();
            string Sql = $@"SELECT SUM({column}) AS TotalSalesAmount 
                            FROM VW_SalesDetail s
                                where OrderDate  between  {fromDate} and  {toDate}
                                and order_year = {year}
                            GROUP BY LEFT(DATENAME(month, s.OrderDate), 3), MONTH(s.OrderDate),order_year                         
                            ";
            var result = Utility.GetDataFromDB<decimal[]>(Sql, column);
            return result;
        }

        public decimal[] GetBranchSalesSummary(String column)
        {
            Utility = new Utility();
            string Sql = $@"SELECT SUM({column}) AS {column} 
                            FROM VW_SalesDetail s
                           GROUP BY BranchName             
                            ";
            var result = Utility.GetDataFromDB<decimal[]>(Sql, column);
            return result;
        }

        public decimal[] GetYearMonthSales(String column,string fromDate, string toDate,int year)
        {
            Utility = new Utility();
            string Sql = $@"SELECT SUM({column}) AS TotalSalesAmount 
                            FROM VW_SalesDetail s
                                where OrderDate  between  {fromDate} and  {toDate}
                                and order_year = {year}
                            GROUP BY LEFT(DATENAME(month, s.OrderDate), 3), MONTH(s.OrderDate),order_year                         
                            ";
            var result = Utility.GetDataFromDB<decimal[]>(Sql, column);
            return result;
        }



        public List<BranchSales> GetBranchSalesDetail(string month_name, int year)
        {
            using (var context = new ApplicationDBContext())
            {
                string sql = $@"select CONCAT(month_name,'-',order_year) as orderMonth,
                                BranchName,
                                COALESCE(sum(TotalSalesAmount), 0) as totalSale,
                                COALESCE(max(TotalSalesAmount), 0) as maxSale,
                                COALESCE(min(TotalSalesAmount), 0) as minSale,
                                COALESCE(AVG(TotalSalesAmount), 0) as avgSale
                        from VW_SalesDetail
                        where order_year = {year}
                        and month_name = {month_name}
                        group by CONCAT(month_name,'-',order_year), BranchName";
                List<BranchSales> result = Utility.GetList<BranchSales>(sql, MapToBranchSales);
                return result;
            }
        }

        private BranchSales MapToBranchSales(SqlDataReader reader)
        {
            return new BranchSales
            {
                orderMonth = reader["orderMonth"].ToString(),
                BranchName = reader["BranchName"].ToString(),
                totalSale = Convert.ToInt64(reader["totalSale"]),
                maxSale = Convert.ToInt64(reader["maxSale"]),
                minSale = Convert.ToInt64(reader["minSale"]),
                avgSale = Convert.ToInt64(reader["avgSale"])
            };
        }
    }
}