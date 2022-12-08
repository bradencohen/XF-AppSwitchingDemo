using System;

using App1.Services;
using App1.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class SecondApp : Application
    {

        public SecondApp()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
