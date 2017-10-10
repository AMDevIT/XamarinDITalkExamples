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
using Android.Hardware;

namespace XamarinExNoDIF.Droid.Hardware
{
    public class DroidSensorListener
        : Java.Lang.Object, ISensorEventListener
    {
        #region Methods

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
        }

        #endregion
    }
}