using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class NotificacionViewController : UIViewController
    {
        public static string titulo, descripcion;
        public  string titulos, descripciones;
        public NotificacionViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tituloLabel.Text = titulos;
            descripcionLabel.Text = descripciones;
        }
    }
}