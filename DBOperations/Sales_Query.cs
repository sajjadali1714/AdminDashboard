using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AdminDashboard.Models;
using AdminDashboard.Models.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.DBOperations
{
    public class Sales_Query
    {
        Utility Utility = null;

        public Int64 GetTotalSalesForCategory(string category)
        {
            Utility = new Utility();
            string sql = @"SELECT SUM(TotalSalesAmount) FROM VW_SalesDetail WHERE ProductCategoryName = @ProductCategoryName";

           var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@ProductCategoryName", category));

            return result;
        }

         public Int64 GetTotalSales()
        {
            Utility = new Utility();
            string sql = @"SELECT SUM(TotalSalesAmount) FROM VW_SalesDetail";

            var result = Utility.GetScalarValueFromDB<Int64>(sql);

            return result;
        }

      public Int64 GetTotalSalesForYear(int year)
{
    Utility = new Utility();
    string sql = @"SELECT SUM(TotalSalesAmount) FROM VW_SalesDetail WHERE YEAR(order_year) = @Year";

    var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@Year", year));

    return result;
}

        public Int64 GetTotalSalesForCustomer(string customerType)
        {
            Utility = new Utility();
            string sql = @"SELECT SUM(Tax) FROM VW_SalesDetail WHERE CustomerTypeName = @CustomerTypeName";

           var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@CustomerTypeName", customerType));

            return result;
        }

           public (decimal[] NormalSales, decimal[] MemberSales) GetFiveMonthSalesByType(string column, string fromDate, string toDate, int year)
        {
            Utility = new Utility();
            string normalSql = $@"
        SELECT 
            SUM({column}) AS TotalSalesAmount 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND order_year = {year} 
            AND CustomerTypeName = 'Normal'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year";

            string memberSql = $@"
        SELECT 
            SUM({column}) AS TotalSalesAmount 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND order_year = {year} 
            AND CustomerTypeName = 'Member'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year";

            var normalSales = Utility.GetDataFromDB<decimal[]>(normalSql, column);
            var memberSales = Utility.GetDataFromDB<decimal[]>(memberSql, column);

            return (normalSales, memberSales);
        }


         public (decimal[] Texas, decimal[] Florida, decimal[] California) GetFiveMonthSalesByBranch(string column, string fromDate, string toDate, int year)
        {
            Utility = new Utility();
            string texasSql = $@"
        SELECT 
            SUM({column}) AS TotalSalesAmount 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND order_year = {year} 
            AND BranchName = 'Texas'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year";

            string floridaSql = $@"
        SELECT 
            SUM({column}) AS TotalSalesAmount 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND order_year = {year} 
            AND BranchName = 'Florida'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year";

             string californiaSql = $@"
        SELECT 
            SUM({column}) AS TotalSalesAmount 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND order_year = {year} 
            AND BranchName = 'California'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year";

            var texasSales = Utility.GetDataFromDB<decimal[]>(texasSql, column);
            var floridaSales = Utility.GetDataFromDB<decimal[]>(floridaSql, column);
            var californiaSales = Utility.GetDataFromDB<decimal[]>(californiaSql, column);

            return (texasSales, floridaSales,californiaSales);
        }


    }
}
