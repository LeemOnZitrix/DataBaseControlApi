using DataBaseControlApi.Infrastructure;
using DataBaseControlApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseControlApi.Core
{
    public class Connection
    {
        private readonly Operations _operations;

        public Connection(Operations operations)
        {
            _operations = operations;
        }
        public async Task<IEnumerable<Ksiazka>> Getksiazka()
        {
            IEnumerable<Ksiazka> ksiazkas = await _operations.ShowKsiazkas();
            return ksiazkas;
        }
        public async Task<Ksiazka?> Findksiazka(int id)
        {
            return await _operations.FindKsiazkas(id);
        }
        public async Task Addksiazka(Ksiazka ksiazka)
        {
            await _operations.AddKsiazkas(ksiazka);
        }
        public async Task Deleteksiazka(int id)
        {
            await _operations.DeleteKsiazkas(id);
        }

    }
}
