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

        protected BluetoothDriverBase bluetoothDriverBase = null;
        protected SettingsStorageBase settings = null;
        
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

        #region Properties

        public DateTime InitStart
        {
            get;
            set;
        }

        public DateTime InitEnd
        {
            get;
            set;
        }

        public String Duration
        {
            get;
            set;
        }

        #endregion

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

        public abstract void InitializeApplicationServices();

        #endregion
    }
}
