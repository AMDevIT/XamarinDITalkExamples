using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_DIF.Hardware;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.iOS.Hardware.IOSSensors))]
namespace Xamarin_DIF.iOS.Hardware
{
    public class IOSSensors
        : SensorsBase
    {
        #region .ctor

        public IOSSensors()
        {
        }

        #endregion

        #region Methods

        public override bool Initialize(SensorTypes sensorTypes)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
