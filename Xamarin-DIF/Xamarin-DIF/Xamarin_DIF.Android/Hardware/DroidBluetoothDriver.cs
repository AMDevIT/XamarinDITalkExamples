﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin_DIF.Hardware;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content.PM;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.Droid.Hardware.DroidBluetoothDriver))]
namespace Xamarin_DIF.Droid.Hardware
{
    public class DroidBluetoothDriver
        : IBluetoothDriver
    {
        #region Fields

        private BluetoothManager bluetoothManager = null;
        private BluetoothAdapter bluetoothAdapter = null;
        private BluetoothLeScanner bluetoothLeScanner = null;
        private DroidLEScannerCallback scannerCallback = null;
        private List<ScanFilter> scanfiltersList = new List<ScanFilter>();          // Scanfilters are broken in most android implementations!

        #endregion

        #region Properties

        public BluetoothDriverStates DriverState
        {
            get;
            private set;
        }

        public Guid[] Filter
        {
            get;
            private set;
        }


        #endregion

        #region .ctor

        public DroidBluetoothDriver()
        {
            if (!Application.Context.PackageManager.HasSystemFeature(PackageManager.FeatureBluetoothLe))
            {
                this.DriverState = BluetoothDriverStates.NotPresent;
                return;
            }

            this.bluetoothManager = Application.Context.GetSystemService(Context.BluetoothService) as BluetoothManager;
            if (this.bluetoothManager != null)
            {
                this.bluetoothAdapter = this.bluetoothManager.Adapter;
                if (this.bluetoothAdapter != null)                
                    this.DriverState = BluetoothDriverStates.Enabled;                
            }
        }

        #endregion

        #region Methods

        public void InitFilter(Guid[] filter)
        {
            if (filter != null && filter.Length > 0)
            {
                foreach(Guid selectedFilter in filter)
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
                    catch(Exception)
                    {

                    }

                    this.Filter = filter;
                }
            }
        }

        public void Start()
        {
            ScanSettings.Builder scanSettingsBuilder = null;
            ScanSettings scanSettings = null;

            switch(this.DriverState)
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
                        scanSettingsBuilder = new ScanSettings.Builder();
                        scanSettingsBuilder.SetMatchMode(BluetoothScanMatchMode.Aggressive);
                        scanSettingsBuilder.SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency);
                        scanSettings = scanSettingsBuilder.Build();
                        try
                        {
                            this.bluetoothLeScanner.StartScan(this.scanfiltersList, scanSettings, this.scannerCallback);
                        }
                        catch(Exception)
                        {

                        }
                    }
                    this.DriverState = BluetoothDriverStates.Discovering;
                    break;
            }
        }

        public void Stop()
        {
            switch(this.DriverState)
            {
                case BluetoothDriverStates.NotPresent:
                    return;

                case BluetoothDriverStates.Discovering:
                    if (this.bluetoothLeScanner != null)
                    {
                        this.bluetoothLeScanner.StopScan(this.scannerCallback);
                        this.DriverState = BluetoothDriverStates.Enabled;
                    }
                    break;
            }                
        }

        #endregion
    }
}