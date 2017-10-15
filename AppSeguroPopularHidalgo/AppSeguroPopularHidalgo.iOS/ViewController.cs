using AppSeguroPopularHidalgo.Storage;
using System;

using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


            iniciarSesionButton.TouchUpInside += IniciarSesionButton_TouchUpInside;
			
		}

        private async  void IniciarSesionButton_TouchUpInside(object sender, EventArgs e)
        {
            AfiliadosSeguroPopular afiliado = new AfiliadosSeguroPopular();
            await afiliado.GetDataFromAPi(polizaTextField.Text,numeroConsecutivoTextField.Text);
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

