using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware
{
    public abstract class BluetoothDriverBase
    {
        #region Events

        public event EventHandler<DiscoveredDevicesChangedEventArgs> DiscoveredDevicesChanged;

        #endregion

        #region Fields

        private readonly List<XMBluetoothDevice> bluetoothDevices = null;

        #endregion

        #region Properties

        public BluetoothDriverStates State
        {
            get;
            protected set;
        }

        #endregion

        #region .ctor

        public BluetoothDriverBase()
        {
            this.bluetoothDevices = new List<XMBluetoothDevice>();
        }

        #endregion

        #region Methods

        public abstract void Start();
        public abstract void Stop();

        protected void RaiseDiscoveredDevicesChanged()
        {
            DiscoveredDevicesChangedEventArgs eventArgs = null;

            if (this.DiscoveredDevicesChanged != null)
            {
                if (this.bluetoothDevices.Count == 0)
                    eventArgs = new DiscoveredDevicesChangedEventArgs();
                else
                    eventArgs = new DiscoveredDevicesChangedEventArgs(this.bluetoothDevices.ToArray());
                this.DiscoveredDevicesChanged(this, eventArgs);
            }
        }

        #endregion
    }
}
