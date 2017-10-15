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
    [Register ("FechaSintomaEmocionalViewController")]
    partial class FechaSintomaEmocionalViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker fechaSintomaEmocionalDatePicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (fechaSintomaEmocionalDatePicker != null) {
                fechaSintomaEmocionalDatePicker.Dispose ();
                fechaSintomaEmocionalDatePicker = null;
            }
        }
    }
}