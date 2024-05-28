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

        public Int64 GetQtyDetail(String column, String operation)
    {
        Utility = new Utility();
        string Sql = $@" Select {operation}({column}) as {column}
                        from VW_SalesDetail ";
        var result = Utility.GetDataFromDB<Int64>(Sql, column);
        
            return result;
        }


    public Int64 GetCustomerTypes(string column, string gender)
    {
        Utility = new Utility();
        string sql = $@"SELECT COUNT(*) FROM VW_SalesDetail WHERE {column} = @Gender";
        var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@Gender", gender));
        return result;
    }

public Int64 GetCustomerCount(string column)
{
    Utility = new Utility();
    string sql = $@"SELECT COUNT(DISTINCT {column}) FROM VW_SalesDetail";
    var result = Utility.GetScalarValueFromDB<Int64>(sql);
    return result;
}

public Int64 GetSumOfSale(string column, string type)
{
    Utility = new Utility();
    string sql = $@"SELECT SUM({column}) FROM VW_SalesDetail WHERE CustomerTypeName = @CustomerType";
    var result = Utility.GetScalarValueFromDB<Int64>(sql, new SqlParameter("@CustomerType", type));
    return result;
}

    public Int64 GetTax(String column, String operation)
    {
        Utility = new Utility();
        string Sql = $@" Select {operation}({column}) as {column}
                        from VW_SalesDetail ";
        var result = Utility.GetDataFromDB<Int64>(Sql, column);
        
            return result;
    }

    public string GetCustomerNameWithMaxTax()
{
    Utility = new Utility();
    string sql = @"
        SELECT TOP 1 FirstName
        FROM VW_SalesDetail
        WHERE Tax = (SELECT Max(Tax) FROM VW_SalesDetail)";

    return Utility.GetDataFromDB<string>(sql, "FirstName");
}


    public string GetCustomerNameWithMinTax()
{
    Utility = new Utility();
    string sql = @"
        SELECT TOP 1 FirstName
        FROM VW_SalesDetail
        WHERE Tax = (SELECT Min(Tax) FROM VW_SalesDetail)";

    return Utility.GetDataFromDB<string>(sql, "FirstName");
}

public Int64 GetSumOfTax(string column)
{
   Utility = new Utility();
        string Sql = $@" Select Sum({column}) as {column}
                        from VW_SalesDetail ";
        var result = Utility.GetDataFromDB<Int64>(Sql, column);
        
            return result;
}

public List<CustomerPurchase> GetTop5CustomersByPurchase()
{
    using (var context = new ApplicationDBContext())
    {
        string sql = @"
            SELECT TOP 5 
                FirstName,
                LastName,
                Email,
                SUM(TotalSalesAmount) AS TotalPrice,
                ProductName,
                ProductCategoryName
            FROM VW_SalesDetail
            GROUP BY FirstName, LastName, Email, ProductName, ProductCategoryName
            ORDER BY SUM(TotalSalesAmount) DESC";

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


}
}
