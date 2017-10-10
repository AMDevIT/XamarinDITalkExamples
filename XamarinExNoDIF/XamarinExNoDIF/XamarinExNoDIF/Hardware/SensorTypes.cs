using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware
{
    [Flags]
    public enum SensorTypes
    {
        None = 0,
        Accelerometer = 1,
        Gyroscope = 2
    }
}
