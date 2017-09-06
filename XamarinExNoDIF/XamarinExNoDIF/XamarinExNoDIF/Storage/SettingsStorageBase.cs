using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Storage
{
    public abstract class SettingsStorageBase
    {
        #region Consts

        public const string DeviceIDKey = "DeviceID";

        #endregion

        #region Properties

        public string DeviceID
        {
            get
            {
                string result = null;

                result = this.GetString(DeviceIDKey);
                return result;
            }
            set
            {
                this.PutString(DeviceIDKey, value);
            }
        }

        #endregion

        #region Methods

        protected abstract String GetString(string key);
        protected abstract void PutString(string key, string value);

        protected abstract int GetInt(string key);
        protected abstract void PutInt(string key, int value);

        #endregion
    }
}
