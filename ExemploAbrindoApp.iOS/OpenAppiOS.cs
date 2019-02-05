using System;
using System.Threading.Tasks;
using ExemploAbrindoApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenAppiOS))]
namespace ExemploAbrindoApp.iOS
{
    public class OpenAppiOS : IAppHandler
    {
        public Task<bool> LaunchApp(string uri)
        {
            try
            {
                var canOpen = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(uri));

                if (!canOpen)
                    return Task.FromResult(false);

                return Task.FromResult(UIApplication.SharedApplication.OpenUrl(new NSUrl(uri)));

            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

    }
}
