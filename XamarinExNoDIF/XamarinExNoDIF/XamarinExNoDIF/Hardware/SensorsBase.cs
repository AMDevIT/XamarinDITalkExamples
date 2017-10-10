using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExNoDIF.Hardware
{
    public abstract class SensorsBase
    {
        #region Properties

        public bool EnableAll
        {
            get;
            set;
        }

        #endregion

        #region .ctor

        public SensorsBase()
            : this(false)
        {

        }

        public SensorsBase(bool enableAll)
        {
            this.EnableAll = enableAll;
        }

        #endregion

        #region Methods

        public abstract void Start();
        public abstract void Stop();

        #endregion
    }
}
