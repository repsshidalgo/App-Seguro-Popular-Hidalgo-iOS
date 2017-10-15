using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
	/// <summary>
	/// Datos del afiliado Afiliado.
	/// </summary>
    public class Afiliado
    {
        public string fechaVencimiento { get; set; }
        public string status { get; set; }
        public string folio { get; set; }
        public string consecutivo { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string CURP { get; set; }
        public string dependenciaSalud { get; set; }
        public string CLUES { get; set; }
        public string sexo { get; set; }
        public string edad { get; set; }
    }
}
