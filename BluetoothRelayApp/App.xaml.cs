using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BluetoothRelayApp
{
    public partial class App : Application
    {
        IBluetoothLE ble = CrossBluetoothLE.Current;
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
