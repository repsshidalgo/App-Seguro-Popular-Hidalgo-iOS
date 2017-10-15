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
    [Register ("DetallesNotificacionViewController")]
    partial class DetallesNotificacionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descripcionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tituloLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descripcionLabel != null) {
                descripcionLabel.Dispose ();
                descripcionLabel = null;
            }

            if (tituloLabel != null) {
                tituloLabel.Dispose ();
                tituloLabel = null;
            }
        }
    }
}