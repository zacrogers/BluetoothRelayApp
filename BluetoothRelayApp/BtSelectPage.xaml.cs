using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothRelayApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BtSelectPage : ContentPage
    {
        IBluetoothLE ble = CrossBluetoothLE.Current;
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;

        ObservableCollection<IDevice> deviceList = new ObservableCollection<IDevice>();
        ObservableCollection<string> pairedDevices = new ObservableCollection<string>();
        
        public BtSelectPage()
        {
            InitializeComponent();

            /*
            var state = ble.State;

            ble.StateChanged += (s, e) =>
            {
                Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
            };
            */


            var devices = adapter.GetSystemConnectedOrPairedDevices();

            btDevicesListView.ItemsSource = deviceList;
            Debug.WriteLine("PRINTING DEVICES");
            foreach (var device in devices)
            {
                deviceList.Add(device);
            }

        }

        private void btDevicesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var device = (IDevice)btDevicesListView.SelectedItem;

            try
            {
                adapter.ConnectToDeviceAsync(device);
            }
            catch (DeviceConnectionException)
            {
                Debug.WriteLine("NOTCONNECTED");
                // ... could not connect to device
            }

        }
    }
}