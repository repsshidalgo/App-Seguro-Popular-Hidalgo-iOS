using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class AgregarSintomaViewController : UIViewController
    {
        public AgregarSintomaViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            agregarSintomaButton.TouchUpInside += AgregarSintomaButton_TouchUpInside;
        }
		//Se conecata a la base  de datos para insertar un nuevo síntoma 
        private void AgregarSintomaButton_TouchUpInside(object sender, EventArgs e)
        {
            iOSConnection iOSConnection = new iOSConnection();
            var connection = iOSConnection.DBiOSConnection();
            DBConnection dbConnection = new DBConnection(connection);

            Sintomas sintoma = new Sintomas() {
                Nombre = nombreSintomaTextField.Text
            };

            dbConnection.CreateSintoma(sintoma);

        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.View.EndEditing(true);
        }
    }
}