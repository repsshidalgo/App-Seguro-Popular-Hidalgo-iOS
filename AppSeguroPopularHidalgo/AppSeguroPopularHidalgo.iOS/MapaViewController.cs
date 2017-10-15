using AppSeguroPopularHidalgo.Model;
using AppSeguroPopularHidalgo.Storage;
using CoreLocation;
using Foundation;
using MapKit;
using System;
using System.Threading.Tasks;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
	public partial class MapaViewController : UIViewController
	{

		UIButton detailButton;
		int opcion = 1;
		CLLocationManager locationManager = new CLLocationManager();

		public MapaViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewWillAppear(bool animated)
		{


		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad(); var plist = NSUserDefaults.StandardUserDefaults;

			elementoUnoLabel.Font = UIFont.FromName("Helvetica-Bold", 12f);
			elementoDosLabel.Font = UIFont.FromName("Helvetica-Bold", 12f);

			if (mapaNavigationItem != null)
			{
				//Desaparezco el botón de "Back" del navigation controller
				mapaNavigationItem.HidesBackButton = true;
			}

			/* var estado = plist.StringForKey("userStatus");
			 estadoPolizaLabel.Text = estado;
			 if (estado.Equals("Activo"))
				 estadoPolizaLabel.BackgroundColor = UIColor.Green;
			 else
				 estadoPolizaLabel.BackgroundColor = UIColor.Red;
			 */

			mapaSegmentedControl.ValueChanged += MapaSegmentedControl_ValueChanged;
			CLLocationCoordinate2D coords = new CLLocationCoordinate2D(20.468812, -98.988980);
			MKCoordinateSpan span = new MKCoordinateSpan(2, 2);
			seguroPopularMapView.Region = new MKCoordinateRegion(coords, span);
			AgregarMarcadoresUnidades();


			//cerrarSesionBarButtonItem.Clicked += CerrarSesionBarButtonItem_Clicked
			buscarBarButtonItem.Clicked += BuscarBarButtonItem_Clicked;




		}

		private void BuscarBarButtonItem_Clicked(object sender, EventArgs e)
		{
			this.PerformSegue("buscarTabBarSegue", this);
		}

		private void UsuarioBarButtonItem_Clicked(object sender, EventArgs e)
		{
			this.PerformSegue("usuarioTabBarSegue", this);
		}

		//private void CerrarSesionBarButtonItem_Clicked(object sender, EventArgs e)
		//{
		//    ConfiguracionApp configuration = new ConfiguracionApp();

		//    configuration.LimpiarConfiguracion();

		//    LoginViewController loginViewController = this.Storyboard.InstantiateViewController("LoginView") as LoginViewController;
		//    if (loginViewController != null)
		//    {
		//        this.NavigationController.PushViewController(loginViewController, true);
		//    }

		//}

		string pId = "PinAnnotation";





		private void AgregarMarcadoresUnidades()
		{
			CentroInformacion centros = new CentroInformacion();
			seguroPopularMapView.Delegate = new MapDelegate(this, 1);
			foreach (UnidadSalud unidad in centros.GetAllUnidadesSalud())
			{

				seguroPopularMapView.AddAnnotations(new MKPointAnnotation()
				{
					Title = unidad.Nombre,
					Coordinate = new CLLocationCoordinate2D(Double.Parse(unidad.Latitud), Double.Parse(unidad.Longitud)),
					Subtitle = unidad.Unidad
				});
			}
		}

		private void AgregarMarcadoresCentros()
		{

			CentroInformacion centros = new CentroInformacion();
			seguroPopularMapView.Delegate = new MapDelegate(this, 2);
			foreach (CentroAfiliacion centro in centros.GetAllCentrosAfiliacion())
			{

				seguroPopularMapView.AddAnnotations(new MKPointAnnotation()
				{
					Title = centro.Nombre,
					Coordinate = new CLLocationCoordinate2D(Double.Parse(centro.Latitud), Double.Parse(centro.Longitud)),
					Subtitle = centro.Horario
				});
			}
		}



		private void MapaSegmentedControl_ValueChanged(object sender, EventArgs e)
		{
			var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;

			switch (selectedSegmentId)
			{
				case 0:
					seguroPopularMapView.RemoveAnnotations(seguroPopularMapView.Annotations);
					AgregarMarcadoresUnidades();
					opcion = 1;
					elementoUnoLabel.Text = "Hospitales";
					elementoDosLabel.Text = "Unidad de salud";
					elementoUnoImageView.Image = UIImage.FromBundle("rojopushpin copia");
					elementoDosImageView.Image = UIImage.FromBundle("morado");
					break;

				case 1:
					seguroPopularMapView.RemoveAnnotations(seguroPopularMapView.Annotations);
					AgregarMarcadoresCentros();
					opcion = 2;
					elementoUnoLabel.Text = "Coordinación estatal";
					elementoDosLabel.Text = "Centro de afiliación";
					elementoUnoImageView.Image = UIImage.FromBundle("rojopushpin copia");
					elementoDosImageView.Image = UIImage.FromBundle("rojopushpin");
					break;
			}
		}



		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier == "usuarioTabBarSegue")
			{
				return false;
			}
			if (segueIdentifier == "buscarTabBarSegue")
			{
				return false;
			}
			return true;
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "buscarTabBarSegue")
			{
				var navigationController = segue.DestinationViewController as BuscarViewController;

				if (navigationController != null)
				{
					navigationController.opcionSelected = opcion;
				}
			}
		}

		[Action("UnwindToMapaViewController:")]
		public void UnwindToMapaViewController(UIStoryboardSegue segue)
		{

		}
	}
}