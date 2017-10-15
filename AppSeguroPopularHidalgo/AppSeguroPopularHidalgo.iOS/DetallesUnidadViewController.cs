using AppSeguroPopularHidalgo.Model;
using CoreLocation;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class DetallesUnidadViewController : UIViewController
    {

        public UnidadSalud unidadSelected;

        public DetallesUnidadViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            this.AutomaticallyAdjustsScrollViewInsets = false;

            detallesUnidadTableView.Source = new TableSource(unidadSelected);
            
            detallesUnidadTableView.ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            

            var coordinate = new CoreLocation.CLLocationCoordinate2D(Double.Parse(unidadSelected.Latitud), Double.Parse(unidadSelected.Longitud));
            var region = new MapKit.MKCoordinateRegion(coordinate, new MapKit.MKCoordinateSpan(0, 0));
            unidadMapView.SetRegion(region, true);
            unidadMapView.AddAnnotations(new MKPointAnnotation()
            {
                Title = unidadSelected.Nombre,
                Coordinate = new CLLocationCoordinate2D(Double.Parse(unidadSelected.Latitud), Double.Parse(unidadSelected.Longitud)),
            });

            mapUnidadActionButton.Clicked += MapUnidadActionButton_Clicked;
            
        }

        private void MapUnidadActionButton_Clicked(object sender, EventArgs e)
        {
            string url = "http://maps.apple.com/?saddr=&daddr=" + unidadSelected.Latitud + "," + unidadSelected.Longitud;

            if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl(url)))
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
            }
            else
            {
                new UIAlertView("Error", "Maps is not supported on this device", null, "Ok").Show();
            }
        }
    }
}