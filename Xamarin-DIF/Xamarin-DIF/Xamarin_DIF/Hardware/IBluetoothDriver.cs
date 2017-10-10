using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF.Hardware
{
    public interface IBluetoothDriver
    {
        #region Properties

        BluetoothDriverStates DriverState
        {
            get;
        }

        #endregion

        #region Methods

        void Start();
        void Stop();

        #endregion
    }
}
