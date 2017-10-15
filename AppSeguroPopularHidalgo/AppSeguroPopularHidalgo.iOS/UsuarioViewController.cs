using AppSeguroPopularHidalgo.Storage;
using Foundation;
using MediaPlayer;
using System;
using System.IO;
using UIKit;
using WindowsAzure.Messaging;
using AppSeguroPopularHidalgo.Model;
using System.Linq;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class UsuarioViewController : UIViewController
	{

		UIImagePickerController imagePicker;

		string clues;

		private SBNotificationHub Hub { get; set; }

		public UsuarioViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var documentsDirectory = Environment.GetFolderPath
									  (Environment.SpecialFolder.Personal);
			string jpgFilename = System.IO.Path.Combine(documentsDirectory, "Poliza.jpg");

			if (File.Exists(jpgFilename))
			{
				capturaPolizaButton.SetTitle("Ver Captura", UIControlState.Normal);
			}

			CentroInformacion centro = new CentroInformacion();

			var plist = NSUserDefaults.StandardUserDefaults;

			folioUsuarioLabel.Text = "Folio: " + plist.StringForKey("userFolio");
			numeroConsecutivoUsuarioLabel.Text = "Número consecutivo: " + plist.StringForKey("userConsecutivo");
			nombreUsuarioLabel.Text = "Nombre: " + plist.StringForKey("userNombres");
			apellidoPaternoUsuarioLabel.Text = "Apellido paterno: " + plist.StringForKey("userApellidoPaterno");
			apellidoMaternoUsuarioLabel.Text = "Apellido materno: " + plist.StringForKey("userApellidoMaterno");
			sexoUsuarioLabel.Text = "Sexo: " + plist.StringForKey("userSexo");
			edadUsuarioLabel.Text = "Edad: " + plist.StringForKey("userEdad");
			curpUsuarioLabel.Text = "CURP: " + plist.StringForKey("userCURP");
			fechaVencimientoUsuarioLabel.Text = "Fecha de vencimiento: " + plist.StringForKey("userFechaVencimiento");
			unidadSaludUsuarioLabel.Text = "Unidad de salud asignado: " + centro.GetUnidadSaludAsignada(plist.StringForKey("userCLUES"));
			clues = plist.StringForKey("userCLUES");

			capturaPolizaButton.TouchUpInside += CapturaPolizaButton_TouchUpInside;

			unidadSaludUsuarioLabel.UserInteractionEnabled = true;
			UITapGestureRecognizer tapInformacionGesture = new UITapGestureRecognizer(tapUnidadSalud);
			unidadSaludUsuarioLabel.AddGestureRecognizer(tapInformacionGesture);

		}

		void tapUnidadSalud()
		{
			CentroInformacion centros = new CentroInformacion();

			var resultados = centros.GetAllUnidadesSalud().Where(unidad => unidad.Clues == clues);


			DetallesUnidadViewController detailUnidad = this.Storyboard.InstantiateViewController("detallesUnidad") as DetallesUnidadViewController;
			if (detailUnidad != null)
			{
				detailUnidad.unidadSelected = resultados.ElementAt(0);
				this.NavigationController.ShowViewController(detailUnidad, this);
			}
		}



		private void CapturaPolizaButton_TouchUpInside(object sender, EventArgs e)
		{

			var documentsDirectory = Environment.GetFolderPath
									  (Environment.SpecialFolder.Personal);
			string jpgFilename = System.IO.Path.Combine(documentsDirectory, "Poliza.jpg");

			if (File.Exists(jpgFilename))
			{
				capturaPolizaButton.SetTitle("Ver Captura", UIControlState.Normal);
				this.PerformSegue("visualizarCapturaSegue", this);
			}
			else
			{

				Camera.TakePicture(this, (obj) =>
				{

					var photo = obj.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;
					var meta = obj.ValueForKey(new NSString("UIImagePickerControllerMediaMetadata")) as NSDictionary;


					NSData imgData = photo.AsJPEG();
					NSError err = null;
					if (imgData.Save(jpgFilename, false, out err))
					{
						capturaPolizaButton.SetTitle("Ver Captura", UIControlState.Normal);
						this.PerformSegue("visualizarCapturaSegue", this);
					}
					else
					{
						Console.WriteLine("NOT saved as" + jpgFilename + " because" + err.LocalizedDescription);
					}


				});


			}
		}

		private void CerrarSesionButton_TouchUpInside(object sender, EventArgs e)
		{
			ConfiguracionApp configuration = new ConfiguracionApp();

			configuration.LimpiarConfiguracion();

			NavigationAppController loginViewController = this.Storyboard.InstantiateViewController("NavigationApp") as NavigationAppController;
			if (loginViewController != null)
			{
				TokenRegistration token = new TokenRegistration();

				Hub = new SBNotificationHub(Constants.ConnectionString, Constants.NotificationHubPath);

				Hub.UnregisterAllAsync(token.Token, (error) =>
				{
					if (error != null)
					{
						return;
					}
				});
				this.NavigationController.ShowDetailViewController(loginViewController, null);
			}
		}



		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier == "visualizarCapturaSegue")
			{
				return false;
			}
			return true;
		}


	}
}