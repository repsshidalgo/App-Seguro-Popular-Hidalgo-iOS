using AppSeguroPopularHidalgo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Foundation;

namespace AppSeguroPopularHidalgo.iOS
{
    public class SintomasEmocionalesTableSource : UITableViewSource
    {
        List<SintomasEmocionales> TableItems;
        string CellIdentifier = "Sintoma";

        public SintomasEmocionalesTableSource(List<SintomasEmocionales> items)
        {
            TableItems = items;
        }



        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return TableItems.Count;
        }

        

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("sintomaEmocional") as SintomaEmocionalTableViewCell;
            
            cell.Tipo = TableItems[indexPath.Row].Tipo;
            cell.Fecha = TableItems[indexPath.Row].Fecha;
            //cell.TextLabel.TextColor = UIColor.White;
            return cell;
        }
    }
}

