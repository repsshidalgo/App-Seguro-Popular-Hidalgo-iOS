using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
    public class FullProperties
    {
        private static string fecha;
        private static int idSintoma;

        public int IdSintoma
        {
            get { return idSintoma; }
            set { idSintoma = value; }
        }


        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
