using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BluetoothRelayApp
{
    public interface IBtConnection
    {
        void Start(string name, int sleepTime, bool readAsCharArray);
        void Cancel();
        void ConnectDevice(string deviceName);
        void SendCommand(string cmd);
        ObservableCollection<string> PairedDevices();
    }
}
