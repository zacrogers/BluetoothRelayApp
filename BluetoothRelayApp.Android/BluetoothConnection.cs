using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BluetoothRelayApp.Droid
{
    public class BluetoothConnection : IBtConnection
    {
        public BluetoothConnection()
        {

        }
        private CancellationTokenSource _ct { get; set; }

        const int RequestResolveError = 1000;
        public void Start(string name, int sleepTime, bool readAsCharArray)
        {

        }
        public void Cancel()
        {

        }
        public void ConnectDevice(string deviceName)
        {
            
        }
        public void SendCommand(string cmd)
        {

        }
        public ObservableCollection<string> PairedDevices()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            ObservableCollection<string> devices = new ObservableCollection<string>();

            foreach (var bd in adapter.BondedDevices)
                devices.Add(bd.Name);

            return devices;
        }
    }
}