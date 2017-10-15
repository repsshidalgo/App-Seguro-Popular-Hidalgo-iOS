using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class DetallesViewCell : UITableViewCell
    {

        private string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value;
                detalleLabel.Text = valor;
            }
        }


        public DetallesViewCell (IntPtr handle) : base (handle)
        {

        }
    }
}