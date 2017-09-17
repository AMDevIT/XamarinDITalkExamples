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
using Xamarin_DIF;
using static Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.Droid.AndroidApplicationStateManager))]

namespace Xamarin_DIF.Droid
{
    public class AndroidApplicationStateManager
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

        public AndroidApplicationStateManager()
        {
            this.DeviceID = this.GetDeviceID();
        }

        #endregion

        #region Methods

        private String GetDeviceID()
        {
            String result = null;
            String deviceID = null;

            deviceID = Secure.GetString(Application.Context.ContentResolver, Secure.AndroidId);
            if (String.IsNullOrEmpty(deviceID))
                deviceID = Build.Serial;
            result = deviceID + "_" + Build.Manufacturer + "_" + Build.Model;
            return result;
        }

        #endregion
    }
}