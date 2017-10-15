using AppSeguroPopularHidalgo.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppSeguroPopularHidalgo.Storage
{
    public class AfiliadosSeguroPopular
    {
        public async Task<Afiliado> GetDataFromAPi(string poliza, string numeroConsecutivo)
        {
            Afiliado afiliado = new Afiliado();

            using (var client = new HttpClient())
                {
                var result = await client.GetStringAsync(String.Format("http://189.254.11.163:8080/consulta/ServicioWeb.asmx/busqueda?folio={0}&consecutivo={1}", poliza, numeroConsecutivo));


                
                    //ok to process
                    var xml = XDocument.Parse(result.ToString());
                    var Dataset = xml.Descendants("consulta");
                if(!(Dataset.Count() == 0))
                {
                    XElement nombre = Dataset.ElementAt(0);

                    afiliado.folio = nombre.Element("ClaveSP").Value;
                    afiliado.consecutivo = nombre.Element("Consecutivo").Value;
                    afiliado.nombres = nombre.Element("Nombres").Value;
                    afiliado.apellidoPaterno = nombre.Element("ApellidoPaterno").Value;
                    afiliado.apellidoMaterno = nombre.Element("ApellidoMaterno").Value;
                    afiliado.CURP = nombre.Element("CURP").Value;
                    afiliado.dependenciaSalud = nombre.Element("NombreUnidadSalud").Value;
                    afiliado.CLUES = nombre.Element("CLUES").Value;

                    if (nombre.Element("Sexo").Value.Equals("H"))
                        afiliado.sexo = "Hombre";
                    else if (nombre.Element("Sexo").Value.Equals("M"))
                        afiliado.sexo = "Mujer";

                    string[] fechaVencimiento = nombre.Element("FechaFinDerechohabiencia").Value.Split('T');
                    afiliado.fechaVencimiento = fechaVencimiento[0];

                    string[] fechaNacimiento = nombre.Element("FechaNacimiento").Value.Split('T');
                    string[] fechaSegmentadaNacimiento = fechaNacimiento[0].Split('-');
                    DateTime nacimiento = new DateTime(Int32.Parse(fechaSegmentadaNacimiento[0]), Int32.Parse(fechaSegmentadaNacimiento[1]), Int32.Parse(fechaSegmentadaNacimiento[2])); //Fecha de nacimiento
                    int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                    afiliado.edad = edad.ToString();

                    string[] fechaSegmentadaVencimiento = fechaVencimiento[0].Split('-');
                    DateTime vencimiento = new DateTime(Int32.Parse(fechaSegmentadaVencimiento[0]), Int32.Parse(fechaSegmentadaVencimiento[1]), Int32.Parse(fechaSegmentadaVencimiento[2])); //Fecha de nacimiento
                                                                                                                                                                                             //DateTime fechaActual = new DateTime(2017,10,15); //Fecha de nacimiento
                    DateTime fechaActual = DateTime.Now;
                    var n = fechaActual.CompareTo(vencimiento);

                    if (n == -1)
                        afiliado.status = "Activo";
                    else if (n == 1)
                        afiliado.status = "Necesita Reafiliación";
                }
            }

            return afiliado;

        }



    }
}
