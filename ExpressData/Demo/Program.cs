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


            //Prerequesties
            var _connectionString = @"Server=DESKTOP-708EN4A\SQLEXPRESS;Database=TIS;Trusted_Connection=True;";

            #region INSERT AND UPDATES
            //Insert
            var record = new tblUser
            {
                Id = 1,
                FName = "Sangeeth",
                LName = "Nandakumar"
            };            
            var primaryKey = SqlHelper.Insert<tblUser>(record, _connectionString);

            //Update
            record = new tblUser
            {
                Id = 1,
                FName = "Navaneeth",
                LName = "Nandakumar"
            };            
            var isUpdated = SqlHelper.Update<tblUser>(record, _connectionString);
            #endregion

            #region QUERIES
            //Plain Query - Gives first result
            var sql1 = $"SELECT * FROM tblUser WHERE Id=1";
            var result = SqlHelper.Query<tblUser>(sql1, _connectionString).FirstOrDefault();

            //Safe Query - Parameterised query
            var sql2 = $"SELECT * FROM tblUser WHERE Id=@id AND Fname=@fname";
            result = SqlHelper.QuerySafe<tblUser>(sql2, new
            {
                id = 1,
                fname = "Navaneeth"
            }, _connectionString);
            #endregion            

            #region STORED PROCEDURES
            var procedureName = $"spGetUsers";
            result = SqlHelper.Execute<tblUser>(procedureName, new { id = 1 }, _connectionString).FirstOrDefault();
            #endregion
        }
    }
}
