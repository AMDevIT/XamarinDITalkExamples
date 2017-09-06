using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExNoDIF.Common;

namespace XamarinExNoDIF.ViewModels
{
    public class MainPageViewModel
        : BindableBase
    {
        #region Fields

        private DateTime initStart = default(DateTime);
        private DateTime initEnd = default(DateTime);
        private String duration = String.Empty;

        #endregion

        #region Properties

        public DateTime InitStart
        {
            get
            {
                return this.initStart;
            }
            private set
            {
                this.SetProperty(ref this.initStart, value);
            }
        }

        public DateTime InitEnd
        {
            get
            {
                return this.initEnd;
            }
            private set
            {
                this.SetProperty(ref this.initEnd, value);
            }
        }

        #endregion
    }
}
