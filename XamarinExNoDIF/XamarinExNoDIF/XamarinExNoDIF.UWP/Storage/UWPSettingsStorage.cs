using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF.UWP.Storage
{
    public class UWPSettingsStorage
        : SettingsStorageBase
    {
        #region Consts

        private const String CompositeStorageKey = "ApplicationSettings";

        #endregion

        #region Fields

        private readonly ApplicationDataContainer settingsDataContainer = null;

        #endregion

        #region .ctor

        public UWPSettingsStorage()
        {
            this.settingsDataContainer = ApplicationData.Current.LocalSettings;
        }

        #endregion

        #region Methods
        protected override int GetInt(string key)
        {
            int result = 0;
            ApplicationDataCompositeValue compositeValue = null;

            if (this.settingsDataContainer != null)
            {
                compositeValue = (ApplicationDataCompositeValue) this.settingsDataContainer.Values[CompositeStorageKey];
                if (compositeValue != null)
                    result = (int)compositeValue[key];
            }
            return result;
        }

        protected override string GetString(string key)
        {
            String result = null;
            ApplicationDataCompositeValue compositeValue = null;

            if (this.settingsDataContainer != null)
            {
                compositeValue = (ApplicationDataCompositeValue)this.settingsDataContainer.Values[CompositeStorageKey];
                if (compositeValue != null)
                    result = compositeValue[key] as String;
            }
            return result;
        }

        protected override void PutInt(string key, int value)
        {
            ApplicationDataCompositeValue compositeValue = null;
            if (this.settingsDataContainer.Values.ContainsKey(CompositeStorageKey))
                compositeValue = (ApplicationDataCompositeValue)this.settingsDataContainer.Values[CompositeStorageKey];
            else
            {
                compositeValue = new ApplicationDataCompositeValue();
                this.settingsDataContainer.Values[CompositeStorageKey] = compositeValue;
            }

            compositeValue[key] = value;
        }

        protected override void PutString(string key, string value)
        {
            ApplicationDataCompositeValue compositeValue = null;
            if (this.settingsDataContainer.Values.ContainsKey(CompositeStorageKey))
                compositeValue = (ApplicationDataCompositeValue)this.settingsDataContainer.Values[CompositeStorageKey];
            else
            {
                compositeValue = new ApplicationDataCompositeValue();
                this.settingsDataContainer.Values[CompositeStorageKey] = compositeValue;
            }

            compositeValue[key] = value;
        }
        #endregion
    }
}
