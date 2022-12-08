using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1
{
    public class AppState
    {
        public static AppState Current { get; set; }

        public ICommand SwitchToSecondApp { get; set; }
    }
}
