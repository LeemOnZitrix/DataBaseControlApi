using System;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using DataBaseControlApi.Infrastructure.Models;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Ksiazka>> ShowKsiazkas()
        {

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            var ksiazki = await connection.QueryAsync<Ksiazka>("SELECT * FROM ksiazki");

            return ksiazki;
        }
        public async Task<Ksiazka?> FindKsiazkas(int id)
        {

            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            var ksiazki = await connection.QueryAsync<Ksiazka>("SELECT * FROM ksiazki");

            return ksiazki.FirstOrDefault(x => x.Id_ksiazka == id);
        }
        public async Task AddKsiazkas(Ksiazka ksiazka)
        {
            var parameters = new { Id = ksiazka.Id_ksiazka, Title = ksiazka.Tytul, Year = ksiazka.Rok_Wydania };
            var sqlstring = "INSERT INTO ksiazki (id_ksiazka, tytul, rok_wydania) VALUES (@Id, @Title , @Year)";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            await connection.QueryAsync(sqlstring, parameters);

        }
        public async Task DeleteKsiazkas(int id)
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MainDataBase"));

            await connection.QueryAsync("DELETE FROM ksiazki WHERE id_ksiazka=" + id);

        }

    }
}
