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
    [Register ("UsuarioViewController")]
    partial class UsuarioViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel apellidoMaternoUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel apellidoPaternoUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton capturaPolizaButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel curpUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel edadUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel fechaVencimientoUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel folioUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nombreUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel numeroConsecutivoUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sexoUsuarioLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel unidadSaludUsuarioLabel { get; set; }

        [Action ("CapturaPolizaButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CapturaPolizaButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIBarButtonItem12261_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem12261_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (apellidoMaternoUsuarioLabel != null) {
                apellidoMaternoUsuarioLabel.Dispose ();
                apellidoMaternoUsuarioLabel = null;
            }

            if (apellidoPaternoUsuarioLabel != null) {
                apellidoPaternoUsuarioLabel.Dispose ();
                apellidoPaternoUsuarioLabel = null;
            }

            if (capturaPolizaButton != null) {
                capturaPolizaButton.Dispose ();
                capturaPolizaButton = null;
            }

            if (curpUsuarioLabel != null) {
                curpUsuarioLabel.Dispose ();
                curpUsuarioLabel = null;
            }

            if (edadUsuarioLabel != null) {
                edadUsuarioLabel.Dispose ();
                edadUsuarioLabel = null;
            }

            if (fechaVencimientoUsuarioLabel != null) {
                fechaVencimientoUsuarioLabel.Dispose ();
                fechaVencimientoUsuarioLabel = null;
            }

            if (folioUsuarioLabel != null) {
                folioUsuarioLabel.Dispose ();
                folioUsuarioLabel = null;
            }

            if (nombreUsuarioLabel != null) {
                nombreUsuarioLabel.Dispose ();
                nombreUsuarioLabel = null;
            }

            if (numeroConsecutivoUsuarioLabel != null) {
                numeroConsecutivoUsuarioLabel.Dispose ();
                numeroConsecutivoUsuarioLabel = null;
            }

            if (sexoUsuarioLabel != null) {
                sexoUsuarioLabel.Dispose ();
                sexoUsuarioLabel = null;
            }

            if (unidadSaludUsuarioLabel != null) {
                unidadSaludUsuarioLabel.Dispose ();
                unidadSaludUsuarioLabel = null;
            }
        }
    }
}