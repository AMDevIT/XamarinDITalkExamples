using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF;
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

        public override void InitializeApplicationServices()
        {
            this.bluetoothDriverBase = new UWPBluetoothDriver();
            this.settings = new UWPSettingsStorage();
        }

        #endregion
    }
}
