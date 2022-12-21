using Dapper;
using System.Data.SqlClient;
using System.Data;
using DataBaseControlApi.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace DataBaseControlApi.Infrastructure
{
    public class Operations
    {
        private readonly IConfiguration _configuration;
        public Operations(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Book>> ShowBooks()
        {

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            var ksiazki = await connection.QueryAsync<Book>("SELECT * FROM ksiazki");

            return ksiazki;
        }
        public async Task<Book?> FindBooks(int id)
        {

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            var ksiazki = await connection.QueryAsync<Book>("SELECT * FROM ksiazki");

            return ksiazki.FirstOrDefault(x => x.Id_ksiazka == id);
        }
        public async Task AddBooks(Book ksiazka)
        {
            var parameters = new { Id = ksiazka.Id_ksiazka, Title = ksiazka.Tytul, Year = ksiazka.Rok_Wydania };
            var sqlstring = "INSERT INTO ksiazki (id_ksiazka, tytul, rok_wydania) VALUES (@Id, @Title , @Year)";

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            await connection.QueryAsync(sqlstring, parameters);

        }
        public async Task RemoveBooks(int id)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            await connection.QueryAsync("DELETE FROM ksiazki WHERE id_ksiazka=" + id);

        }

    }
}
