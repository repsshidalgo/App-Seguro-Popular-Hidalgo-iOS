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
    [Register ("DetallesCentroViewController")]
    partial class DetallesCentroViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView centroMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView detallesCentroTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem mapCentroActionButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (centroMapView != null) {
                centroMapView.Dispose ();
                centroMapView = null;
            }

            if (detallesCentroTableView != null) {
                detallesCentroTableView.Dispose ();
                detallesCentroTableView = null;
            }

            if (mapCentroActionButton != null) {
                mapCentroActionButton.Dispose ();
                mapCentroActionButton = null;
            }
        }
    }
}