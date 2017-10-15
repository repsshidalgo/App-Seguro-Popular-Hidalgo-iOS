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
    [Register ("MapaViewController")]
    partial class MapaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem buscarBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView elementoDosImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel elementoDosLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView elementoUnoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel elementoUnoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel estadoPolizaLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem mapaNavigationItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl mapaSegmentedControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView seguroPopularMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem usuarioBarButtonItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (buscarBarButtonItem != null) {
                buscarBarButtonItem.Dispose ();
                buscarBarButtonItem = null;
            }

            if (elementoDosImageView != null) {
                elementoDosImageView.Dispose ();
                elementoDosImageView = null;
            }

            if (elementoDosLabel != null) {
                elementoDosLabel.Dispose ();
                elementoDosLabel = null;
            }

            if (elementoUnoImageView != null) {
                elementoUnoImageView.Dispose ();
                elementoUnoImageView = null;
            }

            if (elementoUnoLabel != null) {
                elementoUnoLabel.Dispose ();
                elementoUnoLabel = null;
            }

            if (estadoPolizaLabel != null) {
                estadoPolizaLabel.Dispose ();
                estadoPolizaLabel = null;
            }

            if (mapaNavigationItem != null) {
                mapaNavigationItem.Dispose ();
                mapaNavigationItem = null;
            }

            if (mapaSegmentedControl != null) {
                mapaSegmentedControl.Dispose ();
                mapaSegmentedControl = null;
            }

            if (seguroPopularMapView != null) {
                seguroPopularMapView.Dispose ();
                seguroPopularMapView = null;
            }

            if (usuarioBarButtonItem != null) {
                usuarioBarButtonItem.Dispose ();
                usuarioBarButtonItem = null;
            }
        }
    }
}