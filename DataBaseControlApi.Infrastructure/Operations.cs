using System;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using DataBaseControlApi.Infrastructure.Models;
using System.Collections.Generic;

namespace DataBaseControlApi.Infrastructure
{
    public class Operations
    {
        public async Task<IEnumerable<Ksiazka>> ShowKsiazkas()
        {
            using IDbConnection connection = new SqlConnection("server=DESKTOP-VP12MQ7;Trusted_Connection=true;Database=Biblioteka");

            var ksiazki = await connection.QueryAsync<Ksiazka>("SELECT * FROM ksiazki");

            return ksiazki;
        }
        public async Task AddKsiazkas(Ksiazka ksiazka)
        {
            using IDbConnection connection = new SqlConnection("server=DESKTOP-VP12MQ7;Trusted_Connection=true;Database=Biblioteka");

            await connection.QueryAsync("INSERT INTO ksiazki (id_ksiazka, tytul, rok_wydania) VALUES (692137, jak zostalem papiezem, 2137)");

        }
        public async Task DeleteKsiazkas(int id)
        {
            using IDbConnection connection = new SqlConnection("server=DESKTOP-VP12MQ7;Trusted_Connection=true;Database=Biblioteka");

            await connection.QueryAsync("DELETE FROM ksiazki WHERE id_ksiazka=" + id);

        }

    }
}
