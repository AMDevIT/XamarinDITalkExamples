using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF.Storage
{
    public interface ISettingsStorage
    {
        #region Properties

        string DeviceID
        {
            get;
            set;
        }

        #endregion
    }
}
