using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.iOS.IOSApplicationStateManager))]
namespace Xamarin_DIF.iOS
{    
    public class IOSApplicationStateManager
        : IApplicationStateManager
    {
        #region Properties

        public string DeviceID
        {
            get;
            private set;
        }

        public String Description
        {
            get;
            private set;
        }

        public int StateID
        {
            get;
            private set;
        }

        #endregion

        #region .ctor

        public IOSApplicationStateManager()            
        {
            this.DeviceID = this.GetDeviceID();
        }

        #endregion

        #region Methods

        private String GetDeviceID()
        {
            String deviceID = null;

            deviceID = UIDevice.CurrentDevice.IdentifierForVendor.AsString();            
            return deviceID;
        }

        #endregion
    }
}
