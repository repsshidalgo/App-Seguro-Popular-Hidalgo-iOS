using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public partial class PolizaViewController : UIViewController
    {

        UIScrollView scrollView;

        public PolizaViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var documentsDirectory = Environment.GetFolderPath
                                      (Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, "Poliza.jpg");

            scrollView = new UIScrollView(
                new CGRect(0, 0, View.Frame.Width
                , View.Frame.Height - NavigationController.NavigationBar.Frame.Height));
            View.AddSubview(scrollView);
            polizaImageView.Image = UIImage.FromFile(jpgFilename.ToString());
            scrollView.ContentSize = polizaImageView.Image.Size;
            scrollView.AddSubview(polizaImageView);
            scrollView.MaximumZoomScale = 2f;
            scrollView.MinimumZoomScale = 1f;
            scrollView.ViewForZoomingInScrollView += (UIScrollView sv) => { return polizaImageView; };

            UITapGestureRecognizer doubletap = new UITapGestureRecognizer(OnDoubleTap)
            {
                NumberOfTapsRequired = 2 // double tap
            };
            scrollView.AddGestureRecognizer(doubletap); // detect when the scrollView is double-tapped
        }

        private void OnDoubleTap(UIGestureRecognizer gesture)
        {
            if (scrollView.ZoomScale > 1)
                scrollView.SetZoomScale(1f, true);
            else
                scrollView.SetZoomScale(2f, true);
        }
    }
}