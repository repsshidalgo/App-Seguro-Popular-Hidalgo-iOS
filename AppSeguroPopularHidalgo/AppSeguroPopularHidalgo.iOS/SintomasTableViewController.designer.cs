// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    [Register ("SintomasTableViewController")]
    partial class SintomasTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView sintomasTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (sintomasTableView != null) {
                sintomasTableView.Dispose ();
                sintomasTableView = null;
            }
        }
    }
}