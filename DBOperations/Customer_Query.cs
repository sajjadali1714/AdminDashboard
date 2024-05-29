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
    public class Customer_Query
    {
        Utility Utility = null;

        public Int64 GetQtyDetail(String column, String operation, string fromDate, string toDate)
        {
            Utility = new Utility();
            string Sql = $@" Select {operation}({column}) as {column}
                        from VW_SalesDetail 
                        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetDataFromDB<Int64>(Sql, column);

            return result;
        }


        public Int64 GetCustomerTypes(string column, string gender, string fromDate, string toDate)
        {
            Utility = new Utility();
            string sql = $@"SELECT COUNT(*) FROM VW_SalesDetail WHERE {column} = @Gender
            and 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@Gender", gender));
            return result;
        }

        public Int64 GetCustomerCount(string column, string fromDate, string toDate)
        {
            Utility = new Utility();
            string sql = $@"SELECT COUNT(DISTINCT {column}) FROM VW_SalesDetail
            WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetScalarValueFromDB<Int64>(sql);
            return result;
        }

        public Int64 GetSumOfSale(string column, string type, string fromDate, string toDate)
        {
            Utility = new Utility();
            string sql = $@"SELECT SUM({column}) FROM VW_SalesDetail WHERE CustomerTypeName = @CustomerType
            and 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@CustomerType", type));
            return result;
        }

        public Int64 GetTax(String column, String operation, string fromDate, string toDate)
        {
            Utility = new Utility();
            string Sql = $@" Select {operation}({column}) as {column}
                        from VW_SalesDetail 
                        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetDataFromDB<Int64>(Sql, column);

            return result;
        }

        public string GetCustomerNameWithMaxTax(string fromDate, string toDate)
        {
            Utility = new Utility();
            string sql = @$"
        SELECT TOP 1 FirstName
        FROM VW_SalesDetail
        WHERE Tax = (SELECT Max(Tax) FROM VW_SalesDetail) 
        and 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";

            return Utility.GetDataFromDB<string>(sql, "FirstName");
        }


        public string GetCustomerNameWithMinTax(string fromDate, string toDate)
        {
            Utility = new Utility();
            string sql = @$"
        SELECT TOP 1 FirstName
        FROM VW_SalesDetail
        WHERE Tax = (SELECT Min(Tax) FROM VW_SalesDetail)
        and
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";

            return Utility.GetDataFromDB<string>(sql, "FirstName");
        }

        public Int64 GetSumOfTax(string column, string fromDate, string toDate)
        {
            Utility = new Utility();
            string Sql = @$" Select Sum({column}) as {column}
                        from VW_SalesDetail 
                        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' ";
            var result = Utility.GetDataFromDB<Int64>(Sql, column);

            return result;
        }

        public List<CustomerPurchase> GetTop5CustomersByPurchaseDESC(string fromDate, string toDate)
        {
            Utility = new Utility();
            using (var context = new ApplicationDBContext())
            {
                string sql = @$"
            SELECT TOP 5 
                FirstName,
                LastName,
                Email,
                SUM(TotalSalesAmount) AS TotalPrice,
                ProductName,
                ProductCategoryName
            FROM VW_SalesDetail
            WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}'
            GROUP BY FirstName, LastName, Email, ProductName, ProductCategoryName
            ORDER BY SUM(TotalSalesAmount) DESC ";

                return Utility.GetList<CustomerPurchase>(sql, MapToCustomerPurchase);
            }
        }

        public List<CustomerPurchase> GetTop5CustomersByPurchaseASC(string fromDate, string toDate)
        {
            Utility = new Utility();
            using (var context = new ApplicationDBContext())
            {
                string sql = @$"
            SELECT TOP 5 
                FirstName,
                LastName,
                Email,
                SUM(TotalSalesAmount) AS TotalPrice,
                ProductName,
                ProductCategoryName
            FROM VW_SalesDetail
            where  OrderDate BETWEEN '{fromDate}' AND '{toDate}'
            GROUP BY FirstName, LastName, Email, ProductName, ProductCategoryName
            ORDER BY SUM(TotalSalesAmount) ASC";

                return Utility.GetList<CustomerPurchase>(sql, MapToCustomerPurchase);
            }
        }

        private CustomerPurchase MapToCustomerPurchase(SqlDataReader reader)
        {
            return new CustomerPurchase
            {
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                price = reader["TotalPrice"] != DBNull.Value ? Convert.ToInt64(reader["TotalPrice"]) : (long?)null,
                ProductName = reader["ProductName"].ToString(),
                ProductCategoryName = reader["ProductCategoryName"].ToString()
            };
        }


        public List<CustomerDetails> GetCustomersDetails(string fromDate, string toDate)
        {
            Utility = new Utility();
            using (var context = new ApplicationDBContext())
            {
                string sql = @$"
            SELECT
                FirstName,
                CustomerTypeName,
                Phone,
                Gender,
                SUM(Quantity) AS TotalQuantityPurchased,
                MAX(Rating) AS TopRating
            FROM VW_SalesDetail
             WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            GROUP BY FirstName, CustomerTypeName, Phone, Gender
            ORDER BY SUM(TotalSalesAmount)";

                return Utility.GetList<CustomerDetails>(sql, MapToCustomerDetails);
            }
        }

        private CustomerDetails MapToCustomerDetails(SqlDataReader reader)
        {
            return new CustomerDetails
            {
                FirstName = reader["FirstName"].ToString(),
                CustomerTypeName = reader["CustomerTypeName"].ToString(),
                Phone = reader["Phone"].ToString(),
                Gender = reader["Gender"].ToString(),
                TotalQuantityPurchased = Convert.ToInt64(reader["TotalQuantityPurchased"]),
                TopRating = Convert.ToDouble(reader["TopRating"])
            };
        }

        public string[] GetMonthName(String column,string fromDate, string toDate)
        {
            Utility = new Utility();
            string Sql = $@" SELECT 
             {column} as {column} 
         FROM 
             VW_SalesDetail s
         WHERE 
             OrderDate BETWEEN '{fromDate}' AND '{toDate}'
         GROUP BY 
             LEFT(DATENAME(month, s.OrderDate), 3), 
             MONTH(s.OrderDate), 
             order_year,MonthName";
            var result = Utility.GetDataFromDB<string[]>(Sql, column);
            return result;
        }


        public (decimal[] MaleSales, decimal[] FemaleSales) GetFiveMonthSalesByGender(string column, string fromDate, string toDate)
        {
            Utility = new Utility();
            string maleSql = $@"
        SELECT 
            SUM({column}) AS {column} 
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}' 
            AND Gender = 'Male'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year ";

            string femaleSql = @$"
        SELECT 
            SUM({column}) AS {column}
        FROM 
            VW_SalesDetail s
        WHERE 
            OrderDate BETWEEN '{fromDate}' AND '{toDate}'
            AND Gender = 'Female'
        GROUP BY 
            LEFT(DATENAME(month, s.OrderDate), 3), 
            MONTH(s.OrderDate), 
            order_year ";
        
            var maleSales = Utility.GetDataFromDB<decimal[]>(maleSql, column);
            var femaleSales = Utility.GetDataFromDB<decimal[]>(femaleSql, column);
            return (maleSales, femaleSales);
        }

    }
}
