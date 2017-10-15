using AppSeguroPopularHidalgo.Model;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.iOS.Azure
{
    public class MobileAppConnection
    {
        public static MobileServiceClient client = new MobileServiceClient("https://seguropopularapplication.azurewebsites.net");

        public MobileAppConnection()
        {
            CurrentPlatform.Init();
        }

        public static async Task<IEnumerable<Notificaciones>> GetAllNotifications()
        {
            var plist = NSUserDefaults.StandardUserDefaults;

            var lista = await client.GetTable<Notificaciones>().Where(x => (x.Perfil == plist.StringForKey("userFolio") || x.Perfil == plist.StringForKey("userTag"))).ToListAsync();

            return lista;
        }
    }
}
