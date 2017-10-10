using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin_DIF.Hardware;
using Xamarin_DIF.Storage;

namespace Xamarin_DIF
{
    public partial class App : Application
    {
        #region Fields

        private IApplicationStateManager applicationStateManager = null;
        private IBluetoothDriver bluetoothDriver = null;
        private ISettingsStorage settingsStorage = null;
        private SensorsBase sensors = null;

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

            // Get the bluetooth LE instance for peripherals discovery.

            this.bluetoothDriver = DependencyService.Get<IBluetoothDriver>();
            this.bluetoothDriver.Start();

            // Get the storage istance for app settings.

            this.settingsStorage = DependencyService.Get<ISettingsStorage>();            

            // Get the motion sensors.

            this.sensors = DependencyService.Get<SensorsBase>();
            this.sensors.Initialize(SensorTypes.Accelerometer | SensorTypes.Gyroscope);
            this.sensors.Start();     
            
            this.DependencyInitializationEnd = DateTime.Now;
        }

        #endregion
    }
}
