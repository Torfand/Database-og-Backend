using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueries().Wait();
        }

         static async Task TestQueries()
        {

            var connectionSTR = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Getit;Integrated Security=True;";
            var connection = new SqlConnection(connectionSTR);

            int rowsDeleted = await connection.ExecuteAsync(deleteAll);

            






            //CREATE TABLE[dbo].[Person]
            //    (

            //    [Id][int] IDENTITY(1,1) NOT NULL,

            //[FirstName] [nvarchar]
            //(max) NULL,

            //[LastName] [nvarchar]
            //(max) NULL,

            //[BirthYear] [int] NULL
            //    ) 
        }
    }
}
