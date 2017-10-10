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

        public Guid[] Filter
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

        public BluetoothDriverBase(Guid[] filter)
            : this()
        {

        }

        #endregion

        #region Methods

        public abstract void Start();
        public abstract void Stop();
     
        #endregion
    }
}
