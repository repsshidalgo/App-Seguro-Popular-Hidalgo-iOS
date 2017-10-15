using System;
using AppSeguroPopularHidalgo.Model;
using Foundation;

namespace AppSeguroPopularHidalgo.iOS
{
	public class ConfiguracionApp
	{
		public ConfiguracionApp()
		{


		}

		public void GuardarConfiguracion(Afiliado afiliado)
		{
			var plist = NSUserDefaults.StandardUserDefaults;
			plist.SetBool(true, "userLogin");
			plist.SetString(afiliado.status, "userStatus");
			plist.SetString(afiliado.folio, "userFolio");
			plist.SetString(afiliado.consecutivo, "userConsecutivo");
			plist.SetString(afiliado.nombres, "userNombres");
			plist.SetString(afiliado.apellidoPaterno, "userApellidoPaterno");
			plist.SetString(afiliado.apellidoMaterno, "userApellidoMaterno");
			plist.SetString(afiliado.CURP, "userCURP");
			plist.SetString(afiliado.fechaVencimiento, "userFechaVencimiento");
			plist.SetString(afiliado.dependenciaSalud, "userUnidadSalud");
			plist.SetString(afiliado.CLUES, "userCLUES");
			plist.SetBool(false, "userMensaje");
			plist.SetString(afiliado.sexo, "userSexo");
			plist.SetString(afiliado.edad, "userEdad");
			if (Int32.Parse(afiliado.edad) >= 10 && Int32.Parse(afiliado.edad) < 19)
			{
				plist.SetString("Adolescente", "userTag");
			}
			else if (Int32.Parse(afiliado.edad) >= 19 && Int32.Parse(afiliado.edad) < 59)
			{
				if (afiliado.sexo.Equals("Hombre"))
				{
					plist.SetString("AdultoHombre", "userTag");
				}
				else
				{
					plist.SetString("AdultoMujer", "userTag");
				}
			}
			else if (Int32.Parse(afiliado.edad) >= 60)
			{
				plist.SetString("AdultoMayor", "userTag");
			}


		}

		public void LimpiarConfiguracion()
		{
			var plist = NSUserDefaults.StandardUserDefaults;
			plist.SetBool(false, "userLogin");
			plist.SetString("", "userStatus");
			plist.SetString("", "userFolio");
			plist.SetString("", "userConsecutivo");
			plist.SetString("", "userNombres");
			plist.SetString("", "userApellidoPaterno");
			plist.SetString("", "userApellidoMaterno");
			plist.SetString("", "userCURP");
			plist.SetString("", "userFechaVencimiento");
			plist.SetString("", "userUnidadSalud");
			plist.SetString("", "userCLUES");
			plist.SetBool(false, "userMensaje");
			plist.SetString("", "userSexo");
			plist.SetString("", "userEdad");
			plist.SetString("", "userTag");



		}
	}
}