using AudioToolbox;
using Foundation;
using System;
using UIKit;
using UserNotifications;
using WindowsAzure.Messaging;
using ObjCRuntime;

namespace AppSeguroPopularHidalgo.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window
		{
			get;
			set;
		}

		public UIStoryboard MainStoryboard
		{
			get { return UIStoryboard.FromName("MainUniversal", NSBundle.MainBundle); }
		}

		//Creates an instance of viewControllerName from storyboard
		public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
		{
			return storyboard.InstantiateViewController(viewControllerName);
		}


		public void SetRootViewController(UIViewController rootViewController, bool animate)
		{
			if (animate)
			{
				var transitionType = UIViewAnimationOptions.TransitionFlipFromRight;

				Window.RootViewController = rootViewController;
				UIView.Transition(Window, 0.5, transitionType,
								  () => Window.RootViewController = rootViewController,
								  null);
			}
			else
			{
				Window.RootViewController = rootViewController;
			}
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{

			var plist = NSUserDefaults.StandardUserDefaults;

			if (plist.BoolForKey("userLogin"))
			{
				//We are already authenticated, so go to the main tab bar controller;
				var tabBarController = GetViewController(MainStoryboard, "usuarioStoryBoard");

				SetRootViewController(tabBarController, false);
			}
			else
			{
				//User needs to log in, so show the Login View Controlller
				var loginViewController = GetViewController(MainStoryboard, "MainNavigation");
				SetRootViewController(loginViewController, false);
			}

			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
				UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
				new NSSet());

				UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
				UIApplication.SharedApplication.RegisterForRemoteNotifications();
			}
			else
			{
				UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
			}

			//UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();



			return true;
		}

		void LoginViewController_OnLoginSuccess(object sender, EventArgs e)
		{
			//We have successfully Logged In
			var tabBarController = GetViewController(MainStoryboard, "MainTabBarController");
			SetRootViewController(tabBarController, true);
		}


		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			TokenRegistration token = new TokenRegistration();
			token.Token = deviceToken;
		}

		/*public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {

            ProcessNotification(userInfo, false);
        }*/


		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			if (application.ApplicationState == UIApplicationState.Active)
			{
				ProcessNotification(userInfo, false);
			}
			else
			{
				ProcessNotification(userInfo, true);
			}
		}


		void ProcessNotification(NSDictionary options, bool fromFinishedLaunching)
		{
			// Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
			if (null != options && options.ContainsKey(new NSString("aps")))
			{
				//Get the aps dictionary
				NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;

				string alert = string.Empty;
				string titulo = string.Empty;

				//Extract the alert text
				// NOTE: If you're using the simple alert by just specifying
				// "  aps:{alert:"alert msg here"}  ", this will work fine.
				// But if you're using a complex alert with Localization keys, etc.,
				// your "alert" object from the aps dictionary will be another NSDictionary.
				// Basically the JSON gets dumped right into a NSDictionary,
				// so keep that in mind.
				if (aps.ContainsKey(new NSString("alert")))
				{
					alert = (aps[new NSString("alert")] as NSString).ToString();
					titulo = (aps[new NSString("title")] as NSString).ToString();
				}


				//If this came from the ReceivedRemoteNotification while the app was running,
				// we of course need to manually process things like the sound, badge, and alert.
				if (!fromFinishedLaunching)
				{

					UIAlertView avAlert = new UIAlertView("Notificación", alert, null, null, null);
					avAlert.AddButton("Ver detalles");
					avAlert.AddButton("Cancelar");
					avAlert.Show();

					avAlert.Clicked += (sender, args) =>
					{
						if (args.ButtonIndex == 0)
						{
							var storyboard = UIStoryboard.FromName("MainUniversal", null);
							var viewControllerActual = this.Window.RootViewController;
							while (viewControllerActual.PresentedViewController != null)
							{
								viewControllerActual = viewControllerActual.PresentedViewController;
							}
							NotificacionViewController notificacion = storyboard.InstantiateViewController("NotificacionView") as NotificacionViewController;
							if (notificacion != null)
							{
								notificacion.titulos = titulo;
								notificacion.descripciones = alert;
								viewControllerActual.ShowViewController(notificacion, viewControllerActual);
							}
						}
					};
				}
				else
				{

					var storyboard = UIStoryboard.FromName("MainUniversal", null);
					var viewControllerActual = this.Window.RootViewController;
					while (viewControllerActual.PresentedViewController != null)
					{
						viewControllerActual = viewControllerActual.PresentedViewController;
					}
					NotificacionViewController notificacion = storyboard.InstantiateViewController("NotificacionView") as NotificacionViewController;
					if (notificacion != null)
					{
						notificacion.titulos = titulo;
						notificacion.descripciones = alert;
						viewControllerActual.ShowViewController(notificacion, viewControllerActual);
					}
					//NotificacionViewController.titulo = alert;
					//NotificacionViewController.descripcion = alert;
					//try
					//{
					//    viewControllerActual.PresentViewController(storyboard.InstantiateViewController("NavigationNotification"), true, null);
					//}
					//catch (Exception ex)
					//{

					//}

				}

			}
		}


	}
}


