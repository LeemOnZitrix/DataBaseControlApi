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
        public async Task<IEnumerable<Ksiazka>> Getksiazka()
        {
            Operations connection = new Operations();
            IEnumerable<Ksiazka> ksiazkas = await connection.ShowKsiazkas();
            return ksiazkas;
        }
        public async Task Addksiazka(Ksiazka ksiazka)
        {
            Operations connection = new Operations();
            await connection.AddKsiazkas(ksiazka);
        }
        public async Task Deleteksiazka(int id)
        {
            Operations connection = new Operations();
            await connection.DeleteKsiazkas(id);
        }

    }
}
