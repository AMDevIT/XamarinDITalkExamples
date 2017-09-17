using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF.Hardware.BT;
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF
{
    public abstract class ApplicationStateManagerBase
    {
        #region Fields
                
        private static ApplicationStateManagerBase current = null;
        
        #endregion

        #region Properties

        public static ApplicationStateManagerBase Current
        {
            get
            {
                return current;
            }
            private set
            {
                current = value;
            }
        }
      
        #endregion

        #region Methods

        public static ApplicationStateManagerBase InitializePlatformInstance(IApplicationStateManagerInitializer initializer)
        {
            ApplicationStateManagerBase applicationStateManagerBase = null;

            if (initializer == null)
                throw new ArgumentNullException(nameof(initializer));

            applicationStateManagerBase = initializer.CreatePlatformInstance();
            ApplicationStateManagerBase.Current = applicationStateManagerBase;
            return applicationStateManagerBase;
        }

        public abstract BluetoothDriverBase CreateBluetoothDriver();
        public abstract SettingsStorageBase CreateSettingsStorage();

        #endregion
    }
}
