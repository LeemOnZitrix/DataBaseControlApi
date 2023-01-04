using Microsoft.AspNetCore.Mvc;
using DataBaseControlApi.Infrastructure.Models;
using DataBaseControlApi.Core;

namespace DataBaseControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseControlApiController : ControllerBase
    {
        private readonly UnitOfWork _connection;
        public DataBaseControlApiController(UnitOfWork connection)
        {
            _connection = connection;
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<Book>> ReadBooks()
        {
            return await _connection.ReadBooks();
        }
        [HttpGet("Find")]
        public async Task<Book?> Find(int id)
        {
            return await _connection.GetBook(id);
        }
        [HttpPost("Add")]
        public async Task Add([FromBody] Book model)
        {
            await _connection.AddBook(model);
        }
        [HttpDelete("Del")]
        public async Task Delete([FromQuery] int id)
        {
            await _connection.DeleteBook(id);
        }
        [HttpPut("Put")]
        public async Task UpdateBook([FromBody] Book model)
        {
            await _connection.UpdateBook(model);
        }        
    }
}