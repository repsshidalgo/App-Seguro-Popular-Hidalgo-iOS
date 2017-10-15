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
    [Register ("DetallesUnidadViewController")]
    partial class DetallesUnidadViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView detallesUnidadTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem mapUnidadActionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView unidadMapView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detallesUnidadTableView != null) {
                detallesUnidadTableView.Dispose ();
                detallesUnidadTableView = null;
            }

            if (mapUnidadActionButton != null) {
                mapUnidadActionButton.Dispose ();
                mapUnidadActionButton = null;
            }

            if (unidadMapView != null) {
                unidadMapView.Dispose ();
                unidadMapView = null;
            }
        }
    }
}