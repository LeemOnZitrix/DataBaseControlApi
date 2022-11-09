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
        public async Task<IEnumerable<Ksiazka>> Get()
        {
            return await _connection.Getksiazka();
        }
        [HttpGet("Find")]
        public async Task<Ksiazka?> Find(int id)
        {
            return await _connection.Findksiazka(id);
        }
        [HttpPost("Add")]
        public async Task Add([FromBody] Ksiazka model)
        {
            await _connection.Addksiazka(model);
        }
        [HttpDelete("Del")]
        public async Task Delete([FromQuery] int id)
        {
            await _connection.Deleteksiazka(id);
        }
    }
}