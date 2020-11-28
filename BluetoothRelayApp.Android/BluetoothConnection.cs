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
        // HC-05 UUID  "00001101-0000-1000-8000-00805F9B34FB"
        private static readonly Java.Util.UUID MY_UUID_SECURE = Java.Util.UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");

        private Dictionary<string, BluetoothDevice> _pairedDevices = new Dictionary<string, BluetoothDevice>();

        public BluetoothAdapter adapter { get; set; }
        public BluetoothDevice device { get; set; }
        public BluetoothSocket socket { get; set; }

        private bool deviceConnected = false;
        public BluetoothConnection()
        {
            adapter = BluetoothAdapter.DefaultAdapter;
            socket = null;
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
            adapter.StartDiscovery();
            BluetoothDevice device = _pairedDevices[deviceName];

            try
            {
                device.SetPairingConfirmation(false);
                device.SetPairingConfirmation(true);
                device.CreateBond();
            }
            catch(Exception ex)
            { }

            adapter.CancelDiscovery();

            try
            {
                socket = device.CreateRfcommSocketToServiceRecord(MY_UUID_SECURE);
            }
            catch(Exception ex)
            {

            }
            try
            {
                socket.Connect();
            }
            catch (Exception ex)
            {

            }

            deviceConnected = true;
        }

        public void DisconnectDevice(string deviceName)
        {
            BluetoothDevice device = _pairedDevices[deviceName];
            try
            {
                device.Dispose();

                socket.OutputStream.WriteByte(200);
                socket.OutputStream.Close();
                socket.Close();

                socket = null;
            }
            catch { }
        }
        public void SendCommand(string cmd)
        {
            byte[] cmdByteArr = Encoding.ASCII.GetBytes(cmd);
            if(deviceConnected)
            {
                try
                {
                    socket.OutputStream.Write(cmdByteArr, 0, cmdByteArr.Length);
                }
                catch { }
            }
        }
        public ObservableCollection<string> PairedDevices()
        {
            //BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            ObservableCollection<string> devices = new ObservableCollection<string>();

            foreach (var bd in adapter.BondedDevices)
            {
                devices.Add(bd.Name);

                if(!_pairedDevices.ContainsKey(bd.Name))
                    _pairedDevices.Add(bd.Name, bd);
            }

            return devices;
        }
    }
}