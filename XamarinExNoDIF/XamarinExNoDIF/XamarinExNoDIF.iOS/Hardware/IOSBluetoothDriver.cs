using CoreBluetooth;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinExNoDIF.Hardware;

namespace XamarinExNoDIF.iOS.Hardware
{
    public class IOSBluetoothDriver
        : BluetoothDriverBase
    {
        #region Fields

        private CBCentralManager centralManager = null;
        private CBUUID[] scanFilter = new CBUUID[] { };

        #endregion
      
        #region .ctor
        public IOSBluetoothDriver()
            : base(null)
        {

        }

        public IOSBluetoothDriver(Guid[] filter)
        {
            List<CBUUID> uuidList = null;

            this.centralManager = new CBCentralManager();
            this.centralManager.DiscoveredPeripheral += CentralManager_DiscoveredPeripheral;
            switch (this.centralManager.State)
            {
                case CBCentralManagerState.PoweredOff:
                case CBCentralManagerState.Unauthorized:
                case CBCentralManagerState.Unsupported:
                    this.State = BluetoothDriverStates.NotPresent;
                    break;
                case CBCentralManagerState.PoweredOn:
                case CBCentralManagerState.Resetting:
                    this.State = BluetoothDriverStates.Enabled;
                    break;
                case CBCentralManagerState.Unknown:
                    this.State = BluetoothDriverStates.Unknown;
                    break;
            }

            if (filter != null && filter.Length > 0)
            {
                uuidList = new List<CBUUID>();
                foreach (Guid currentFilter in filter)
                {
                    CBUUID uuid = null;
                    uuid = CBUUID.FromString(currentFilter.ToString());
                    uuidList.Add(uuid);
                }
                this.scanFilter = uuidList.ToArray();
                this.Filter = filter;
            }
            else
                this.Filter = new Guid[] { };
        }

        #endregion

        #region Methods
      
        public override void Start()
        {
            PeripheralScanningOptions scanningOptions = new PeripheralScanningOptions();

            switch (this.State)
            {
                case BluetoothDriverStates.Enabled:
                    try
                    {
                        this.centralManager.ScanForPeripherals(this.scanFilter, scanningOptions);
                    }
                    catch (Exception exc)
                    {
                        System.Diagnostics.Debug.WriteLine(exc.ToString());
                    }
                    this.State = BluetoothDriverStates.Discovering;
                    break;
            }
        }

        public override void Stop()
        {
            if (this.State == BluetoothDriverStates.Discovering)
            {
                this.centralManager.StopScan();
                this.State = BluetoothDriverStates.Enabled;
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
