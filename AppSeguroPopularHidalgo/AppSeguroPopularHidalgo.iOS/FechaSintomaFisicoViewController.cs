using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class FechaSintomaFisicoViewController : UIViewController
    {

        


        public FechaSintomaFisicoViewController (IntPtr handle) : base (handle)
        {
        }
		/// <summary>
		/// Carga de vista de sintomas fisicos 
		/// </summary>

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            fechaSintomaFisicoDatePicker.TimeZone = NSTimeZone.LocalTimeZone;

            FullProperties properties = new FullProperties();
            properties.Fecha = DateTime.SpecifyKind((DateTime)fechaSintomaFisicoDatePicker.Date, DateTimeKind.Utc).ToLocalTime().ToShortDateString();

            fechaSintomaFisicoDatePicker.ValueChanged += FechaSintomaFisicoDatePicker_ValueChanged;
            

        }
		/// <summary>
		/// cambio de fecha con los sintomas fisicos 
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