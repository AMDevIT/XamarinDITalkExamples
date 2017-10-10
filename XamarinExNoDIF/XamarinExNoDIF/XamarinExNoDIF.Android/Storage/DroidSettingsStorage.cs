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
using XamarinExNoDIF.Storage;

namespace XamarinExNoDIF.Droid.Storage
{
    public class DroidSettingsStorage
        : SettingsStorageBase
    {
        #region Methods

        protected override int GetInt(string key)
        {
            throw new NotImplementedException();
        }

        protected override string GetString(string key)
        {
            throw new NotImplementedException();
        }

        protected override void PutInt(string key, int value)
        {
            throw new NotImplementedException();
        }

        protected override void PutString(string key, string value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}