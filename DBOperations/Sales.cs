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
        public Int64 GetSalesDetail(String column)
        {
            using (var context = new ApplicationDBContext())
            {
                string Sql = $@" Select COALESCE(sum({column}), 0) as TotalSalesAmount
                        from VW_SalesDetail 
                        where ";
                //Sql = "select COALESCE(sum(" + column + "),0) as TotalSalesAmount from VW_SalesDetail";

                var result = context.VwSalesDetails
                    .FromSqlRaw(Sql)
                    .Select(v => v.TotalSalesAmount)
                    .FirstOrDefault();
                return Convert.ToInt64(result);


                //return result.ToString();
            }
        }

        public Int64 GetSalesDetail(String column, String Mon, int year)
        {
            using (var context = new ApplicationDBContext())
            {
                string Sql = $@" Select COALESCE(sum({column}), 0) as TotalSalesAmount
                        from VW_SalesDetail";
                //Sql = "select COALESCE(sum(" + column + "),0) as TotalSalesAmount from VW_SalesDetail";

                var result = context.VwSalesDetails
                    .FromSqlRaw(Sql)
                    .Select(v => v.TotalSalesAmount)
                    .FirstOrDefault();
                return Convert.ToInt64(result);


                //return result.ToString();
            }
        }

        public Int64 GetSalesDetail(String column, String FromDate, String ToDate)
        {
            using (var context = new ApplicationDBContext())
            {
                string Sql = $@" Select COALESCE(sum({column}), 0) as TotalSalesAmount
                        from VW_SalesDetail";
                //Sql = "select COALESCE(sum(" + column + "),0) as TotalSalesAmount from VW_SalesDetail";

                var result = context.VwSalesDetails
                    .FromSqlRaw(Sql)
                    .Select(v => v.TotalSalesAmount)
                    .FirstOrDefault();
                return Convert.ToInt64(result);


                //return result.ToString();
            }
        }










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
}