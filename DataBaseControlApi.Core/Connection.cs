using DataBaseControlApi.Infrastructure;
using DataBaseControlApi.Infrastructure.Models;

namespace DataBaseControlApi.Core
{
    public class Connection
    {
        private readonly Operations _operations;

        public Connection(Operations operations)
        {
            _operations = operations;
        }
        public async Task<IEnumerable<Book>> GetBook()
        {
            IEnumerable<Book> ksiazkas = await _operations.ShowBooks();
            return ksiazkas;
        }
        public async Task<Book?> FindBook(int id)
        {
            return await _operations.FindBooks(id);
        }
        public async Task AddBook(Book ksiazka)
        {
            await _operations.AddBooks(ksiazka);
        }
        public async Task RemoveBook(int id)
        {
            await _operations.RemoveBooks(id);
        }

    }
}
