using AppSeguroPopularHidalgo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Foundation;

namespace AppSeguroPopularHidalgo.iOS
{
    public class SintomasFisicosTableSource : UITableViewSource
    {

        List<SintomasFisicos> TableItems;
        string CellIdentifier = "Sintoma";

        public SintomasFisicosTableSource(List<SintomasFisicos> items)
        {
            TableItems = items;
        }



        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return TableItems.Count;
        }
        

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("sintomaFisico") as SintomaFisicoTableViewCell;

            cell.Descripcion = TableItems[indexPath.Row].Descripcion;
            cell.Intensidad = TableItems[indexPath.Row].Intensidad;
            cell.Fecha = TableItems[indexPath.Row].Fecha;

            //cell.TextLabel.TextColor = UIColor.White;
            return cell;
        }
    }
}
