using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_DIF.Common;

namespace Xamarin_DIF.ViewModels
{
    public class MainPageViewModel
        : BindableBase
    {
        #region Consts

        private const string DateTimeFormatString = "HH:mm:ss, FFFF";

        #endregion

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

        public String FormattedInitStart
        {
            get
            {
                String result = null;

                result = this.initStart.ToString(DateTimeFormatString);
                return result;
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

        public String FormattedInitEnd
        {
            get
            {
                String result = null;

                result = this.initEnd.ToString(DateTimeFormatString);
                return result;
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

            this.InitStart = currentApp.DependencyInitializationStart;
            this.InitEnd = currentApp.DependencyInitializationEnd;
            this.Duration = this.SetDuration();
        }

        #endregion

        #region Methods

        private String SetDuration()
        {
            TimeSpan durationSpan = TimeSpan.Zero;
            String result = null;

            durationSpan = this.InitEnd - this.InitStart;            
            result = durationSpan.TotalMilliseconds.ToString() + " milliseconds";            
            return result;
        }

        #endregion
    }
}
