using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.UWP
{
    public class UWPApplicationStateManagerInitializer
        : IApplicationStateManagerInitializer
    {
        #region Methods

        public ApplicationStateManagerBase CreatePlatformInstance()
        {
            ApplicationStateManagerBase platformApplicationStateManagerBase = new UWPApplicationStateManager();
            return platformApplicationStateManagerBase;
        }

        #endregion
    }
}
