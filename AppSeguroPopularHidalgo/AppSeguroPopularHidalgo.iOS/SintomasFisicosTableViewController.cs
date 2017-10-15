using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomasFisicosTableViewController : UITableViewController
    {

        public SintomasFisicosTableViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewWillAppear(bool animated)
        {
            iOSConnection iOSConnection = new iOSConnection();
            var connection = iOSConnection.DBiOSConnection();
            DBConnection dbConnection = new DBConnection(connection);

            FullProperties property = new FullProperties();

            List<SintomasFisicos> list = dbConnection.GetAllSintomasFisicos(property.IdSintoma);

            SintomasFisicosTableView.Source = new SintomasFisicosTableSource(list);

            SintomasFisicosTableView.RowHeight = UITableView.AutomaticDimension;
            SintomasFisicosTableView.EstimatedRowHeight = 40f;

            SintomasFisicosTableView.ReloadData();
        }
    }
}