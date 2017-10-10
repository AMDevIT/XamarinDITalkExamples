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
using Android.Bluetooth.LE;

namespace Xamarin_DIF.Droid.Hardware
{
    public class DroidLEScannerCallback
        : ScanCallback
    {
        #region Methods

        public override void OnBatchScanResults(IList<ScanResult> results)
        {
            System.Diagnostics.Debug.WriteLine("Batch scan result received.");
        }

        public override void OnScanResult([GeneratedEnum] ScanCallbackType callbackType, ScanResult result)
        {
            System.Diagnostics.Debug.WriteLine("Scan result received.");
        }

        #endregion
    }
}