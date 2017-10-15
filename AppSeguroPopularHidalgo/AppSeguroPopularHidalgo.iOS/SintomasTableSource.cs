using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using AppSeguroPopularHidalgo.Model;

namespace AppSeguroPopularHidalgo.iOS
{
    public class SintomasTableSource : UITableViewSource
    {
        List<Sintomas> TableItems;
        string CellIdentifier = "Sintoma";

        public SintomasTableSource(List<Sintomas> items)
        {
            TableItems = items;
        }



        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return TableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("Sintoma") as SintomaTableViewCell;

            cell.Nombre = TableItems[indexPath.Row].Nombre;
            //cell.TextLabel.TextColor = UIColor.White;
            return cell;
        }
    }
}
