using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinExNoDIF.Hardware;
using XamarinExNoDIF.Storage;
using XamarinExNoDIF.Droid.Hardware;
using XamarinExNoDIF.Droid.Storage;
using XamarinExNoDIF.Hardware;

namespace XamarinExNoDIF.Droid
{
    public class DroidApplicationStateManager
        : ApplicationStateManagerBase
    {
        #region Methods

        public override BluetoothDriverBase CreateBluetoothDriver()
        {
            DroidBluetoothDriver bluetoothDriver = new DroidBluetoothDriver();
            return bluetoothDriver;
        }

        public override SettingsStorageBase CreateSettingsStorage()
        {
            DroidSettingsStorage settingsStorage = new DroidSettingsStorage();
            return settingsStorage;
        }

        public override SensorsBase CreateSensorsDriver()
        {
            DroidSensors droidSensors = new DroidSensors(true);
            return droidSensors;
        }

        #endregion
    }
}