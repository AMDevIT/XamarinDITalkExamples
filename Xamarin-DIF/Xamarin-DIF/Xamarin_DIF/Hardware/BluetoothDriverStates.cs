using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF.Hardware
{    
    public enum BluetoothDriverStates
    {
        NotPresent = -1,
        Unknown = 0,
        Enabled = 1,
        Discovering = 2
    }
}
