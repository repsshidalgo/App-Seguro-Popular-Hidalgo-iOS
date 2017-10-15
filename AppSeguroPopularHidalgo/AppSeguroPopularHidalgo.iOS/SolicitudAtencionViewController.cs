using AppSeguroPopularHidalgo.iOS.Services;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class SolicitudAtencionViewController : UIViewController
	{
		public SolicitudAtencionViewController(IntPtr handle) : base(handle)
		{
		}
		/// <summary>
		/// Carga de elementos de envio de solicitud, queja o denunci
		/// </summary>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			enviarEmailButton.TouchUpInside += EnviarEmailButton_TouchUpInside;
			telefonoButton.TouchUpInside += TelefonoButton_TouchUpInside;
		}

		/// <summary>
		/// Evento para eviar email queja, denuncia, felicitaciones
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void EnviarEmailButton_TouchUpInside(object sender, EventArgs e)
		{
			Email email = new Email();

			if (email.EmailSneder("Contacto:" + informacionContactoTextField.Text + "\n" + "Solicitud:" + solicitudTextField.Text))
			{
				UIAlertView alert = new UIAlertView()
				{
					Message = "Tu solicitud fue enviada correctamente.",
					Title = "Aviso"
				};

				alert.AddButton("Ok");
				alert.Show();
				informacionContactoTextField.Text = "";
				solicitudTextField.Text = "";
				this.View.EndEditing(true);
			}
			else
			{
				UIAlertView alert = new UIAlertView()
				{
					Message = "Hubo un problema, favor de intentarlo más tarde.",
					Title = "Aviso"
				};

				alert.AddButton("Ok");
				alert.Show();
			}
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			this.View.EndEditing(true);
		}

		void TelefonoButton_TouchUpInside(object sender, EventArgs e)
		{
			var url = new NSUrl("tel:" + "018007172583");
			if (!UIApplication.SharedApplication.OpenUrl(url))
			{
				
			};

		}
	}
}