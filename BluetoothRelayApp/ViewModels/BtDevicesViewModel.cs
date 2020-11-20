using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BluetoothRelayApp.ViewModels
{
    class BtDevicesViewModel
    {
        private ObservableCollection<string> pairedDevices;

        public ObservableCollection<string> PairedDevices
        {
            get { return pairedDevices; }
            set
            {
                pairedDevices = value;
            }
        }

        public BtDevicesViewModel(ObservableCollection<string> devices)
        {
            pairedDevices = new ObservableCollection<string>();
            
            foreach (var device in pairedDevices)
            {
                PairedDevices.Add(device);
            }
            

        }
    }
}
