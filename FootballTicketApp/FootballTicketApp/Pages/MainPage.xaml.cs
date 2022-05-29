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
        List<Match> matches = new List<Match>();
        public MainPage()
        {
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://10.0.2.2:64121/api/getMatches");
            matches = JsonConvert.DeserializeObject<List<Match>>(response);
            LViewMatches.ItemsSource = matches;
        }

        private void LViewMatches_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MatchPage(LViewMatches.SelectedItem as Match));
        }

        private void entrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LViewMatches.ItemsSource = matches.Where(p => p.FirstTeam.Title.Trim().ToLower().Contains(entrySearch.Text.Trim().ToLower()) ||
            p.SecondTeam.Title.Trim().ToLower().Contains(entrySearch.Text.Trim().ToLower()));
        }
    }
}
