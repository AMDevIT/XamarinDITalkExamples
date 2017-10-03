using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF.Hardware
{
    public abstract class SensorsBase
    {
        #region Fields

        private readonly Guid instanceID;
        protected string platform = String.Empty;

        #endregion

        #region Properties

        public Guid InstanceID
        {
            get
            {
                return this.instanceID;
            }
        }

        public String Platform
        {
            get
            {
                return this.platform;
            }
        }

        #endregion

        #region .ctor

        public SensorsBase()
        {
            this.instanceID = Guid.NewGuid();
        }

        #endregion
    }
}
