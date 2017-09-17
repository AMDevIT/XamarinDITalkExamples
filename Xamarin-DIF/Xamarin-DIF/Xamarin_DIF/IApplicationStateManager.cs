using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF
{
    public interface IApplicationStateManager
    {
        #region Properties

        // Current device hardware identification string
        string DeviceID
        {
            get;
        }

        // Current application state description
        String Description
        {
            get;            
        }

        // Current application state ID
        int StateID
        {
            get;
        }

        #endregion
    }
}
