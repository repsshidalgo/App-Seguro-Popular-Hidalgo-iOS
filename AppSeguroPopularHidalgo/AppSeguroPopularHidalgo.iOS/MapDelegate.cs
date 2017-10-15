using AppSeguroPopularHidalgo.iOS;
using AppSeguroPopularHidalgo.Storage;
using CoreLocation;
using MapKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
	public class MapDelegate : MKMapViewDelegate
	{

		protected string pId = "PinAnnotation";
		int opcion;
		UIButton detailButton;
		MapaViewController parent;
		IMKAnnotation annotation;


		public MapDelegate(MapaViewController parent, int opcion)
		{
			this.parent = parent;
			this.opcion = opcion;
		}

		public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
		{
			
				if (mapView.UserLocation != null)
				{
					CLLocationCoordinate2D coords = mapView.UserLocation.Coordinate;
					MKCoordinateSpan span = new MKCoordinateSpan(0.1, 0.1);
					mapView.Region = new MKCoordinateRegion(coords, span);
				}
		}

		public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
		{
			this.annotation = annotation;
			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(pId);
			// Set current location and location of annotation 
			CLLocationCoordinate2D currentLocation = mapView.UserLocation.Coordinate;
			CLLocationCoordinate2D annotationLocation = annotation.Coordinate;



			// We don't want a special annotation for the user location 
			if (currentLocation.Latitude == annotationLocation.Latitude && currentLocation.Longitude == annotationLocation.Longitude)
				return null;

			if (annotationView == null)
				annotationView = new MKPinAnnotationView(annotation, pId);
			else
				annotationView.Annotation = annotation;

			annotationView.CanShowCallout = true;
			(annotationView as MKPinAnnotationView).AnimatesDrop = false;

			var sss = annotation.GetTitle();
			// Set to true if you want to animate the pin dropping 
			if (annotation.GetTitle().Contains("HOSPITAL") || annotation.GetTitle().Contains("Coordinación"))
				(annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Red;
			else if (opcion == 1)
				(annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Purple;
			else if (opcion == 2)
				(annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Green;

			annotationView.Selected = true;

			// you can add an accessory view, in this case, we'll add a button on the right, and an image on the left
			detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);

			annotationView.RightCalloutAccessoryView = detailButton;

			// Annotation icon may be specified like this, in case you want it. 
			// annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromBundle("example.png")); 

			return annotationView;
		}

		public override void CalloutAccessoryControlTapped(MKMapView mapView, MKAnnotationView view, UIControl control)
		{

			CentroInformacion centros = new CentroInformacion();

			if (opcion == 1)
			{
				var resultados = centros.GetAllUnidadesSalud().Where(unidad => unidad.Nombre == view.Annotation.GetTitle() && unidad.Latitud == view.Annotation.Coordinate.Latitude.ToString() && unidad.Longitud == view.Annotation.Coordinate.Longitude.ToString());

				DetallesUnidadViewController detailUnidad = parent.Storyboard.InstantiateViewController("detallesUnidad") as DetallesUnidadViewController;
				if (detailUnidad != null)
				{
					detailUnidad.unidadSelected = resultados.ElementAt(0);
					parent.NavigationController.ShowViewController(detailUnidad, parent);
				}
			}
			else if (opcion == 2)
			{
				var resultados = centros.GetAllCentrosAfiliacion().Where(centro => centro.Nombre == view.Annotation.GetTitle() && centro.Latitud == view.Annotation.Coordinate.Latitude.ToString() && centro.Longitud == view.Annotation.Coordinate.Longitude.ToString());

				DetallesCentroViewController detailCentro = parent.Storyboard.InstantiateViewController("detallesCentro") as DetallesCentroViewController;
				if (detailCentro != null)
				{
					detailCentro.centroSelected = resultados.ElementAt(0);
					parent.NavigationController.ShowViewController(detailCentro, parent);
				}
			}
		}

		public override void RegionChanged(MKMapView mapView, bool animated) { }


	}
}
