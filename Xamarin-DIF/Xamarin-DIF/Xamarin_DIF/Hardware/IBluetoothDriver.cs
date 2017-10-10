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

        Guid[] Filter
        {
            get;
        }

        #endregion

        #region Methods

        void InitFilter(Guid[] filter);
        void Start();
        void Stop();

        #endregion
    }
}
