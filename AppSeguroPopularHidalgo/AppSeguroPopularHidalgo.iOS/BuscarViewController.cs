using AppSeguroPopularHidalgo.Model;
using AppSeguroPopularHidalgo.Storage;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class BuscarViewController : UITableViewController
    {
        public int opcionSelected;

        IList<UnidadSalud> listUnidades;
        IList<UnidadSalud> searchItemsUnidades;

        IList<CentroAfiliacion> listCentros;
        IList<CentroAfiliacion> searchItemsCentros;

        public BuscarViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            CentroInformacion informacion = new CentroInformacion();

            if (opcionSelected == 1)
            {
                listUnidades = informacion.GetAllUnidadesSalud();
                searchItemsUnidades = listUnidades;
            }
            else if (opcionSelected == 2)
            {
                listCentros = informacion.GetAllCentrosAfiliacion();
                searchItemsCentros = listCentros;
            }

            centrosSearchView.SizeToFit();
            centrosSearchView.AutocorrectionType = UITextAutocorrectionType.No;
            centrosSearchView.AutocapitalizationType = UITextAutocapitalizationType.None;
            centrosSearchView.TextChanged += (sender, e) =>
            {
                //this is the method that is called when the user searches  
                searchTable();
            };
        }

        private void searchTable()
        {
            //perform the search, and refresh the table with the results  
            PerformSearch(centrosSearchView.Text);
            centrosTableView.ReloadData();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (opcionSelected == 1)
                return listUnidades.Count();
            else if (opcionSelected == 2)
                return listCentros.Count();

            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("centro");

            if (opcionSelected == 1)
            {
                var data = listUnidades[indexPath.Row];
                cell.TextLabel.Text = data.Nombre;
            }
            else if(opcionSelected == 2)
            {
                var data = listCentros[indexPath.Row];
                cell.TextLabel.Text = data.Nombre;
            }



            return cell;
        }

        public void PerformSearch(string searchText)
        {
            searchText = searchText.ToLower();
            if(opcionSelected == 1)
                this.listUnidades = searchItemsUnidades.Where(x => x.Nombre.ToLower().Contains(searchText)).ToList();
            else if(opcionSelected == 2)
                this.listCentros = searchItemsCentros.Where(x => x.Nombre.ToLower().Contains(searchText)).ToList();
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (opcionSelected == 1)
            {


                DetallesUnidadViewController detailUnidad = this.Storyboard.InstantiateViewController("detallesUnidad") as DetallesUnidadViewController;
                if (detailUnidad != null)
                {
                    detailUnidad.unidadSelected = listUnidades.ElementAt(indexPath.Row);
                    this.NavigationController.ShowViewController(detailUnidad, this);
                }
            }
            else if (opcionSelected == 2)
            {
                DetallesCentroViewController detailCentro = this.Storyboard.InstantiateViewController("detallesCentro") as DetallesCentroViewController;
                if (detailCentro != null)
                {
                    detailCentro.centroSelected = listCentros.ElementAt(indexPath.Row);
                    this.NavigationController.ShowViewController(detailCentro, this);
                }
            }
        }
    }
}