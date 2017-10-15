using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using UIKit;


namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomaEmocionalViewController : UIViewController
    {
		/// <summary>
		/// Variable intencidad
		/// </summary>
        int intensidad;
		/// <summary>
		/// Variable emocional
		/// </summary>
        string Emocional;

        public SintomaEmocionalViewController(IntPtr handle) : base(handle)
        {
        }
		/// <summary>
		/// Carga de los tipos emocionales segun tenga el usario
		/// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            asustadoButton.TouchUpInside += AsustadoButton_TouchUpInside;
            cansadoButton.TouchUpInside += CansadoButton_TouchUpInside;
            contentoButton.TouchUpInside += ContentoButton_TouchUpInside;
            enojadoButton.TouchUpInside += EnojadoButton_TouchUpInside;
            hambrientoButton.TouchUpInside += HambrientoButton_TouchUpInside;
            tristeButton.TouchUpInside += TristeButton_TouchUpInside;

            guardarSintomaEmocionalButton.TouchUpInside += GuardarSintomaEmocionalButton_TouchUpInside;
        }
		/// <summary>
		/// Guarda los datos emocionales dados por el usario
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void GuardarSintomaEmocionalButton_TouchUpInside(object sender, EventArgs e)
        {
            if (!(intensidad == 0 || intensidad > 6) && !fechaSintomaEmocionalButton.TitleLabel.Text.Equals("Seleccione la fecha"))
            {
                iOSConnection iOSConnection = new iOSConnection();
                var connection = iOSConnection.DBiOSConnection();
                DBConnection dbConnection = new DBConnection(connection);

                FullProperties property = new FullProperties();

                SintomasEmocionales sintomaEmocional = new SintomasEmocionales()
                {
                    Tipo = Emocional,
                    Fecha = fechaSintomaEmocionalButton.TitleLabel.Text,
                    ídSintoma = property.IdSintoma
                };

                dbConnection.CreateSintomaEmocional(sintomaEmocional);

                SintomasEmocionalesTableViewController detailUnidad = this.Storyboard.InstantiateViewController("sintomasEmocionalesTable") as SintomasEmocionalesTableViewController;
                if (detailUnidad != null)
                {
                    this.NavigationController.ShowViewController(detailUnidad, this);
                }

            }
            else
            {
                string mensaje = "";
                if (intensidad == 0 || intensidad > 6)
                {
                    mensaje = mensaje + "\nSeleccione la emoción que esta experimentando";
                }
                if (fechaSintomaEmocionalButton.TitleLabel.Text.Equals("Seleccione la fecha"))
                {
                    mensaje = mensaje + "\nSeleccione la fecha";
                }

                Messages(mensaje);

            }
        }
		/// <summary>
		/// Boton de sintoma de tristesa
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void TristeButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 6;
            itemSelected(intensidad);
        }
		/// <summary>
        /// Boton de sintoma de tristesa
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void HambrientoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 5;
            itemSelected(intensidad);
        }
		/// <summary>
       /// Boton de sintoma de enojo
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void EnojadoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 4;
            itemSelected(intensidad);
        }
		/// <summary>
/// Boton de sintoma de contento
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void ContentoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 3;
            itemSelected(intensidad);
        }
		/// <summary>
/// Boton de sintoma de cansancio
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void CansadoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 2;
            itemSelected(intensidad);
        }
		/// <summary>
///Boton de sintoma de asustado
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void AsustadoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 1;
            itemSelected(intensidad);
        }
		/// <summary>
		/// Casos para determinar el tipo de estado emocional
		/// </summary>
		/// <param name="item">Item.</param>
        private void itemSelected(int item)
        {
            switch (item)
            {
                case 1:
                    Emocional = "Asustado";
                    asustadoButton.Enabled = false;
                    cansadoButton.Enabled = true;
                    contentoButton.Enabled = true;
                    enojadoButton.Enabled = true;
                    hambrientoButton.Enabled = true;
                    tristeButton.Enabled = true;
                    break;
                case 2:
                    Emocional = "Cansado";
                    asustadoButton.Enabled = true;
                    cansadoButton.Enabled = false;
                    contentoButton.Enabled = true;
                    enojadoButton.Enabled = true;
                    hambrientoButton.Enabled = true;
                    tristeButton.Enabled = true;
                    break;
                case 3:
                    Emocional = "Contento";
                    asustadoButton.Enabled = true;
                    cansadoButton.Enabled = true;
                    contentoButton.Enabled = false;
                    enojadoButton.Enabled = true;
                    hambrientoButton.Enabled = true;
                    tristeButton.Enabled = true;
                    break;
                case 4:
                    Emocional = "Enojado";
                    asustadoButton.Enabled = true;
                    cansadoButton.Enabled = true;
                    contentoButton.Enabled = true;
                    enojadoButton.Enabled = false;
                    hambrientoButton.Enabled = true;
                    tristeButton.Enabled = true;
                    break;
                case 5:
                    Emocional = "Hambriento";
                    asustadoButton.Enabled = true;
                    cansadoButton.Enabled = true;
                    contentoButton.Enabled = true;
                    enojadoButton.Enabled = true;
                    hambrientoButton.Enabled = false;
                    tristeButton.Enabled = true;
                    break;
                case 6:
                    Emocional = "Triste";
                    asustadoButton.Enabled = true;
                    cansadoButton.Enabled = true;
                    contentoButton.Enabled = true;
                    enojadoButton.Enabled = true;
                    hambrientoButton.Enabled = true;
                    tristeButton.Enabled = false;
                    break;
            }
        }

		/// <summary>
		/// Notificacion de que se a guardado el estado emocional
		/// </summary>
		/// <returns>The messages.</returns>
		/// <param name="mensaje">Mensaje.</param>
        private void Messages(string mensaje)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Aviso",
                Message = mensaje
            };

            alert.AddButton("Ok");
            alert.Show();
        }
		/// <summary>
		/// Control de fecha
		/// </summary>
		/// <param name="segue">Segue.</param>
        [Action("UnwindToSintomaEmocionalViewController:")]
        public void UnwindToSintomaEmocionalViewController(UIStoryboardSegue segue)
        {

            FullProperties properties = new FullProperties();
            fechaSintomaEmocionalButton.SetTitle(properties.Fecha, UIControlState.Normal);

        }
    }
}