using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExemploAbrindoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void skypeForms_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Xamarin.Forms.Device.OpenUri(new Uri("skype://"));
            });
        }

        public async void dependencyService_Clicked(object sender, EventArgs e)
        {
            var appname = "skype://";
            var exists = await DependencyService.Get<IAppHandler>().LaunchApp(appname);

            //Você pode ver que existe e abrir a store correspondente
            if (!exists)
            {
                string url = Device.RuntimePlatform == Device.iOS ? "https://itunes.apple.com/br/app/skype-para-iphone/id304878510?mt=8" 
                : "https://play.google.com/store/apps/details?id=com.skype.raider&hl=pt_BR";
                Device.OpenUri(new Uri(url));
            }
        }

        public async void xamarinEssentials_Clicked(object sender, EventArgs e)
        {
            var appname = "skype://";
            var supportsUri = await Launcher.CanOpenAsync(appname);

            if (supportsUri)
                await Launcher.OpenAsync(appname);
        }


    }
}
