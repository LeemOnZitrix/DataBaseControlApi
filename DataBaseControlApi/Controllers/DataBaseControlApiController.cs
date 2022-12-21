using Microsoft.AspNetCore.Mvc;
using DataBaseControlApi.Infrastructure.Models;
using DataBaseControlApi.Core;

namespace DataBaseControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseControlApiController : ControllerBase
    {
        private readonly Connection _connection;
        public DataBaseControlApiController(Connection connection)
        {
            _connection = connection;
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _connection.GetBook();
        }
        [HttpGet("Find")]
        public async Task<Book?> Find(int id)
        {
            return await _connection.FindBook(id);
        }
        [HttpPost("Add")]
        public async Task Add([FromBody] Book model)
        {
            await _connection.AddBook(model);
        }
        [HttpDelete("Del")]
        public async Task Delete([FromQuery] int id)
        {
            await _connection.RemoveBook(id);
        }
    }
}