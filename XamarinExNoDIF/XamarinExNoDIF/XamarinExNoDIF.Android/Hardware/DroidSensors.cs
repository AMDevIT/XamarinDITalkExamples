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
using XamarinExNoDIF.Hardware;

namespace XamarinExNoDIF.Droid.Hardware
{
    public class DroidSensors
        : SensorsBase
    {
        #region .ctor

        public DroidSensors()
            : base()
        {

        }

        public DroidSensors(bool enableAll)
            : base(enableAll)
        {

        }

        #endregion

        #region Methods

        public override void Start()
        {            
        }

        public override void Stop()
        {
        }

        #endregion
    }
}