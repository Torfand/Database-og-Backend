using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using NyhetsBrev.Core.Domain_Model;
using NyhetsBrev.Core.Domain_Services;

namespace NyhetsBrev.Infrastructure.DataAcsess
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
            const string insert = "INSERT INTO Registrations (Email, Code) VALUES (@Email, @Code)";
            var DBSubscription = MapToDatabase(subscription);
            var rowsAffected = await conn.ExecuteAsync(insert, DBSubscription);
            return rowsAffected == 1;

        }

   

        public async Task<Subscription> ReadByEmail(string Email)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string read = "SELECT Email, Code WHERE Email = @Email";
            var result = await conn.QueryAsync<>()

        }

        public async Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
        private Subscription MapToDatabase(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
