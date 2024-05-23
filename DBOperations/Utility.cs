using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdminDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.DBOperations
{
    public class Utility
    {

        public T GetDataFromDB<T>(string Sql, string column)
        {
            using (var context = new ApplicationDBContext())
            {
                // Dynamically create an expression to select the specified column
                var parameter = Expression.Parameter(typeof(VwSalesDetail));
                var property = Expression.Property(parameter, column);
                var convert = Expression.Convert(property, typeof(object)); // Convert to object
                var selector = Expression.Lambda<Func<VwSalesDetail, object>>(convert, parameter);

                // Execute the SQL query and apply the dynamic column selector
                var result = context.VwSalesDetails
                    .FromSqlRaw(Sql)
                    .Select(selector)
                    .ToArray();

                if (typeof(T) == typeof(int))
                {
                    return (T)(object)Convert.ToInt32(result.FirstOrDefault());
                }
                else if (typeof(T) == typeof(long))
                {
                    return (T)(object)Convert.ToInt64(result.FirstOrDefault());
                }
                else if (typeof(T) == typeof(string))
                {
                    return (T)(object)result.FirstOrDefault()?.ToString();
                }
                else if (typeof(T) == typeof(int[]))
                {
                    return (T)(object)result;
                }
                else if (typeof(T) == typeof(List<int>))
                {
                    return (T)(object)result.ToList();
                }

                throw new ArgumentException("Unsupported data type");
            }
        }
    }
}


// // Example usage
// int intValue = GetSalesDetail<int>("ColumnName");
// long longValue = GetSalesDetail<long>("ColumnName");
// string stringValue = GetSalesDetail<string>("ColumnName");
// // Example for other types like arrays or lists:
// int[] intArrayValue = GetSalesDetail<int[]>("ColumnName");
// List<int> intListValue = GetSalesDetail<List<int>>("ColumnName");