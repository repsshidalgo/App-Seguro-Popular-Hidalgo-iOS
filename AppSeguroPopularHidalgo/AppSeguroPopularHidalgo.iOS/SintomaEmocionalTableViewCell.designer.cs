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
    [Register ("SintomaEmocionalTableViewCell")]
    partial class SintomaEmocionalTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView emocionImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel emocionSintomaEmocionalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel fechaSintomaEmocionalLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (emocionImageView != null) {
                emocionImageView.Dispose ();
                emocionImageView = null;
            }

            if (emocionSintomaEmocionalLabel != null) {
                emocionSintomaEmocionalLabel.Dispose ();
                emocionSintomaEmocionalLabel = null;
            }

            if (fechaSintomaEmocionalLabel != null) {
                fechaSintomaEmocionalLabel.Dispose ();
                fechaSintomaEmocionalLabel = null;
            }
        }
    }
}