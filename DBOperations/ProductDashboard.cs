using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.DBOperations
{
    public class ProductDashboard
    {
        Utility Utility = null;
        
        public decimal[] GetProductDetail(String column, string operation,string fromDate,string toDate,string whereClause,string groupBy)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE({operation}({column}), 0) as {column}
                        from VW_SalesDetail 
                        where OrderDate  between  '{fromDate}' and  '{toDate}'
                        {whereClause}
                        group by {groupBy}";
            var result = Utility.GetDataFromDB<decimal[]>(Sql, column);
            return result;
        }

        public int[] GetProductOrderDetail(String column, string operation,string fromDate,string toDate,string groupBy)
        {
            Utility = new Utility();
            string Sql = $@" Select COALESCE({operation}({column}), 0) as {column}
                        from VW_SalesDetail 
                        where OrderDate  between  '{fromDate}' and  '{toDate}'
                        group by {groupBy}";
            var result = Utility.GetDataFromDB<int[]>(Sql, column);
            return result;
        }
    }
}