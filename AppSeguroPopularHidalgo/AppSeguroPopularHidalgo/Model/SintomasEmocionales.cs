using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
    public class SintomasEmocionales
    {
        [SQLite.PrimaryKeyAttribute, SQLite.AutoIncrement]
        public int id { get; set; }
        public string Tipo { get; set; }
        public string Fecha { get; set; }
        public int ídSintoma { get; set; }
    }
}
