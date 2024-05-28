using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdminDashboard.Models;
using Microsoft.Data.SqlClient;
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
                else if (typeof(T) == typeof(decimal[]))
                {
                    var intArray = result.Cast<decimal>().ToArray();
                    return (T)(object)intArray;
                }
                else if (typeof(T) == typeof(List<int>))
                {
                    return (T)(object)result.ToList();
                }

                throw new ArgumentException("Unsupported data type");
            }
        }

        public T GetDataFromDB<T>(string sql, params SqlParameter[] parameters) where T : class, new()
    {
        using (var context = new ApplicationDBContext())
        using (var command = context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = sql;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            context.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    var entity = new T();
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        if (!Equals(result[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(entity, result[prop.Name], null);
                        }
                    }
                    return entity;
                }
                return null;
            }
        }
    }


        public List<T> GetList<T>(string sql, Func<SqlDataReader, T> map) where T : class, new()
    {
        using (var context = new ApplicationDBContext())
        using (var command = context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = sql;
            context.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                var entities = new List<T>();

                while (result.Read())
                {
                    entities.Add(map((SqlDataReader)result));
                }
                return entities;
            }
        }
    }


    public T GetScalarValueFromDB<T>(string sql, params SqlParameter[] parameters)
{
    using (var context = new ApplicationDBContext())
    using (var command = context.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = sql;
        command.Parameters.AddRange(parameters);
        context.Database.OpenConnection();

        var result = command.ExecuteScalar();
        if (result == null || result == DBNull.Value)
            return default;

        return (T)Convert.ChangeType(result, typeof(T));
    }
}




        // public List<T> Getlist<T>(string sql) where T : class, new()
        // {
        //     using (var context = new ApplicationDBContext())
        //     {
        //         var result = context.VwSalesDetails
        //         .FromSqlRaw(sql)
        //         .AsEnumerable()
        //         .Select(row => MapToType<T>(row))
        //         .ToList();

        //         return result;
        //     }
        // }

        // private T MapToType<T>(VwSalesDetail row) where T : class, new()
        // {
        //     // Create an instance of the desired type
        //     var instance = new T();
        //     var properties = typeof(T).GetProperties();

        //     foreach (var property in properties)
        //     {
        //         var value = typeof(VwSalesDetail).GetProperty(property.Name)?.GetValue(row);
        //         property.SetValue(instance, value);
        //     }

        //     return instance;
        // }

    }

    
}



// // Example usage
// int intValue = GetSalesDetail<int>("ColumnName");
// long longValue = GetSalesDetail<long>("ColumnName");
// string stringValue = GetSalesDetail<string>("ColumnName");
// // Example for other types like arrays or lists:
// int[] intArrayValue = GetSalesDetail<int[]>("ColumnName");
// List<int> intListValue = GetSalesDetail<List<int>>("ColumnName");