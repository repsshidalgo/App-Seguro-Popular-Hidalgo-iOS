using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class SintomaEmocionalTableViewCell : UITableViewCell
    {
        

        private string tipo;
		/// <summary>
		/// Obtiene o regresa el tipo de Sintoma emocional del usuario
		/// </summary>
		/// <value>The tipo.</value>
        public string Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                emocionSintomaEmocionalLabel.Text = tipo;


                switch (tipo)
                {
                    case "Asustado":
                        emocionImageView.Image = UIImage.FromBundle("Surprised");
                        break;
                    case "Cansado":
                        emocionImageView.Image = UIImage.FromBundle("Sleepy-02");
                        break;
                    case "Contento":
                        emocionImageView.Image = UIImage.FromBundle("Happy");
                        break;
                    case "Enojado":
                        emocionImageView.Image = UIImage.FromBundle("Angry-WF");
                        break;
                    case "Hambriento":
                        emocionImageView.Image = UIImage.FromBundle("Annoyed-WF");
                        break;
                    case "Triste":
                        emocionImageView.Image = UIImage.FromBundle("Sad-WF");
                        break;
                }
            }
        }
		/// <summary>
		/// Tipo de dato para fecha
		/// </summary>
        private string fecha;
		/// <summary>
		/// Obtiene o regresa la fecha que se seleccione o en la que se encuentre
		/// </summary>
		/// <value>The fecha.</value>
        public string Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                fechaSintomaEmocionalLabel.Text = fecha;
            }
        }

        public SintomaEmocionalTableViewCell (IntPtr handle) : base (handle)
        {
        }
    }
}