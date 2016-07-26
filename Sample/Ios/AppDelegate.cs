using Foundation;
using UIKit;

namespace RoxSample
{
    [Register("AppDelegate")]
    public partial class AppDelegate
        : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rox.VideoIos.Init();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new VideoApplication());

            return base.FinishedLaunching(app, options);
        }
    }
}