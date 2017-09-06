using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware.BT
{
    public enum BluetoothDriverStates
    {
        Error = -1,
        Unknown = 0,
        NotPresent = 1,
        Enabled = 2,
        Discovering = 3
    }
}
