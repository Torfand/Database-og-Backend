using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NumberPuzzleWeb.Core.Domain_Model;
using NumberPuzzleWeb.Core.DomainServices;
using DBGameModel = NumberPuzzleWeb.I.DataAcsess.Model.GameModel;

namespace NumberPuzzleWeb.I.DataAcsess.Repository
{
    public class GameModelRepository : IGameRepository
    {
        private string _connectionstring =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NumberPuzzle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public async Task<bool> Create(GameModel gameModel)
        {
            await using var conn = new SqlConnection(_connectionstring);
            const string insert = "INSERT INTO Game (Id, Numbers, PlayCount) VALUES (@Id, @Numbers, @PlayCount)";
            var dbGameModel = MapToDatabase(gameModel);
            var rowsAffected = await conn.ExecuteAsync(insert, dbGameModel);
            return rowsAffected == 1;


        }
        public async Task<GameModel> Read(Guid id)
        {
            await using var conn = new SqlConnection(_connectionstring);
            const string select = "SELECT Id, Numbers, PlayCount FROM Game WHERE Id = @Id";
            var result = await conn.QueryAsync<DBGameModel>(select, new { Id = id });
            var gameModel = result.SingleOrDefault();
            return MapToDomain(gameModel);
        }

        public async Task<bool> Update(GameModel gameModel)
        {
            await using var conn = new SqlConnection(_connectionstring);
            const string insert = "UPDATE Game SET Numbers=@Numbers, PlayCount= @PlayCount WHERE Id=@Id";
            var dbGameModel = MapToDatabase(gameModel);
            var rowsAffected = await conn.ExecuteAsync(insert, dbGameModel);
            return rowsAffected == 1;

        }
        private GameModel MapToDomain(DBGameModel gameModel)
        {
            var numbers = gameModel.Numbers.ToCharArray().Select(c => c - '0').ToArray();
            return new GameModel(gameModel.Id , gameModel.PlayCount, numbers);
        }
        private static DBGameModel MapToDatabase(GameModel gameModel)
        {
           var numbers = new string(gameModel.Numbers).Replace(' ', '0');
           return new DBGameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }
      


    }
}
