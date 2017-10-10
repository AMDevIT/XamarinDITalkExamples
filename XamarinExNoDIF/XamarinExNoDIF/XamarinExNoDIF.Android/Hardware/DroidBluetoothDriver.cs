using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinExNoDIF.Hardware;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content.PM;

namespace XamarinExNoDIF.Droid.Hardware
{
    public class DroidBluetoothDriver
      : BluetoothDriverBase
    {
        #region Fields

        private BluetoothManager bluetoothManager = null;
        private BluetoothAdapter bluetoothAdapter = null;
        private BluetoothLeScanner bluetoothLeScanner = null;
        private DroidLEScannerCallback scannerCallback = null;
        private List<ScanFilter> scanfiltersList = null;            // Scanfilters are broken in most android implementations!
        private ScanSettings scanSettings = null;

        #endregion

        #region .ctor

        public DroidBluetoothDriver()
            : this(null)
        {
            
        }

        public DroidBluetoothDriver(Guid[] filter)
            : this(null, null)
        {
            ScanSettings.Builder scanSettingsBuilder = null;            

            scanSettingsBuilder = new ScanSettings.Builder();
            scanSettingsBuilder.SetMatchMode(BluetoothScanMatchMode.Aggressive);
            scanSettingsBuilder.SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency);
            this.scanSettings = scanSettingsBuilder.Build();
            this.scanfiltersList = new List<ScanFilter>();

            if (filter != null && filter.Length > 0)
            {                         
                foreach (Guid selectedFilter in filter)
                {
                    ParcelUuid parcelUuid = null;
                    ScanFilter.Builder filterBuilder = new ScanFilter.Builder();
                    ScanFilter currentFilter = null;

                    try
                    {
                        parcelUuid = ParcelUuid.FromString(selectedFilter.ToString());
                        filterBuilder.SetServiceUuid(parcelUuid);
                        currentFilter = filterBuilder.Build();
                        this.scanfiltersList.Add(currentFilter);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public DroidBluetoothDriver(IEnumerable<ScanFilter> scanFilters, ScanSettings scanSettings)            
        {
            ScanSettings.Builder scanSettingsBuilder = null;

            if (scanFilters != null)
                this.scanfiltersList = new List<ScanFilter>(scanFilters);
            else
                this.scanfiltersList = new List<ScanFilter>();

            if (scanSettings != null)
                this.scanSettings = scanSettings;
            else
            {              
                scanSettingsBuilder = new ScanSettings.Builder();
                scanSettingsBuilder.SetMatchMode(BluetoothScanMatchMode.Aggressive);
                scanSettingsBuilder.SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency);
                this.scanSettings = scanSettingsBuilder.Build();
            }

            if (!Application.Context.PackageManager.HasSystemFeature(PackageManager.FeatureBluetoothLe))
            {
                this.State = BluetoothDriverStates.NotPresent;
                return;
            }

            this.bluetoothManager = Application.Context.GetSystemService(Context.BluetoothService) as BluetoothManager;
            if (this.bluetoothManager != null)
            {
                this.bluetoothAdapter = this.bluetoothManager.Adapter;
                if (this.bluetoothAdapter != null)
                    this.State = BluetoothDriverStates.Enabled;
            }
        }

        #endregion

        #region Methods       

        public override void Start()
        {
            ScanSettings.Builder scanSettingsBuilder = null;

            switch (this.State)
            {
                case BluetoothDriverStates.NotPresent:
                    return;

                case BluetoothDriverStates.Enabled:
                    this.scannerCallback = new DroidLEScannerCallback();
                    this.bluetoothLeScanner = this.bluetoothAdapter.BluetoothLeScanner;
                    if (this.scanfiltersList.Count == 0)
                        this.bluetoothLeScanner.StartScan(this.scannerCallback);
                    else
                    {                      
                        try
                        {
                            if (this.scanSettings == null)
                            {
                                scanSettingsBuilder = new ScanSettings.Builder();
                                scanSettingsBuilder.SetMatchMode(BluetoothScanMatchMode.Aggressive);
                                scanSettingsBuilder.SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency);
                                this.scanSettings = scanSettingsBuilder.Build();
                                this.scanfiltersList = new List<ScanFilter>();
                            }
                            this.bluetoothLeScanner.StartScan(this.scanfiltersList, scanSettings, this.scannerCallback);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    this.State = BluetoothDriverStates.Discovering;
                    break;
            }
        }

        public override void Stop()
        {
            switch (this.State)
            {
                case BluetoothDriverStates.NotPresent:
                    return;

                case BluetoothDriverStates.Discovering:
                    if (this.bluetoothLeScanner != null)
                    {
                        this.bluetoothLeScanner.StopScan(this.scannerCallback);
                        this.State = BluetoothDriverStates.Enabled;
                    }
                    break;
            }
        }

        #endregion
    }
}