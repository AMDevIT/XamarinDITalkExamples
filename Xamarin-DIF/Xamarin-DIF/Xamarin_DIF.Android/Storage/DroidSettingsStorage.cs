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
using Xamarin_DIF.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.Droid.Storage.DroidSettingsStorage))]
namespace Xamarin_DIF.Droid.Storage
{
    public class DroidSettingsStorage
        : SettingsStorageBase
    {
        #region Consts

        private const string PreferencesFileName = "XamarinDIFDemo.pref";

        #endregion 

        #region Fields

        private ISharedPreferences sharedPreferences = null;

        #endregion

        #region .ctor

        public DroidSettingsStorage()
            : base()
        {
            try
            {
                this.sharedPreferences = Application.Context.GetSharedPreferences(PreferencesFileName, FileCreationMode.Private);
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        #endregion

        #region Methods

        protected override int GetInt(string key)
        {
            int result = 0;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.sharedPreferences != null)
                result = this.sharedPreferences.GetInt(key, 0);

            return result;
        }

        protected override void PutInt(string key, int value)
        {
            ISharedPreferencesEditor preferencesEditor = null;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.sharedPreferences != null)
            {
                preferencesEditor = this.sharedPreferences.Edit();
                preferencesEditor.PutInt(key, value);
                preferencesEditor.Commit();
                preferencesEditor.Dispose();
                preferencesEditor = null;
            }
        }

        protected override string GetString(string key)
        {
            string result = null;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.sharedPreferences != null)
                result = this.sharedPreferences.GetString(key, null);

            return result;
        }

        protected override void PutString(string key, string value)
        {
            ISharedPreferencesEditor preferencesEditor = null;

            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (this.sharedPreferences != null)
            {
                preferencesEditor = this.sharedPreferences.Edit();
                preferencesEditor.PutString(key, value);
                preferencesEditor.Commit();
                preferencesEditor.Dispose();
                preferencesEditor = null;
            }
        }

        #endregion
    }
}