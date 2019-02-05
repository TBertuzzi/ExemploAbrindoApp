using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using ExemploAbrindoApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenAppAndroid))]
namespace ExemploAbrindoApp.Droid
{
    [Activity(Label = "OpenAppAndroid")]
    public class OpenAppAndroid : Activity, IAppHandler
    {
        public Task<bool> LaunchApp(string uri)
        {
            bool result = false;

            try
            {
                var aUri = Android.Net.Uri.Parse(uri.ToString());
                var intent = new Intent(Intent.ActionView, aUri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
                result = true;
            }
            catch (ActivityNotFoundException)
            {
                result = false;
            }

            return Task.FromResult(result);
        }
    }
}
