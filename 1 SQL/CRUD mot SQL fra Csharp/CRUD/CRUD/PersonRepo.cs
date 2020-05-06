using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CRUD
{
    class PersonRepo
    {
        private readonly SqlConnection _connection;


        public PersonRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> Create(Person person)
        {
            var sql = @"INSERT INTO Person(FirstName, LastName, BirthYear)
                        VALUES (@FirstName, @LastName, @BirthYear)";
            return await _connection.ExecuteAsync(sql, person);
        }

        public async Task<IEnumerable<Person>> Readall()
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear FROM Person";
            return  await _connection.QueryAsync<Person>(sql);
        }
        public async Task<IEnumerable<Person>> ReadOnefromId( int id)
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear FROM Person
                            WHERE Id = @Id";
            return await _connection.QueryAsync<Person>(sql, new {Id = id});

        }
        public async Task<int> Update(Person person)
        {
            var sql = @"UPDATE Person
                        SET LastName = @LastName, FirstName = @FirstName, BirthYear = @BirthYear
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, person);
        }
        public async Task<int> Delete(Person person = null , int? id = null)
        {
            var sql = @"DELETE FROM Person
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, person ?? (object)new {Id = id.Value});
        }


     

    }
}
