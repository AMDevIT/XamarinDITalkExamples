using CoreMotion;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinExNoDIF.Hardware;

namespace XamarinExNoDIF.iOS.Hardware
{
    public class IOSSensors
        : SensorsBase
    {
        #region Fields

        private CMMotionManager motionManager = null;
        private NSOperationQueue queue = null;
        private bool gyroStarted = false;
        private bool accelerometerStarted = false;

        #endregion

        #region .ctor

        public IOSSensors(SensorTypes sensorTypes)
        {
            motionManager = new CMMotionManager();            
            this.queue = new NSOperationQueue();
            this.RequestedSensors = sensorTypes;
        }

        #endregion

        #region Methods
        
        public override void Start()
        {
            if (this.Started == false)
            {
                if (this.RequestedSensors.HasFlag(SensorTypes.Accelerometer) && this.motionManager.AccelerometerAvailable)
                {
                    this.motionManager.StartAccelerometerUpdates(this.queue, (CMAccelerometerData accelerometerData, NSError error) =>
                    {

                    });
                    this.accelerometerStarted = true;
                }

                if (this.RequestedSensors.HasFlag(SensorTypes.Gyroscope) && this.motionManager.GyroAvailable)
                {
                    this.motionManager.StartGyroUpdates(this.queue, (CMGyroData gyroData, NSError error) =>
                    {

                    });
                    this.gyroStarted = true;
                }

                this.Started = true;
            }
        }

        public override void Stop()
        {
            if (this.Started)
            {
                if (this.accelerometerStarted)
                {
                    this.motionManager.StopAccelerometerUpdates();
                    this.accelerometerStarted = false;
                }

                if (this.gyroStarted)
                {
                    this.motionManager.StopGyroUpdates();
                    this.gyroStarted = false;
                }
                this.Started = false;
            }
        }

        #endregion
    }
}
