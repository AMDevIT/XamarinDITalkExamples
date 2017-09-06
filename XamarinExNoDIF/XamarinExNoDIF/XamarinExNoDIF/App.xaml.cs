using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinExNoDIF
{
    public partial class App : Application
    {
        #region Fields
               

        #endregion

        #region .ctor

        public App()
        {
            InitApplication();
        }

        public App(IApplicationStateManagerInitializer applicationStateInitializer)
            
        {
            InitializeDependencies(applicationStateInitializer);
            InitApplication();
        }

        #endregion

        #region Methods

        private void InitApplication()
        {
            InitializeComponent();
            MainPage = new XamarinExNoDIF.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeDependencies(IApplicationStateManagerInitializer applicationStateManagerInitializer)
        {
            DateTime initStart = default(DateTime);
            DateTime initEnd = default(DateTime);
            TimeSpan durationSpan = TimeSpan.Zero;
            String duration = null;

            if (applicationStateManagerInitializer == null)
                throw new ArgumentNullException(nameof(applicationStateManagerInitializer));
            initStart = DateTime.Now;
            ApplicationStateManagerBase.InitializePlatformInstance(applicationStateManagerInitializer);
            ApplicationStateManagerBase.Current.InitializeApplicationServices();
            initEnd = DateTime.Now;
            durationSpan = initEnd - initStart;
            duration = durationSpan.ToString();
            ApplicationStateManagerBase.Current.InitStart = initStart;
            ApplicationStateManagerBase.Current.InitEnd = initStart;
            ApplicationStateManagerBase.Current.Duration = duration;
        }

        #endregion
    }
}
