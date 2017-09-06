using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware.BT
{
    public class DiscoveredDevicesChangedEventArgs
        : EventArgs
    {
        #region Properties

        public XMBluetoothDevice[] Devices
        {
            get;
            protected set;
        }

        #endregion

        #region .ctor

        public DiscoveredDevicesChangedEventArgs()
        {
            this.Devices = new XMBluetoothDevice[] { };
        }

        public DiscoveredDevicesChangedEventArgs(XMBluetoothDevice[] devices)
        {
            if (devices == null)
                throw new ArgumentNullException(nameof(devices));

            this.Devices = devices;
        }

        #endregion
    }
}
