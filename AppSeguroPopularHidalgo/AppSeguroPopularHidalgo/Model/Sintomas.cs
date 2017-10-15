using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
    public class Sintomas
    {
        [SQLite.PrimaryKeyAttribute,SQLite.AutoIncrement]
        public int id { get; set; }
        public string Nombre { get; set; }
    }
}
