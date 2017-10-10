using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF.Hardware;

namespace XamarinExNoDIF.UWP.Hardware
{
    public class UWPSensors
        : SensorsBase
    {
        #region .ctor

        public UWPSensors()
            : base()
        {

        }

        public UWPSensors(bool enableAll)
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
