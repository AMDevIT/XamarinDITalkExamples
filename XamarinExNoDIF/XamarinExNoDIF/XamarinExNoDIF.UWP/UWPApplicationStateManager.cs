using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF;
using XamarinExNoDIF.Hardware.BT;
using XamarinExNoDIF.Storage;
using XamarinExNoDIF.UWP.Hardware.BT;
using XamarinExNoDIF.UWP.Storage;

namespace XamarinExNoDIF.UWP
{
    public class UWPApplicationStateManager
        : ApplicationStateManagerBase
    {
        #region Fields
               

        #endregion

        #region Methods        

        public override BluetoothDriverBase CreateBluetoothDriver()
        {
            return new UWPBluetoothDriver();
        }

        public override SettingsStorageBase CreateSettingsStorage()
        {
            return new UWPSettingsStorage();
        }

        #endregion
    }
}
