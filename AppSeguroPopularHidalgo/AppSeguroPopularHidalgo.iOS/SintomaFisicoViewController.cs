using AppSeguroPopularHidalgo.iOS.Storage;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomaFisicoViewController : UIViewController
    {
        public static Sintomas sintomaSelected;
		/// <summary>
		/// Variable para la intencidaa de dolor fisicio
		/// </summary>
        int intensidad;
		/// <summary>
		/// Variable para describir la intencidad de dolor
		/// </summary>
        string Dolor;

        public SintomaFisicoViewController(IntPtr handle) : base(handle)
        {
        }
		/// <summary>
		/// botones para la selección de dolor 
		/// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            sinDolorButton.TouchUpInside += SinDolorButton_TouchUpInside;
            dolorLeveButton.TouchUpInside += DolorLeveButton_TouchUpInside;
            dolorModeradoButton.TouchUpInside += DolorModeradoButton_TouchUpInside;
            dolorSeveroButton.TouchUpInside += DolorSeveroButton_TouchUpInside;
            dolorMuySeveroButton.TouchUpInside += DolorMuySeveroButton_TouchUpInside;
            maximoDolorButton.TouchUpInside += MaximoDolorButton_TouchUpInside;

            guardarSintomaFisicoButton.TouchUpInside += GuardarSintomaFisicoButton_TouchUpInside;
        }
		/// <summary>
		/// Guarda el estado del botón precionado en este caso el sisntoma
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void GuardarSintomaFisicoButton_TouchUpInside(object sender, EventArgs e)
        {
            if (!(intensidad == 0 || intensidad > 6) && !fechaSintomaFisicoButton.TitleLabel.Text.Equals("Seleccione la fecha") && !descripcionSintomaFisicoTextField.Text.Equals(""))
            {

                iOSConnection iOSConnection = new iOSConnection();
                var connection = iOSConnection.DBiOSConnection();
                DBConnection dbConnection = new DBConnection(connection);

                FullProperties property = new FullProperties();

                SintomasFisicos sintomaFisico = new SintomasFisicos()
                {
                    Descripcion = descripcionSintomaFisicoTextField.Text,
                    Intensidad = Dolor,
                    Fecha = fechaSintomaFisicoButton.TitleLabel.Text,
                    ídSintoma = property.IdSintoma
                };

                dbConnection.CreateSintomaFisico(sintomaFisico);

                SintomasFisicosTableViewController detailUnidad = this.Storyboard.InstantiateViewController("sintomasFisicosTable") as SintomasFisicosTableViewController;
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
                    mensaje = mensaje + "\nSeleccione la intensidad del dolor";
                }
                if (fechaSintomaFisicoButton.TitleLabel.Text.Equals("Seleccione la fecha"))
                {
                    mensaje = mensaje + "\nSeleccione la fecha";
                }
                if (descripcionSintomaFisicoTextField.Text.Equals(""))
                {
                    mensaje = mensaje + "\nAgrega una descripción";
                }

                Messages(mensaje);
            }
        }
		/// <summary>
		/// Evento botón de Máximo dolor
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void MaximoDolorButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 6;
            itemSelected(intensidad);
        }

		/// <summary>
		/// Evento botón de dolor muy severo
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void DolorMuySeveroButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 5;
            itemSelected(intensidad);
        }

		/// <summary>
		/// Evento botón dolor severo
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void DolorSeveroButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 4;
            itemSelected(intensidad);
        }

		/// <summary>
		/// evento botón dolor moderado
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void DolorModeradoButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 3;
            itemSelected(intensidad);
        }
		/// <summary>
		/// Evento botón deolor leve
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        private void DolorLeveButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 2;
            itemSelected(intensidad);
        }
		/// <summary>
		/// Evento botón sin dolor
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>

        private void SinDolorButton_TouchUpInside(object sender, EventArgs e)
        {
            intensidad = 1;
            itemSelected(intensidad);
        }
		/// <summary>
		/// Selección de dolor de acuerdo al estado del botón preconado
		/// </summary>
		/// <param name="item">Item.</param>
        private void itemSelected(int item)
        {
            switch (item)
            {
                case 1:
                    Dolor = "Sin Dolor";
                    sinDolorButton.Enabled = false;
                    dolorLeveButton.Enabled = true;
                    dolorModeradoButton.Enabled = true;
                    dolorSeveroButton.Enabled = true;
                    dolorMuySeveroButton.Enabled = true;
                    maximoDolorButton.Enabled = true;
                    break;
                case 2:
                    Dolor = "Dolor Leve";
                    sinDolorButton.Enabled = true;
                    dolorLeveButton.Enabled = false;
                    dolorModeradoButton.Enabled = true;
                    dolorSeveroButton.Enabled = true;
                    dolorMuySeveroButton.Enabled = true;
                    maximoDolorButton.Enabled = true;
                    break;
                case 3:
                    Dolor = "Dolor Moderado";
                    sinDolorButton.Enabled = true;
                    dolorLeveButton.Enabled = true;
                    dolorModeradoButton.Enabled = false;
                    dolorSeveroButton.Enabled = true;
                    dolorMuySeveroButton.Enabled = true;
                    maximoDolorButton.Enabled = true;
                    break;
                case 4:
                    Dolor = "Dolor Severo";
                    sinDolorButton.Enabled = true;
                    dolorLeveButton.Enabled = true;
                    dolorModeradoButton.Enabled = true;
                    dolorSeveroButton.Enabled = false;
                    dolorMuySeveroButton.Enabled = true;
                    maximoDolorButton.Enabled = true;
                    break;
                case 5:
                    Dolor = "Dolor Muy Severo";
                    sinDolorButton.Enabled = true;
                    dolorLeveButton.Enabled = true;
                    dolorModeradoButton.Enabled = true;
                    dolorSeveroButton.Enabled = true;
                    dolorMuySeveroButton.Enabled = false;
                    maximoDolorButton.Enabled = true;
                    break;
                case 6:
                    Dolor = "Máximo Dolor";
                    sinDolorButton.Enabled = true;
                    dolorLeveButton.Enabled = true;
                    dolorModeradoButton.Enabled = true;
                    dolorSeveroButton.Enabled = true;
                    dolorMuySeveroButton.Enabled = true;
                    maximoDolorButton.Enabled = false;
                    break;
            }
        }

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
		/// Fecha en el cual sucedio tal evento
		/// </summary>
		/// <param name="segue">Segue.</param>
        [Action("UnwindToSintomaFisicoViewController:")]
        public void UnwindToSintomaFisicoViewController(UIStoryboardSegue segue)
        {

            FullProperties properties = new FullProperties();
            fechaSintomaFisicoButton.SetTitle(properties.Fecha, UIControlState.Normal);

        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            this.View.EndEditing(true);
        }


    }
}