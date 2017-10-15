using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomasViewController : UIViewController
    {
        public SintomasViewController (IntPtr handle) : base (handle)
        {
        }

        //public override void ViewWillAppear(bool animated)
        //{
        //    iOSConnection iOSConnection = new iOSConnection();
        //    var connection = iOSConnection.DBiOSConnection();
        //    DBConnection dbConnection = new DBConnection(connection);

        //    List<Sintomas> list = dbConnection.GetAllSintomas();

        //    sintomasTableView.Source = new SintomasTableSource(list);

        //    sintomasTableView.ReloadData();
        //}
    }
}