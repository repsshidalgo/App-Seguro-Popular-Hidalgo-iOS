using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomasEmocionalesTableViewController : UITableViewController
    {
        public SintomasEmocionalesTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            iOSConnection iOSConnection = new iOSConnection();
            var connection = iOSConnection.DBiOSConnection();
            DBConnection dbConnection = new DBConnection(connection);

            FullProperties property = new FullProperties();

            List<SintomasEmocionales> list = dbConnection.GetAllSintomasEmocionales(property.IdSintoma);

            SintomasEmocionalesTableView.Source = new SintomasEmocionalesTableSource(list);

            SintomasEmocionalesTableView.RowHeight = UITableView.AutomaticDimension;
            SintomasEmocionalesTableView.EstimatedRowHeight = 40f;

            SintomasEmocionalesTableView.ReloadData();
        }
    }
}