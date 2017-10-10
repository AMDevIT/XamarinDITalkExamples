using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_DIF.Hardware;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.iOS.Hardware.IOSBluetoothDriver))]
namespace Xamarin_DIF.iOS.Hardware
{
    public class IOSBluetoothDriver
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
