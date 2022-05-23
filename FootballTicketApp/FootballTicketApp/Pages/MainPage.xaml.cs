using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FootballTicketApp.Pages;

namespace FootballTicketApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://10.0.2.2:64121/api/getMatches");
            LViewMatches.ItemsSource = JsonConvert.DeserializeObject<List<Match>>(response);
        }

        private void LViewMatches_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MatchPage(LViewMatches.SelectedItem as Match));
        }
    }
}
