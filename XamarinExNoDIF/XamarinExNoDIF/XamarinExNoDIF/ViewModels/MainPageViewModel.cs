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
        private string duration = String.Empty;

        #endregion

        #region Properties

        public DateTime InitStart
        {
            get
            {
                return this.initStart;
            }
            protected set
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
            protected set
            {
                this.SetProperty(ref this.initEnd, value);
            }
        }

        public String Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                this.SetProperty(ref this.duration, value);
            }
        }

        #endregion

        #region .ctor

        public MainPageViewModel()
        {
            App currentApp = App.Current as App;
            TimeSpan durationSpan = TimeSpan.Zero;

            this.InitStart = ApplicationStateManagerBase.Current.InitStart;
            this.InitEnd = ApplicationStateManagerBase.Current.InitEnd;
            this.Duration = ApplicationStateManagerBase.Current.Duration;
        }

        #endregion

        #region Methods

        #endregion
    }
}
