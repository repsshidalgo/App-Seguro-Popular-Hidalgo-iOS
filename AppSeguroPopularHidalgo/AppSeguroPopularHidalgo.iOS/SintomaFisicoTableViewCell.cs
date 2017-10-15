using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomaFisicoTableViewCell : UITableViewCell
    {
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                descripcionSintomaFisicoLabel.Text = descripcion;
            }
        }

        private string intensidad;

        public string Intensidad
        {
            get { return intensidad; }
            set
            {
                intensidad = value;
                intensidadSintomaFisicoLabel.Text = intensidad;
                

                switch (intensidad)
                {
                    case "Sin Dolor":
						intensidadImageView.Image = UIImage.FromBundle("Happy");
                        break;
                    case "Dolor Leve":
                        intensidadImageView.Image = UIImage.FromBundle("Smile");
                        break;
                    case "Dolor Moderado":
                        intensidadImageView.Image = UIImage.FromBundle("Sad");
                        break;
                    case "Dolor Severo":
                        intensidadImageView.Image = UIImage.FromBundle("Worried");
                        break;
                    case "Dolor Muy Severo":
                        intensidadImageView.Image = UIImage.FromBundle("Cry-WF");
                        break;
                    case "Máximo Dolor":
                        intensidadImageView.Image = UIImage.FromBundle("Cry");
                        break;
                }
            }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                fechaSintomaFisicoLabel.Text = fecha;
            }
        }
        public SintomaFisicoTableViewCell (IntPtr handle) : base (handle)
        {
        }
    }
}