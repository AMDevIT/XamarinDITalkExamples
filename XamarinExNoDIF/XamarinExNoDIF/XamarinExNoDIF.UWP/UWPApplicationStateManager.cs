using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF;
using XamarinExNoDIF.Hardware;
using XamarinExNoDIF.Storage;
using XamarinExNoDIF.UWP.Hardware;
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

        public override SensorsBase CreateSensorsDriver()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
