using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using AppSeguroPopularHidalgo.Model;
using System.Linq;

namespace AppSeguroPopularHidalgo.iOS
{
    public class CentroTableSource : UITableViewSource
    {
		/// <summary>
		/// The cell identifier.
		/// </summary>
        protected string cellIdentifier = "detalleCentro";
        Dictionary<string, List<string>> indexedTableItems;
        string[] keys;
		/// <summary>
		/// Inicializa datos para mostrar información del centro de salud
		/// </summary>
		/// <param name="centro">Centro.</param>
		/// <param name="cellIdentifier">Cell identifier.</param>
        public CentroTableSource(CentroAfiliacion centro, string cellIdentifier = "detalleCentro")
        {
            this.cellIdentifier = cellIdentifier;
            indexedTableItems = new Dictionary<string, List<string>>();
            indexedTableItems.Add("Información general", new List<string> { "Nombre: " + centro.Nombre });
            indexedTableItems["Información general"].Add("Dirección: " + centro.Direccion);
            indexedTableItems["Información general"].Add("Teléfono: " + centro.Telefono);
            indexedTableItems["Información general"].Add("Responsable: " + centro.Responsable);
            indexedTableItems["Información general"].Add("Teléfono responsable: " + centro.TelefonoResponsable);
            indexedTableItems["Información general"].Add("Horario: " + centro.Horario);
            indexedTableItems["Información general"].Add("Correo: " + centro.Correo);

            keys = indexedTableItems.Keys.ToArray();
        }

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>Regresa los datos obtenidos a una tabla para su visulisación.</returns>
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

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return indexedTableItems[keys[section]].Count;
        }
		/// <summary>
		/// Tamaño de la tabla
		/// </summary>
		/// <returns>regresa un tamaño de tabla de acuerdo a los datos obtenidos</returns>
		/// <param name="tableView">Table view.</param>
        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
    }
}
