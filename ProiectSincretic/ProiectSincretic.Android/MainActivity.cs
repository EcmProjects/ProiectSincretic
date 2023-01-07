using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Telephony.Data;
using System.Threading.Tasks;
using Xamarin.Essentials;
using AndroidX.Core.App;

namespace ProiectSincretic.Droid
{
    [Activity(Label = "ProiectSincretic", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            await Permisions();
            AppSettings.MainFolder = this.GetExternalFilesDir("").AbsolutePath;
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private static readonly string[] StoragePermissions =
        {
             Android.Manifest.Permission.WriteExternalStorage,
            Android.Manifest.Permission.ReadExternalStorage,
            Android.Manifest.Permission.ManageExternalStorage,
           
           
        };

        async Task<bool> Permisions()
        {
            try
            {
                Permission permission1 = ActivityCompat.CheckSelfPermission(Android.App.Application.Context, Android.Manifest.Permission.WriteExternalStorage);

                if (permission1 != Permission.Granted)
                {
                    // We don't have permission so prompt the user
                    ActivityCompat.RequestPermissions(this, StoragePermissions, 1001);
                    permission1 = ActivityCompat.CheckSelfPermission(Android.App.Application.Context, Android.Manifest.Permission.WriteExternalStorage);
                }


                while (true) 
                { 
                   await Task.Delay(100);

                    permission1 = ActivityCompat.CheckSelfPermission(Android.App.Application.Context, Android.Manifest.Permission.WriteExternalStorage);
                    if (permission1 == Permission.Granted)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                
            }
       

            return true;
        }
    }
}