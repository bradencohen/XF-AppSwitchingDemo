using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public ICommand SwitchToSecondApp { get; }

        public AboutViewModel()
        {
            Title = "Switch to second app";
            SwitchToSecondApp = new Command( SwitchAppToSecondApp );
        }

        private void SwitchAppToSecondApp()
        {
            Device.BeginInvokeOnMainThread( () =>
            {
                AppState.Current.SwitchToSecondApp.Execute( null );
            } );
        }
    }
}