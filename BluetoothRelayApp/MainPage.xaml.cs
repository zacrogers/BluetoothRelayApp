using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BluetoothRelayApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {

        }

        private void Button3_Clicked(object sender, EventArgs e)
        {

        }

        private void Button4_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new BtSelectPage());
            Navigation.PushAsync(new BtSelectPage());
        }


    }
}
