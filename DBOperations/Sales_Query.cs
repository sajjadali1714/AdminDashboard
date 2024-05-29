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


    }
}
