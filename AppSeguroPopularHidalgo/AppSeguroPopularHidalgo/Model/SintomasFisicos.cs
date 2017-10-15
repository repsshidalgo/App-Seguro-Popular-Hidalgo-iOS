using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
    public class SintomasFisicos
    {
        [SQLite.PrimaryKeyAttribute, SQLite.AutoIncrement]
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Fecha { get; set; }
        public int ídSintoma { get; set; }
    }
}
