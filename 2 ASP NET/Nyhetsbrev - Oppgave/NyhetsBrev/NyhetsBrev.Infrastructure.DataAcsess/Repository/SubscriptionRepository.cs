using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NyhetsBrev.Core.Domain_Model;
using NyhetsBrev.Core.Domain_Services;
using NyhetsBrev.Infrastructure.DataAcsess.Model;
using DBNewsletterModel = NyhetsBrev.Infrastructure.DataAcsess.Model.NewsletterModel;

namespace NyhetsBrev.Infrastructure.DataAcsess.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly string _connectionString;

        public SubscriptionRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }
        public async Task<bool> Create(Subscription subscription)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert = "INSERT INTO Registrations (Id, Name, Email, Code) VALUES (@Id, @Name, @Email, @Code)";
            //var DBSubscription = MapToDatabase(subscription);
            var rowsAffected = await conn.ExecuteAsync(insert);
            return rowsAffected == 1;

        }

   

        public async Task<Subscription> ReadByEmail(string email)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string read = "SELECT Id, Name, Email, Code FROM Registrations WHERE Email=@Email";
            var result = await conn.QueryAsync<DBNewsletterModel>(read, new {Email = email});
            var subModel = result.SingleOrDefault();
            return MapToDomain(subModel);

        }

    

        public async Task<bool> Update(Subscription subscription)
        {
           await using var conn = new SqlConnection(_connectionString);
           const string insert = "UPDATE Registrations SET Name=@Name, Email=@Email WHERE Id=@Id";
           //var DBSubscription = MapToDatabase(subscription);
           var rowsAffected = await conn.ExecuteAsync(insert);
           return rowsAffected == 1;

        }
        private Subscription MapToDomain(NewsletterModel newsletterModel)
        {
            var code = newsletterModel.Code;
            return new Subscription(newsletterModel.Name, newsletterModel.Email, newsletterModel.Code);
        }
        //private static Subscription MapToDatabase(Subscription subscription)
        //{

        //}
    }
}
