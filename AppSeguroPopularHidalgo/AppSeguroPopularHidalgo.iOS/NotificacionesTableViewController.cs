using AppSeguroPopularHidalgo.iOS.Azure;
using AppSeguroPopularHidalgo.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{

	public class TableSourceMedicos : UITableViewSource
	{

		List<Notificaciones> TableItems;
		string CellIdentifier = "notificacion";

		public TableSourceMedicos(List<Notificaciones> items)
		{
			TableItems = items;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("notificacion");



			var data = TableItems[indexPath.Row];

			cell.TextLabel.Text = data.Titulo;

			return cell;
		}

	}

	public partial class NotificacionesTableViewController : UITableViewController
	{

		System.Collections.Generic.IEnumerable<Notificaciones> dataNotifications;
		List<Notificaciones> listaNotificaciones = new List<Notificaciones>();
		public NotificacionesTableViewController(IntPtr handle) : base(handle)
		{

		}
		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();


			try
			{
				dataNotifications = await MobileAppConnection.GetAllNotifications();

				foreach (Notificaciones notificacion in dataNotifications)
				{
					listaNotificaciones.Add(notificacion);
				}
				notificacionesTableView.Source = new TableSourceMedicos(listaNotificaciones);

				notificacionesTableView.ReloadData();
			}
			catch (Exception ex) { }
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "notificacionSegue")
			{
				var navigationController = segue.DestinationViewController as NotificacionViewController;

				if (navigationController != null)
				{
					var rowPath = notificacionesTableView.IndexPathForSelectedRow;
					var selectedData = listaNotificaciones[rowPath.Row];
					navigationController.titulos = selectedData.Titulo;
					navigationController.descripciones = selectedData.Descripcion;
				}
			}
		}

		[Action("UnwindToNotificacionesTableViewController:")]
		public async void UnwindToNotificacionesTableViewController(UIStoryboardSegue segue)
		{
			dataNotifications = await MobileAppConnection.GetAllNotifications();

			foreach (Notificaciones notificacion in dataNotifications)
			{
				listaNotificaciones.Add(notificacion);
			}
			notificacionesTableView.Source = new TableSourceMedicos(listaNotificaciones);

			notificacionesTableView.ReloadData();
		}


	}
}