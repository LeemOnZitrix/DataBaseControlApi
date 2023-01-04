using Dapper;
using System.Data.SqlClient;
using System.Data;
using DataBaseControlApi.Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace DataBaseControlApi.Infrastructure
{
    public class BookRepository
    {
        private readonly IDbConnection _connection;
        public BookRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Book>> ReadBooks()
        {                      
            return await _connection.QueryAsync<Book>("SELECT * FROM ksiazki");
        }
        public async Task<Book?> GetBook(int id)
        {
            var ksiazki = await _connection.QueryAsync<Book>("SELECT * FROM ksiazki");

            return ksiazki.FirstOrDefault(x => x.Id_ksiazka == id);
        }
        public async Task AddBook(Book book)
        {
            var parameters = new { Id = book.Id_ksiazka, Title = book.Tytul, Year = book.Rok_Wydania };
            var sqlstring = "INSERT INTO ksiazki (id_ksiazka, tytul, rok_wydania) VALUES (@Id, @Title , @Year)";

            await _connection.QueryAsync(sqlstring, parameters);
        }
        public async Task DeleteBook(int id)
        {
            await _connection.QueryAsync("DELETE FROM ksiazki WHERE id_ksiazka=" + id);
        }       
        public async Task UpdateBook(Book book)
        {
            var parameters = new { Id = book.Id_ksiazka, Title = book.Tytul, Year = book.Rok_Wydania };
            var sqlstring = "UPDATE ksiazki SET tytul = @Title, rok_wydania = @Year WHERE id_ksiazka = @Id";

            await _connection.QueryAsync(sqlstring, parameters);
        }
    }
}
