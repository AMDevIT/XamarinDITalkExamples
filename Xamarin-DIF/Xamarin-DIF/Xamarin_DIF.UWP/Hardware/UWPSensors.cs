using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_DIF.Hardware;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.UWP.Hardware.UWPSensors))]
namespace Xamarin_DIF.UWP.Hardware
{
    

    public class UWPSensors
        : SensorsBase
    {
        #region Methods

        public UWPSensors()
        {
            this.platform = "UWP";
        }

        #endregion
    }
}
