using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using XamarinExNoDIF.Hardware.BT;

namespace XamarinExNoDIF.UWP.Hardware.BT
{
    public class UWPBluetoothDriver
        : BluetoothDriverBase
    {
        #region Fields

        private Bluetooth​LE​Advertisement​Watcher leWatcher = null;

        #endregion

        #region Methods

        public override void Start()
        {
            if (this.leWatcher == null)
            {
                this.leWatcher = new BluetoothLEAdvertisementWatcher();
                this.leWatcher.Received += LeWatcher_Received;
                this.leWatcher.Stopped += LeWatcher_Stopped;
            }

            this.leWatcher.Start();
        }        

        public override void Stop()
        {
            this.leWatcher.Stop();
        }

        #endregion

        #region Event Handlers
        private void LeWatcher_Stopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
        }

        private void LeWatcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {            
        }

        #endregion
    }
}
