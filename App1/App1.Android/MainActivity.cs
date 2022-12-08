using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Rock.Mobile.Droid;
using Android.Content;

namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static SecondApp SecondAppToLoad { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate( savedInstanceState );

            // This causes Xamarin.Forms to track this activity and not the splash activity
            Forms.Init( this, savedInstanceState );
            Xamarin.Essentials.Platform.Init( this, savedInstanceState );

            AppState.Current.SwitchToSecondApp = new Command( SwitchToSecondApp );
            // load our new application
            LoadApplication( SplashActivity.ApplicationToLoad );
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Changes the server.
        /// </summary>
        private void SwitchToSecondApp()
        {
            var app = new SecondApp();
            // app.doWhatever() 
            SecondAppToLoad = app;

            StartActivity( new Intent( Android.App.Application.Context, typeof( SecondAppActivity ) ) );
            Finish();
        }
    }
}