using ExpressData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before running this program");
            Console.WriteLine("1. Create a table named tblUsers");
            Console.WriteLine("2. Create 3 columns Id, Fname and Lname");
            Console.WriteLine("3. Set the connection string to database server inside Main()");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.ReadLine();

            //Prerequesties
            var _connectionString = "";


            #region QUERIES
            //Plain Query - Gives first result
            var sql1 = $"SELECT * FROM tblUsers WHERE Id=1";
            var result = SqlHelper.Query<User>(sql1, _connectionString).FirstOrDefault();

            //Safe Query - Parameterised query
            var sql2 = $"SELECT * FROM tblUsers WHERE Id=@id AND Fname=@fname";
            result = SqlHelper.QuerySafe<User>(sql2, new
            {
                id = 1,
                fname = "Sangeeth"
            }, _connectionString);
            #endregion

            #region INSERT AND UPDATES
            var record = new User
            {
                Id = 1,
                FName = "Sangeeth",
                LName = "Nandakumar"
            };

            //Insert
            var primaryKey = SqlHelper.Insert<User>(record, _connectionString);

            //Update
            var isUpdated = SqlHelper.Insert<User>(record, _connectionString);
            #endregion

            #region STORED PROCEDURES
            var procedureName = $"spGetUsers";
            result = SqlHelper.Execute<User>(procedureName, new { id = 1 }, _connectionString).FirstOrDefault();
            #endregion
        }
    }
}
