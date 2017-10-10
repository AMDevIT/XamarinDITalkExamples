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
using Xamarin_DIF.Hardware;
using Android.Hardware;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.Droid.Hardware.DroidSensors))]
namespace Xamarin_DIF.Droid.Hardware
{
    public class DroidSensors
        : SensorsBase
    {
        #region Fields

        private SensorManager sensorManager = null;
        private Sensor accelerometer = null;
        private Sensor gyroscope = null;
        private DroidSensorListener sensorListener = null;

        #endregion

        #region .ctor

        public DroidSensors()
        {
            this.sensorManager = Application.Context.GetSystemService(Context.SensorService) as SensorManager;
            this.sensorListener = new DroidSensorListener();
        }

        #endregion

        #region Methods

        public override bool Initialize(SensorTypes sensorTypes)
        {
            if (!this.Initialized)
            {
                // Accelerometer
                if (sensorTypes.HasFlag(SensorTypes.Accelerometer))                
                    this.accelerometer = this.sensorManager.GetDefaultSensor(SensorType.Accelerometer);
                // Gyroscope
                if (sensorTypes.HasFlag(SensorTypes.Gyroscope))
                    this.gyroscope = this.sensorManager.GetDefaultSensor(SensorType.Gyroscope);
                this.Initialized = true;
                return true;
            }
            return false;
        }

        public override void Start()
        {
            if (this.Initialized && this.Started == false)
            {
                try
                {
                    if (this.accelerometer != null)
                        this.sensorManager.RegisterListener(this.sensorListener, this.accelerometer, SensorDelay.Normal);
                    if (this.gyroscope != null)
                        this.sensorManager.RegisterListener(this.sensorListener, this.gyroscope, SensorDelay.Normal);
                    this.Started = true;
                }
                catch(Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.ToString());
                }
            }
        }

        public override void Stop()
        {
            if (this.Initialized && this.Started == true)
            {
                try
                {
                    if (this.accelerometer != null)
                        this.sensorManager.UnregisterListener(this.sensorListener, this.accelerometer);
                    if (this.gyroscope != null)
                        this.sensorManager.UnregisterListener(this.sensorListener, this.gyroscope);
                    this.Started = false;
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc.ToString());
                }
            }
        }

        #endregion
    }
}