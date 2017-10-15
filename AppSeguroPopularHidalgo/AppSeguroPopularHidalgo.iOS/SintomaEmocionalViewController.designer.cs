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
    [Register ("SintomaEmocionalViewController")]
    partial class SintomaEmocionalViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton asustadoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton cansadoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton contentoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton enojadoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton fechaSintomaEmocionalButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton guardarSintomaEmocionalButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton hambrientoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton tristeButton { get; set; }

        [Action ("TristeButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TristeButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (asustadoButton != null) {
                asustadoButton.Dispose ();
                asustadoButton = null;
            }

            if (cansadoButton != null) {
                cansadoButton.Dispose ();
                cansadoButton = null;
            }

            if (contentoButton != null) {
                contentoButton.Dispose ();
                contentoButton = null;
            }

            if (enojadoButton != null) {
                enojadoButton.Dispose ();
                enojadoButton = null;
            }

            if (fechaSintomaEmocionalButton != null) {
                fechaSintomaEmocionalButton.Dispose ();
                fechaSintomaEmocionalButton = null;
            }

            if (guardarSintomaEmocionalButton != null) {
                guardarSintomaEmocionalButton.Dispose ();
                guardarSintomaEmocionalButton = null;
            }

            if (hambrientoButton != null) {
                hambrientoButton.Dispose ();
                hambrientoButton = null;
            }

            if (tristeButton != null) {
                tristeButton.Dispose ();
                tristeButton = null;
            }
        }
    }
}