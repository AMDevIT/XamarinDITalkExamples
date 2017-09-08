using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin_DIF.Hardware.BT;
using Xamarin_DIF.Storage;

namespace Xamarin_DIF
{
    public partial class App : Application
    {
        #region Fields

        private IApplicationStateManager applicationStateManager = null;
        private IBluetoothDriver bluetoothDriver = null;
        private ISettingsStorage settingsStorage = null;

        #endregion

        #region Properties

        public DateTime DependencyInitializationStart
        {
            get;
            private set;
        }

        public DateTime DependencyInitializationEnd
        {
            get;
            private set;
        }

        #endregion

        #region .ctor

        public App()
        {
            InitializeComponent();
            InitializeDependencies();

            MainPage = new Xamarin_DIF.MainPage();
        }

        #endregion

        #region Methods

        protected override void OnStart()
        {
            // Handle when your app starts
            this.InitializeDependencies();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void InitializeDependencies()
        {
            this.DependencyInitializationStart = DateTime.Now;

            this.applicationStateManager = DependencyService.Get<IApplicationStateManager>();
            this.bluetoothDriver = DependencyService.Get<IBluetoothDriver>();
            this.settingsStorage = DependencyService.Get<ISettingsStorage>();

            this.DependencyInitializationEnd = DateTime.Now;
        }

        #endregion
    }
}
