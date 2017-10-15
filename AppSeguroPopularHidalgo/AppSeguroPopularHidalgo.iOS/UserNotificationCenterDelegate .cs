using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using UserNotifications;

namespace AppSeguroPopularHidalgo.iOS
{
    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {

        #region Constructors
        public UserNotificationCenterDelegate()
        {
            
        }
        #endregion

        #region Override Methods
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do something with the notification
            Console.WriteLine("Active Notification: {0}", notification);

            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
        #endregion

        #region Override Methods
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            // Take action based on Action ID
            switch (response.ActionIdentifier)
            {
                case "reply":
                    // Do something
                    break;
                default:

                    string identifier = response.ActionIdentifier;
                    // Take action based on identifier
                    if (response.IsDefaultAction)
                    {

                        var storyboard = UIStoryboard.FromName("Main", null);

                        NotificacionViewController notificacion = storyboard.InstantiateViewController("NotificacionView") as NotificacionViewController;
                        if (notificacion != null)
                        {
                            NotificacionViewController.titulo = response.Description;
                            NotificacionViewController.descripcion = Description;
                            notificacion.ShowViewController(notificacion, this);
                        }
                    }
                    else if (response.IsDismissAction)
                    {
                        // Handle dismiss action
                    }
                    break;
            }

            // Inform caller it has been handled
            completionHandler();
        }
        #endregion

    }
}
