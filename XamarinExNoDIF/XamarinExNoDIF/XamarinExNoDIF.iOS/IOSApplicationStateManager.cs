using System;
using System.Collections.Generic;
using System.Text;
using XamarinExNoDIF.Hardware;
using XamarinExNoDIF.iOS.Hardware;
using XamarinExNoDIF.iOS.Storage;
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF.iOS
{
    public class IOSApplicationStateManager
        : ApplicationStateManagerBase
    {
        #region Methods

        public override BluetoothDriverBase CreateBluetoothDriver()
        {
            return this.CreateBluetoothDriver(null);
        }

        public override BluetoothDriverBase CreateBluetoothDriver(Guid[] filter)
        {
            IOSBluetoothDriver bluetoothDriver = null;

            if (filter == null)
                bluetoothDriver = new IOSBluetoothDriver();
            else
                bluetoothDriver = new IOSBluetoothDriver(filter);
            return bluetoothDriver;
        }

        public override SensorsBase CreateSensorsDriver()
        {
            return this.CreateSensorsDriver(SensorTypes.Accelerometer | SensorTypes.Gyroscope);
        }

        public override SensorsBase CreateSensorsDriver(SensorTypes sensorTypes)
        {
            IOSSensors sensors = new IOSSensors(sensorTypes);
            return sensors;
        }

        public override SettingsStorageBase CreateSettingsStorage()
        {
            IOSSettingsStorage settingsStorage = new IOSSettingsStorage();
            return settingsStorage;
        }

        #endregion
    }
}
