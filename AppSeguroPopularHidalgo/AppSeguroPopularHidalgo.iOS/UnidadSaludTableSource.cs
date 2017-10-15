using AppSeguroPopularHidalgo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Foundation;

namespace AppSeguroPopularHidalgo.iOS
{
    public class UnidadSaludTableSource : UITableViewSource
    {
        protected string cellIdentifier = "detalleUnidad";

        Dictionary<string, List<string>> indexedTableItems;
        string[] keys;

        public UnidadSaludTableSource(UnidadSalud unidad)
        {
            indexedTableItems = new Dictionary<string, List<string>>();
            indexedTableItems.Add("Información",new List<string> { unidad.Nombre });
            indexedTableItems["Información"].Add(unidad.Clues);
            indexedTableItems["Información"].Add(unidad.Clave);
            indexedTableItems["Información"].Add(unidad.Municipio);
            indexedTableItems["Información"].Add(unidad.Localidad);
            indexedTableItems["Información"].Add(unidad.TipoEstablecimiento);
            indexedTableItems["Información"].Add(unidad.Direccion);
            indexedTableItems["Información"].Add(unidad.CodigoPostal);
            indexedTableItems["Información"].Add(unidad.Telefono);
            indexedTableItems["Información"].Add(unidad.Horario);
            indexedTableItems.Add("Gestor Médico", new List<string> { unidad.Gestor });
            indexedTableItems["Gestor Médico"].Add(unidad.Unidad);
            indexedTableItems.Add("Servicios de salud", new List<string> { unidad.AccionesSaludPublica });
            indexedTableItems["Servicios de salud"].Add(unidad.ConsultaMedicinaGeneralFamiliar);
            indexedTableItems["Servicios de salud"].Add(unidad.Odontologia);
            indexedTableItems["Servicios de salud"].Add(unidad.Anestesiologia);
            indexedTableItems["Servicios de salud"].Add(unidad.Cirugia);
            indexedTableItems["Servicios de salud"].Add(unidad.GinecologiaObstetricia);
            indexedTableItems["Servicios de salud"].Add(unidad.MedicinaInterna);
            indexedTableItems["Servicios de salud"].Add(unidad.Pediatra);
            indexedTableItems["Servicios de salud"].Add(unidad.TraumaOrtopedia);
            indexedTableItems["Servicios de salud"].Add(unidad.AtencionUrgencias);
            indexedTableItems["Servicios de salud"].Add(unidad.Radiologia);
            indexedTableItems["Servicios de salud"].Add(unidad.LaboratorioClinico);
            indexedTableItems["Servicios de salud"].Add(unidad.BancoSangre);

            
            keys = indexedTableItems.Keys.ToArray();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            string item = indexedTableItems[keys[indexPath.Section]][indexPath.Row];

            //---- if there are no cells to reuse, create a new one


            //---- set the item text
            cell.TextLabel.Text = item.ToString();

            //---- if the item has a valid image, and it's not the contact style (doesn't support images)


            //---- set the accessory

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return indexedTableItems[keys[section]].Count;
        }

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
