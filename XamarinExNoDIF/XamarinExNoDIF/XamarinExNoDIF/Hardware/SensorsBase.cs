using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware
{
    public abstract class SensorsBase
    {
        #region Fields

        private SensorTypes requestedSensors = SensorTypes.None;
        private bool initialized = false;
        private bool started = false;

        #endregion

        #region Properties

        public SensorTypes RequestedSensors
        {
            get
            {
                return this.requestedSensors;
            }
            protected set
            {
                this.requestedSensors = value;
            }
        }

        public bool Initialized
        {
            get
            {
                return this.initialized;
            }
            protected set
            {
                this.initialized = value;
            }
        }

        public bool Started
        {
            get
            {
                return this.started;
            }
            protected set
            {
                this.started = value;
            }
        }

        #endregion

        #region .ctor

        public SensorsBase()
        {
        }

        #endregion

        #region Methods
                
        public abstract void Start();
        public abstract void Stop();

        #endregion
    }
}
