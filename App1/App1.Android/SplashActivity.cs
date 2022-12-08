using System;
using System.Drawing;
using System.Threading;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;

using AndroidX.AppCompat.App;

using App1;
using App1.Droid;

using Xamarin.Essentials;

namespace Rock.Mobile.Droid
{
    [Activity( Label = "App1Splash", MainLauncher = true, Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class SplashActivity : AppCompatActivity
    {
        #region Properties

        public static bool FormsInitialized { get; private set; }

        /// <summary>
        /// Gets or sets the application to be loaded by <see cref="MainActivity"/>.
        /// </summary>
        /// <value>
        /// The application to be loaded by <see cref="MainActivity"/>.
        /// </value>
        public static App ApplicationToLoad { get; set; }

        #endregion

        #region Methods

        protected override void OnCreate( Bundle savedInstanceState )
        {
            base.OnCreate( savedInstanceState );

            // Ensure any existing application is cleared.
            if ( Xamarin.Forms.Application.Current != null )
            {
                if ( Xamarin.Forms.Application.Current is IDisposable disposable )
                {
                    disposable.Dispose();
                }

                Xamarin.Forms.Application.ClearCurrent();
            }

            //
            // Do one-time initialization.
            //
            if ( !FormsInitialized )
            {
                Xamarin.Forms.Forms.Init( this, savedInstanceState );

                // Custom plug-in initializers
                Xamarin.Essentials.Platform.Init( this.Application );
                FormsInitialized = true;
            }

            BeginAppStart();
        }

        private void BeginAppStart()
        {
            ThreadPool.QueueUserWorkItem( o =>
            {
                System.Threading.Tasks.Task.Run( () =>
                {
                    var app = new App();

                    // app.DoWhatever();

                    ApplicationToLoad = app;
                    AppState.Current = new AppState();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread( () =>
                    {
                        var mainIntent = new Intent( Application.Context, typeof( MainActivity ) );

                        mainIntent.AddFlags( ActivityFlags.NoAnimation );

                        StartActivity( mainIntent );
                        OverridePendingTransition( 0, 0 );
                        Finish();
                    } );
                } );
            } );
        }

        #endregion
    }
}