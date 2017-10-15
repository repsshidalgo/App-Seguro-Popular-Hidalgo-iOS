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
    [Register ("SolicitudAtencionViewController")]
    partial class SolicitudAtencionViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton enviarEmailButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField informacionContactoTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField solicitudTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton telefonoButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (enviarEmailButton != null) {
                enviarEmailButton.Dispose ();
                enviarEmailButton = null;
            }

            if (informacionContactoTextField != null) {
                informacionContactoTextField.Dispose ();
                informacionContactoTextField = null;
            }

            if (solicitudTextField != null) {
                solicitudTextField.Dispose ();
                solicitudTextField = null;
            }

            if (telefonoButton != null) {
                telefonoButton.Dispose ();
                telefonoButton = null;
            }
        }
    }
}