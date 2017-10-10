using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.iOS.IOSApplicationStateManager))]
namespace Xamarin_DIF.iOS
{    
    public class IOSApplicationStateManager
        : IApplicationStateManager
    {
        #region Properties

        public string DeviceID => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int StateID => throw new NotImplementedException();

        #endregion
    }
}
