using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public IBtConnection btConnection;
        ObservableCollection<string> pairedDevices = new ObservableCollection<string>();
        
        public BtSelectPage()
        {
            InitializeComponent();
        }
        public BtSelectPage(IBtConnection bt)
        {
            InitializeComponent();

            btConnection = bt;
            pairedDevices = bt.PairedDevices();

            btDevicesListView.ItemsSource = pairedDevices;

            btDevicesListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var deviceName = (string)e.SelectedItem;
                btConnection.ConnectDevice(deviceName);
            };
        }
    }
}