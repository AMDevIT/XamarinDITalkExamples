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

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.Droid.AndroidApplicationStateManager))]

namespace Xamarin_DIF.Droid
{
    public class AndroidApplicationStateManager
        : IApplicationStateManager
    {
        #region Properties

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
    }
}