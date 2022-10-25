using Microsoft.AspNetCore.Mvc;
using DataBaseControlApi.Infrastructure.Models;
using DataBaseControlApi.Core;

namespace DataBaseControlApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseControlApiController : ControllerBase
    {       

        [HttpPost("Get")]
        public async Task<IEnumerable<Ksiazka>> Get()
        {
            Connection connection = new Connection();
            return await connection.Getksiazka();
        }
        [HttpPost("Add")]
        public async Task Add([FromBody] Ksiazka model)
        {
            Connection connection = new Connection();
            await connection.Addksiazka(model);
        }
        [HttpDelete("Del")]
        public async Task Delete([FromQuery] int id)
        {
            Connection connection = new Connection();
            await connection.Deleteksiazka(id);
        }
    }
}