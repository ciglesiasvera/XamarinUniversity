using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
            //BackgroundColor = Color.FromRgb(0xf0, 0xf0, 0xf0);
            //Content = new Label()
            //{
            //    Text = "Connection Available",
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.Center,
            //    TextColor = Color.FromRgb(0x40, 0x40, 0x40),
            //};
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();

            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }
        
    }
}
