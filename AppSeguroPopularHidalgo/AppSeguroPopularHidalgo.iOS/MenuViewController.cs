using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class MenuViewController : UIViewController
	{
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			cerrarSesionButton.TouchUpInside += CerrarSesionButton_TouchUpInside;
		}

		void CerrarSesionButton_TouchUpInside(object sender, EventArgs e)
		{
			ConfiguracionApp configuration = new ConfiguracionApp();

			configuration.LimpiarConfiguracion();

			MainNavigationController mainNavigationController = this.Storyboard.InstantiateViewController("MainNavigation") as MainNavigationController;
			if (mainNavigationController != null)
			{
				this.NavigationController.ShowDetailViewController(mainNavigationController, this);
			}
		}
	}
}