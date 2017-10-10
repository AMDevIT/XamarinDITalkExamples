using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF.iOS.Storage
{
    public class IOSSettingsStorage
        : SettingsStorageBase
    {
        #region Fields

        private NSUserDefaults userDefaults = null;

        #endregion 

        #region .ctor

        public IOSSettingsStorage()
            : base()
        {
            this.userDefaults = new NSUserDefaults();
        }

        #endregion

        #region Methods

        protected override int GetInt(string key)
        {
            int result = 0;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.userDefaults != null)
                result = (int)this.userDefaults.IntForKey(key);

            return result;
        }

        protected override string GetString(string key)
        {
            string result = null;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.userDefaults != null)
                result = this.userDefaults.StringForKey(key);

            return result;
        }

        protected override void PutInt(string key, int value)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.userDefaults != null)
                this.userDefaults.SetInt(value, key);
        }

        protected override void PutString(string key, string value)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.userDefaults != null)
                this.userDefaults.SetString(value, key);
        }

        #endregion
    }
}
