using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AdminDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.DBOperations
{
    public class Sales
    {
        Utility Utility = null;
        public Int64 GetSalesDetail(String column)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE(sum({column}), 0) as {column}
                        from VW_SalesDetail ";
            var result = Utility.GetDataFromDB<int>(Sql, column);
            return result;
        }

        public Int64 GetMonthSalesDetail(String column, string month_name, int year)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE(sum({column}), 0) as {column}
                        from VW_SalesDetail 
                        where month_name in ({month_name})
                        and order_year = {year}";
            var result = Utility.GetDataFromDB<int>(Sql, column);
            return result;
        }
    }

    // public Int64 GetSalesDetail(String column, String Mon, int year)
    // {
    //     using (var context = new ApplicationDBContext())
    //     {
    //         string Sql = $@" Select COALESCE(sum({column}), 0) as Total
    //                 from VW_SalesDetail a
    //                 where a.month_name = {Mon} 
    //                 and a.order_year = {year}";

    //         var result = context.VwSalesDetails
    //             .FromSqlRaw(Sql)
    //             .Select(v => v.TotalSalesAmount)
    //             .FirstOrDefault();
    //         return Convert.ToInt64(result);
    //     }
    // }

    // public Int64 GetSalesDetail(String column, String FromDate, String ToDate)
    // {
    //     using (var context = new ApplicationDBContext())
    //     {
    //         string Sql = $@" Select COALESCE(sum({column}), 0) as Total
    //                 from VW_SalesDetail a
    //                 where a.order_date between {FromDate} and {ToDate}";

    //             var result = context.VwSalesDetails
    //             .FromSqlRaw(Sql)
    //             .Select(v => v.TotalSalesAmount)
    //             .FirstOrDefault();
    //         return Convert.ToInt64(result);


    //     }
    // }










    // public List<VwSalesDetail> GetSalesDetail(){
    //     using (var context = new ApplicationDBContext()){
    //         context.VwSalesDetails.FromSql("");
    //         var result = context.VwSalesDetails.Select(
    //             x => new VwSalesDetail(){
    //                 InvoiceNo = x.InvoiceNo,
    //                 BranchName = x.BranchName,
    //                 CustomerTypeName = x.CustomerTypeName
    //             }
    //         ).ToList();
    //         return result;
    //     }


}
