using AppSeguroPopularHidalgo.Storage;
using Foundation;
using System;
using UIKit;
using WindowsAzure.Messaging;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class LoginViewController : UIViewController
	{

		private SBNotificationHub Hub { get; set; }


		public LoginViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			/*var plist = NSUserDefaults.StandardUserDefaults;

			if (plist.BoolForKey("userLogin"))
			{
				//MapaViewController mapaViewController = this.Storyboard.InstantiateViewController("MapaViewControllerStoryboard") as MapaViewController;
				AppTabBarController usarioViewController = this.Storyboard.InstantiateViewController("usuarioStoryBoard") as AppTabBarController;
				if (usarioViewController != null)
				{
					this.NavigationController.ShowDetailViewController(usarioViewController, this);
				}

			}*/


		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			if (logueoNavigationItem != null)
			{
				//Desaparezco el botón de "Back" del navigation controller
				logueoNavigationItem.HidesBackButton = true;
			}




			iniciarSesionButton.TouchUpInside += IniciarSesionButton_TouchUpInside;
			polizaTextField.EditingChanged += PolizaTextField_EditingChanged;
			numeroConsecutivoTextField.EditingChanged += NumeroConsecutivoTextField_EditingChanged;
		}

		private void PolizaTextField_EditingChanged(object sender, EventArgs e)
		{
			if (polizaTextField.Text.Length != 0 && numeroConsecutivoTextField.Text.Length != 0)
				iniciarSesionButton.Enabled = true;
			else if (polizaTextField.Text.Length == 0 || numeroConsecutivoTextField.Text.Length == 0)
				iniciarSesionButton.Enabled = false;
		}

		private void NumeroConsecutivoTextField_EditingChanged(object sender, EventArgs e)
		{
			if (polizaTextField.Text.Length != 0 && numeroConsecutivoTextField.Text.Length != 0)
				iniciarSesionButton.Enabled = true;
			else if (polizaTextField.Text.Length == 0 || numeroConsecutivoTextField.Text.Length == 0)
				iniciarSesionButton.Enabled = false;
		}

		private void IniciarSesionButton_TouchUpInside(object sender, EventArgs e)
		{

			Connectivity.Plugin.NetworkStatus internetStatus = Connectivity.Plugin.Reachability.InternetConnectionStatus();


			if (internetStatus != Connectivity.Plugin.NetworkStatus.NotReachable)
			{


				Navigation();


			}
			else
			{
				UIAlertView alert = new UIAlertView()
				{
					Message = "No tienes conexión a internet. Favor de intentarlo más tarde.",
					Title = "Aviso"
				};

				alert.AddButton("Ok");
				alert.Show();
			}


		}

		private async void Navigation()
		{
			TokenRegistration token = new TokenRegistration();

			iniciarSesionButton.Enabled = false;
			AfiliadosSeguroPopular afiliado = new AfiliadosSeguroPopular();
			var afiliadoSP = await afiliado.GetDataFromAPi(polizaTextField.Text, numeroConsecutivoTextField.Text);

			if (afiliadoSP.folio != null)
			{
				ConfiguracionApp config = new ConfiguracionApp();

				config.GuardarConfiguracion(afiliadoSP);

				var plist = NSUserDefaults.StandardUserDefaults;
				try
				{
					Hub = new SBNotificationHub(Constants.ConnectionString, Constants.NotificationHubPath);

					Hub.UnregisterAllAsync(token.Token, (error) =>
					{
						if (error != null)
						{
							return;
						}

						NSSet tags = new NSSet(plist.StringForKey("userFolio"), plist.StringForKey("userTag")); // create tags if you want
					Hub.RegisterNativeAsync(token.Token, tags, (errorCallback) =>
						{
							if (errorCallback != null)
							{

							}
						});
					});
				}
				catch (Exception ex)
				{
				}


				this.PerformSegue("loginUserSeguroPopular", this);
			}
			else
			{
				iniciarSesionButton.Enabled = true;
				UIAlertView alert = new UIAlertView()
				{
					Message = "Usted no esta afiliado en nuestro sistema.",
					Title = "Seguro Popular Hidalgo"
				};

				alert.AddButton("Ok");
				alert.Show();
			}
		}

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier == "loginUserSeguroPopular")
			{
				return false;
			}
			return true;
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			this.View.EndEditing(true);
		}
	}
}