using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomaTableViewCell : UITableViewCell
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                nombreSintomaLabel.Text = nombre;
            }
        }
        public SintomaTableViewCell (IntPtr handle) : base (handle)
        {
        }
    }
}