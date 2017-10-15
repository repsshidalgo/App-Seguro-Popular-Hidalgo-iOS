using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class FechaSintomaEmocionalViewController : UIViewController
    {
        public FechaSintomaEmocionalViewController (IntPtr handle) : base (handle)
        {
        }
		/// <summary>
		/// caraga de vista de sintomas al igual que carga controles como la fecha descripción y emoción.
		/// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            fechaSintomaEmocionalDatePicker.TimeZone = NSTimeZone.LocalTimeZone;

            FullProperties properties = new FullProperties();
            properties.Fecha = DateTime.SpecifyKind((DateTime)fechaSintomaEmocionalDatePicker.Date, DateTimeKind.Utc).ToLocalTime().ToShortDateString();

            fechaSintomaEmocionalDatePicker.ValueChanged += FechaSintomaFisicoDatePicker_ValueChanged;


        }
		/// <summary>
		/// Control para el cambio de fecha
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void FechaSintomaFisicoDatePicker_ValueChanged(object sender, EventArgs e)
        {
            FullProperties properties = new FullProperties();
            properties.Fecha = DateTime.SpecifyKind((DateTime)(sender as UIDatePicker).Date, DateTimeKind.Utc).ToLocalTime().ToShortDateString();
        }
    }
}