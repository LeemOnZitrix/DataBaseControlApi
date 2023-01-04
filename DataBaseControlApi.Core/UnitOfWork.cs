using DataBaseControlApi.Infrastructure;
using DataBaseControlApi.Infrastructure.Models;

namespace DataBaseControlApi.Core
{
    public class UnitOfWork
    {
        private readonly BookRepository _operations;

        public UnitOfWork(BookRepository operations)
        {
            _operations = operations;
        }
        public async Task<IEnumerable<Book>> ReadBooks() => await _operations.ReadBooks();
        public async Task<Book?> GetBook(int id) => await _operations.GetBook(id);       
        public async Task AddBook(Book book) => await _operations.AddBook(book);       
        public async Task DeleteBook(int id) => await _operations.DeleteBook(id);
        public async Task UpdateBook(Book book) => await _operations.UpdateBook(book);                     


    }
}
