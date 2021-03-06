﻿using CoreBluetooth;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_DIF.Hardware;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.iOS.Hardware.IOSBluetoothDriver))]
namespace Xamarin_DIF.iOS.Hardware
{
    public class IOSBluetoothDriver
        : IBluetoothDriver
    {
        #region Fields

        private CBCentralManager centralManager = null;
        private CBUUID[] scanFilter = new CBUUID[] { };

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

        public IOSBluetoothDriver()
        {
            this.centralManager = new CBCentralManager();
            this.centralManager.DiscoveredPeripheral += CentralManager_DiscoveredPeripheral;
            switch(this.centralManager.State)
            {
                case CBCentralManagerState.PoweredOff:
                case CBCentralManagerState.Unauthorized:
                case CBCentralManagerState.Unsupported:                
                    this.DriverState = BluetoothDriverStates.NotPresent;
                    break;
                case CBCentralManagerState.PoweredOn:
                case CBCentralManagerState.Resetting:
                    this.DriverState = BluetoothDriverStates.Enabled;
                    break;
                case CBCentralManagerState.Unknown:
                    this.DriverState = BluetoothDriverStates.Unknown;
                    break;
            }
        }

        #endregion

        #region Methods

        public void InitFilter(Guid[] filter)
        {
            List<CBUUID> uuidList = null;

            if (filter != null && filter.Length > 0)
            {
                uuidList = new List<CBUUID>();
                foreach(Guid currentFilter in filter)
                {
                    CBUUID uuid = null;
                    uuid = CBUUID.FromString(currentFilter.ToString());
                    uuidList.Add(uuid);
                }
                this.scanFilter = uuidList.ToArray();
            }
        }

        public void Start()
        {
            PeripheralScanningOptions scanningOptions = new PeripheralScanningOptions();

            switch (this.DriverState)
            {
                case BluetoothDriverStates.Enabled:
                    try
                    {
                        this.centralManager.ScanForPeripherals(this.scanFilter, scanningOptions);
                    }
                    catch(Exception exc)
                    {
                        System.Diagnostics.Debug.WriteLine(exc.ToString());
                    }
                    this.DriverState = BluetoothDriverStates.Discovering;
                    break;
            }
        }

        public void Stop()
        {
            if (this.DriverState == BluetoothDriverStates.Discovering)
            {
                this.centralManager.StopScan();
                this.DriverState = BluetoothDriverStates.Enabled;
            }            
        }

        #endregion

        #region Event Handlers

        private void CentralManager_DiscoveredPeripheral(object sender, CBDiscoveredPeripheralEventArgs e)
        {
            
        }        

        #endregion
    }
}
