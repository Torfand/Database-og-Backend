using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NewsLetter.Core._2_Domain_Services;
using NewsLetter.Core._3_Domain_Model;




namespace NewsLetter.Infrastructure.DataAcsess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public async Task<bool> Create(Subscription subscription)
        {
            const string 
                connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            await using var connection = new SqlConnection(connStr);
            const string insert = "INSERT INTO Registrations (Name, Email, Code, Status) VALUES (@Name, @Email, @Code, 'NOT Verified')";
            var dbModel = MapToDB(subscription);
            var rowsAffected = await connection.ExecuteAsync(insert, dbModel);
            return rowsAffected == 1;

        }


        public async Task<Subscription> ReadByEmail(string email)
        {
            const string
                connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string select = "SELECT Name, Email, Code FROM Registrations WHERE Email = @Email";
            var result = await connection.QueryAsync<Subscription>(select, new {Email = email});
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);
        }

   


        public async Task<bool> Update(Subscription subscription)
        {
            const string
                connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewsLetter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string insert = "UPDATE Registrations SET Status='Verified', Email=@Email WHERE Code=@Code";
            var DbModel = MapToDB(subscription);
            var rowsAffected = await connection.ExecuteAsync(insert, DbModel);
            return rowsAffected == 1;


        }
        private Subscription MapToDomain(Subscription subscription)
        {
            return new Subscription(subscription.Name, subscription.Email, subscription.Code);
        }

        private Subscription MapToDB(Subscription subscription)
        {
            return new Subscription(subscription.Name, subscription.Email, subscription.Code);
        }
    }
}
