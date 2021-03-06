﻿using System;
using XamarinExNoDIF.Droid.Hardware;
using XamarinExNoDIF.Droid.Storage;
using XamarinExNoDIF.Hardware;
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF.Droid
{
    public class DroidApplicationStateManager
        : ApplicationStateManagerBase
    {
        #region Methods

        public override BluetoothDriverBase CreateBluetoothDriver()
        {
            return this.CreateBluetoothDriver(null);
        }

        public override BluetoothDriverBase CreateBluetoothDriver(Guid[] filter)
        {
            DroidBluetoothDriver bluetoothDriver = null;

            if (filter == null)
                bluetoothDriver = new DroidBluetoothDriver();
            else
                bluetoothDriver = new DroidBluetoothDriver(filter);
            return bluetoothDriver;
        }

        public override SettingsStorageBase CreateSettingsStorage()
        {
            DroidSettingsStorage settingsStorage = new DroidSettingsStorage();
            return settingsStorage;
        }

        public override SensorsBase CreateSensorsDriver()
        {
            return this.CreateSensorsDriver(SensorTypes.Accelerometer | SensorTypes.Gyroscope);
        }        

        public override SensorsBase CreateSensorsDriver(SensorTypes sensorTypes)
        {
            DroidSensors droidSensors = new DroidSensors(sensorTypes);
            return droidSensors;
        }

        #endregion
    }
}