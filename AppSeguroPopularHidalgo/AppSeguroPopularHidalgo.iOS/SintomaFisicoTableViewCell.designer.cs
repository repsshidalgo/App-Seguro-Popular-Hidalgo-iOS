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
    [Register ("SintomaFisicoTableViewCell")]
    partial class SintomaFisicoTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descripcionSintomaFisicoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel fechaSintomaFisicoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView intensidadImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel intensidadSintomaFisicoLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descripcionSintomaFisicoLabel != null) {
                descripcionSintomaFisicoLabel.Dispose ();
                descripcionSintomaFisicoLabel = null;
            }

            if (fechaSintomaFisicoLabel != null) {
                fechaSintomaFisicoLabel.Dispose ();
                fechaSintomaFisicoLabel = null;
            }

            if (intensidadImageView != null) {
                intensidadImageView.Dispose ();
                intensidadImageView = null;
            }

            if (intensidadSintomaFisicoLabel != null) {
                intensidadSintomaFisicoLabel.Dispose ();
                intensidadSintomaFisicoLabel = null;
            }
        }
    }
}