using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_DIF.Hardware.BT;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.UWP.Hardware.BT.UWPBluetoothDriver))]
namespace Xamarin_DIF.UWP.Hardware.BT
{
    public class UWPBluetoothDriver
        : IBluetoothDriver
    {
        #region Properties

        public BluetoothDriverStates DriverState
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void Start()
        {            
        }

        public void Stop()
        {         
        }

        #endregion
    }
}
