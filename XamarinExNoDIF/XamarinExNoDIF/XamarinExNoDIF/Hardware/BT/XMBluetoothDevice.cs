using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware.BT
{
    public class XMBluetoothDevice
    {
        #region Properties

        public string LocalName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public float RSSI
        {
            get;
            set;
        }

        public float Accuracy
        {
            get;
            set;
        }

        #endregion
    }
}
