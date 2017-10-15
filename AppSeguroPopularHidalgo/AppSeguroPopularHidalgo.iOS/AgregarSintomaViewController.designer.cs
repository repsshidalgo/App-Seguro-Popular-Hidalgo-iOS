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
    [Register ("AgregarSintomaViewController")]
    partial class AgregarSintomaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton agregarSintomaButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nombreSintomaTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (agregarSintomaButton != null) {
                agregarSintomaButton.Dispose ();
                agregarSintomaButton = null;
            }

            if (nombreSintomaTextField != null) {
                nombreSintomaTextField.Dispose ();
                nombreSintomaTextField = null;
            }
        }
    }
}