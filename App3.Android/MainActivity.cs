using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using FFImageLoading.Forms.Platform;
using FFImageLoading;
using FFImageLoading.Config;
using Xamarin.Android.Net;
using System.Net.Http;
using System.Net;

namespace SimpleCommerce.Droid
{
    [Activity(Label = "App3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CachedImageRenderer.Init(true);
            ImageService.Instance.Initialize(
                new Configuration { 
                    HttpClient = new HttpClient(
                    new AndroidClientHandler() 
                    { 
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate, 
                    }) 
                });

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            CachedImageRenderer.InitImageViewHandler();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}