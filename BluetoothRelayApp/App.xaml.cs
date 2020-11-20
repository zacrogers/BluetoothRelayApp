using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BluetoothRelayApp
{
    public partial class App : Application
    {
        public IBtConnection btConnection;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public App(IBtConnection bt)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(bt));
            //MainPage = new NavigationPage(new MainPage());
            btConnection = bt;
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
