using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ExpressData
{
    public static class SqlHelper
    {
        //INSERT
        public static long Insert<T>(T record, string connectionString) where T: class
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Insert(record);
                    sqlConnection.Close();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }            
        }
        //UPDATE
        public static bool Update<T>(T record, string connectionString) where T: class
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Update(record);
                    sqlConnection.Close();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }            
        }
        //RUN PARAMETERISED QUERY
        public static T QuerySafe<T>(string sql, object parameters, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var output = connection.Query<T>(sql, parameters).FirstOrDefault();
                    connection.Close();
                    return output;
                }
            }
            catch(Exception ex)
            {
                throw;
            }            
        }
        //RUN PLAIN QUERY
        public static IEnumerable<T> Query<T>(string sql, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var output = connection.Query<T>(sql);
                    connection.Close();
                    return output;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        //RUN STORED PROCEDURE
        public static IEnumerable<T> Execute<T>(string procedureName, object parameters, string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var output = connection.Query<T>(procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                    return output;
                }
            }
            catch(Exception ex)
            {
                throw;
            }            
        }
    }
}
