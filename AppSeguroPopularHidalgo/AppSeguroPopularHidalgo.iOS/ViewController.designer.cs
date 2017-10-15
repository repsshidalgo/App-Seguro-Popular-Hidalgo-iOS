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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton iniciarSesionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField numeroConsecutivoTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField polizaTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iniciarSesionButton != null) {
                iniciarSesionButton.Dispose ();
                iniciarSesionButton = null;
            }

            if (numeroConsecutivoTextField != null) {
                numeroConsecutivoTextField.Dispose ();
                numeroConsecutivoTextField = null;
            }

            if (polizaTextField != null) {
                polizaTextField.Dispose ();
                polizaTextField = null;
            }
        }
    }
}