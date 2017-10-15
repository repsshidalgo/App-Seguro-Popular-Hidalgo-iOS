using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace AppSeguroPopularHidalgo.iOS
{
    public static class Camera
    {    //variable para imagen
        static UIImagePickerController picker;
        static Action<NSDictionary> _callback;

        static void Init()
        {
            if (picker != null)
                return;

            picker = new UIImagePickerController();
            picker.Delegate = new CameraDelegate();
        }

		//hace la llamada a la camara del dispositivo

        class CameraDelegate : UIImagePickerControllerDelegate
        {
            public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
            {
                var cb = _callback;
                _callback = null;

                picker.DismissModalViewController(true);
                cb(info);
            }
        }

        public static void TakePicture(UIViewController parent, Action<NSDictionary> callback)
        {
            Init();
            picker.SourceType = UIImagePickerControllerSourceType.Camera;
            _callback = callback;
            try
            {
                parent.PresentModalViewController(picker, true);
            }
            catch (Exception ex)
            {
            }
        }

        public static void SelectPicture(UIViewController parent, Action<NSDictionary> callback)
        {
            Init();
            picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            _callback = callback;
            parent.PresentModalViewController(picker, true);
        }
    }
}
