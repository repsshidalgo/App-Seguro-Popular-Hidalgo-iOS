using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
   

    public partial class SintomasTableViewController : UITableViewController
    {

        List<Sintomas> list;

        public SintomasTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            iOSConnection iOSConnection = new iOSConnection();
            var connection = iOSConnection.DBiOSConnection();
            DBConnection dbConnection = new DBConnection(connection);

            list = dbConnection.GetAllSintomas();

            sintomasTableView.Source = new SintomasTableSource(list);
            
            sintomasTableView.RowHeight = UITableView.AutomaticDimension;
            sintomasTableView.EstimatedRowHeight = 40f;

            sintomasTableView.ReloadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "sintomaSegue")
            {
                FullProperties property = new FullProperties();
                var rowPath = TableView.IndexPathForSelectedRow;
                var selectedData = list[rowPath.Row];
                property.IdSintoma = selectedData.id;
            }
        }

        [Action("UnwindToSintomasTableViewController:")]
        public void UnwindToSintomasTableViewController(UIStoryboardSegue segue)
        {
            iOSConnection iOSConnection = new iOSConnection();
            var connection = iOSConnection.DBiOSConnection();
            DBConnection dbConnection = new DBConnection(connection);

            list = dbConnection.GetAllSintomas();

            sintomasTableView.Source = new SintomasTableSource(list);
            

            sintomasTableView.ReloadData();
        }
    }
}