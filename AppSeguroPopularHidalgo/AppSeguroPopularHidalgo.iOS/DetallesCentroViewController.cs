using AppSeguroPopularHidalgo.Model;
using CoreLocation;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class DetallesCentroViewController : UIViewController
    {

        public CentroAfiliacion centroSelected;

        public DetallesCentroViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            this.AutomaticallyAdjustsScrollViewInsets = false;

            detallesCentroTableView.Source = new CentroTableSource(centroSelected);

            detallesCentroTableView.ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var coordinate = new CoreLocation.CLLocationCoordinate2D(Double.Parse(centroSelected.Latitud), Double.Parse(centroSelected.Longitud));
            var region = new MapKit.MKCoordinateRegion(coordinate, new MapKit.MKCoordinateSpan(0, 0));
            centroMapView.SetRegion(region, true);
            centroMapView.AddAnnotations(new MKPointAnnotation()
            {
                Title = centroSelected.Nombre,
                Coordinate = new CLLocationCoordinate2D(Double.Parse(centroSelected.Latitud), Double.Parse(centroSelected.Longitud)),
            });

            mapCentroActionButton.Clicked += MapCentroActionItem_Clicked;
        }

        private void MapCentroActionItem_Clicked(object sender, EventArgs e)
        {
            string url = "http://maps.apple.com/?saddr=&daddr=" + centroSelected.Latitud + "," + centroSelected.Longitud;
            url = url.Replace(" ", "%20");
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