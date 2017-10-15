using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using AppSeguroPopularHidalgo.Model;
using System.Linq;

namespace AppSeguroPopularHidalgo.iOS
{
    public class TableSource : UITableViewSource
    {
		/// <summary>
		/// Variable detalle de unidad
		/// </summary>
        protected string cellIdentifier = "detalleUnidad";
		/// <summary>
		/// Diccionario del contenido del detalle de unidad
		/// </summary>
        Dictionary<string, List<string>> indexedTableItems;
        string[] keys;
		/// <summary>
		/// Se inicializa una istancia hacia la tabla de unidada de detalle
		/// </summary>
		/// <param name="unidad">Unidad.</param>
		/// <param name="cellIdentifier">Cell identifier.</param>
        public TableSource(UnidadSalud unidad, string cellIdentifier = "detalleUnidad")
        {
            this.cellIdentifier = cellIdentifier;
            indexedTableItems = new Dictionary<string, List<string>>();
            indexedTableItems.Add("Información", new List<string> { "Nombre: " + unidad.Nombre });
            indexedTableItems["Información"].Add("Clues: " + unidad.Clues);
            indexedTableItems["Información"].Add("Clave: " + unidad.Clave);
            indexedTableItems["Información"].Add("Municipio: " + unidad.Municipio);
            indexedTableItems["Información"].Add("Localidad: " + unidad.Localidad);
            indexedTableItems["Información"].Add("Tipo de establecimiento: " + unidad.TipoEstablecimiento);
            indexedTableItems["Información"].Add("Dirección: " + unidad.Direccion);
            indexedTableItems["Información"].Add("Código postal: " + unidad.CodigoPostal);
            indexedTableItems["Información"].Add("Teléfono: " + unidad.Telefono);
            indexedTableItems["Información"].Add("Horario(Matutino, Vespertino, Nocturno, Jornada acumulada, Todos los anteriores): " + unidad.Horario);
            indexedTableItems.Add("Gestor Médico", new List<string> { "Gestor: " + unidad.Gestor });
            indexedTableItems["Gestor Médico"].Add("Unidad de adscripción: " + unidad.Unidad);
            indexedTableItems.Add("Servicios de salud", new List<string> { "Acciones  de Salud Pública: " + unidad.AccionesSaludPublica });
            indexedTableItems["Servicios de salud"].Add("Consulta de Medicina General / Familiar: " + unidad.ConsultaMedicinaGeneralFamiliar);
            indexedTableItems["Servicios de salud"].Add("Odontología: " + unidad.Odontologia);
            indexedTableItems["Servicios de salud"].Add("Anestesiología: " + unidad.Anestesiologia);
            indexedTableItems["Servicios de salud"].Add("Cirugía: " + unidad.Cirugia);
            indexedTableItems["Servicios de salud"].Add("Ginecología y Obstetricia: " + unidad.GinecologiaObstetricia);
            indexedTableItems["Servicios de salud"].Add("Medicina Interna: " + unidad.MedicinaInterna);
            indexedTableItems["Servicios de salud"].Add("Pediatría: " + unidad.Pediatra);
            indexedTableItems["Servicios de salud"].Add("Trauma y Ortopedia" + unidad.TraumaOrtopedia);
            indexedTableItems["Servicios de salud"].Add("Atenciones en Urgencias: " + unidad.AtencionUrgencias);
            indexedTableItems["Servicios de salud"].Add("Radiología: " + unidad.Radiologia);
            indexedTableItems["Servicios de salud"].Add("Laboratorio Clínico: " + unidad.LaboratorioClinico);
            indexedTableItems["Servicios de salud"].Add("Banco de sangre: " + unidad.BancoSangre);


            keys = indexedTableItems.Keys.ToArray();
        }
		/// <summary>
		/// Obtiene los detalles de la unidad de salud
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            DetallesViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as DetallesViewCell;
            string item = indexedTableItems[keys[indexPath.Section]][indexPath.Row];

            //---- if there are no cells to reuse, create a new one


            //---- set the item text
            cell.Valor = item.ToString();

            //---- if the item has a valid image, and it's not the contact style (doesn't support images)


            //---- set the accessory

            return cell;
        }
		/// <summary>
		/// Retorna los detalles del cento de salud seleccionado
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return indexedTableItems[keys[section]].Count;
        }

		/// <summary>
		/// Cantidad de secciones que contiene el detalle
		/// </summary>
		/// <returns>The of sections.</returns>
		/// <param name="tableView">Table view.</param>
        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }
		/// <summary>
		/// Encabezados para dar formato al detalle
		/// </summary>
		/// <returns>The for header.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
    }
}
