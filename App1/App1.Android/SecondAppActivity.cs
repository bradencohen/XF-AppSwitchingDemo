using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Rock.Mobile.Droid;

namespace App1.Droid
{
    [Activity( Label = "App2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class SecondAppActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate( Bundle savedInstanceState )
        {
            base.OnCreate( savedInstanceState );

            // This causes Xamarin.Forms to track this activity and not the splash activity
            Forms.Init( this, savedInstanceState );

            Xamarin.Essentials.Platform.Init( this, savedInstanceState );

            // load our new application
            LoadApplication( MainActivity.SecondAppToLoad );
        }

        public override void OnRequestPermissionsResult( int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults )
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult( requestCode, permissions, grantResults );

            base.OnRequestPermissionsResult( requestCode, permissions, grantResults );
        }
    }
}