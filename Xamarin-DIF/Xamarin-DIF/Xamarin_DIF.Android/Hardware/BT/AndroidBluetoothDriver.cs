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
using Xamarin_DIF.Hardware.BT;

namespace Xamarin_DIF.Droid.Hardware.BT
{
    public class AndroidBluetoothDriver
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