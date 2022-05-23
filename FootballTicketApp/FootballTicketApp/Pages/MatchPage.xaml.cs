using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FootballTicketApp.Models;

namespace FootballTicketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        List<Ticket> tickets = new List<Ticket>();
        Match match = new Match();
        public MatchPage(Match currentMatch)
        {
            InitializeComponent();
            match = currentMatch;
            Team.Source = currentMatch.FirstTeam.Photo;
            Team1.Source = currentMatch.SecondTeam.Photo;
            var client = new WebClient();
            var response = client.DownloadString("http://10.0.2.2:64121/api/Tickets");
            tickets = JsonConvert.DeserializeObject<List<Ticket>>(response);
            int[] sectors = Enumerable.Range(1, 6).ToArray();
            int[] rows = Enumerable.Range(1, 8).ToArray();
            int[] sites = Enumerable.Range(1, 10).ToArray();
            pickRow.ItemsSource = rows;
            pickSector.ItemsSource = sectors;
            pickSite.ItemsSource = sites;
        }

        private void btnPost_Clicked(object sender, EventArgs e)
        {
            if (pickRow.SelectedItem != null || pickSector.SelectedItem != null || pickSite.SelectedItem != null)
            {
                foreach (Ticket ticket in tickets)
                {
                    if ((int)pickRow.SelectedItem == ticket.Row && (int)pickSector.SelectedItem == ticket.Sector && (int)pickSite.SelectedItem == ticket.Site)
                    {
                        DisplayAlert("Ошибка!", "Данное место занято!", "OK");
                        return;
                    }
                }
                Ticket currentTicket = new Ticket();
                currentTicket.ClientId = Manager.loginedClient.Id;
                currentTicket.Sector = (int)pickSector.SelectedItem;
                currentTicket.Row = (int)pickRow.SelectedItem;
                currentTicket.Site = (int)pickSite.SelectedItem;
                currentTicket.PurchaseDate = DateTime.Now;
                currentTicket.MatchId = match.Id;
                currentTicket.Status = false;
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var response = client.UploadString("http://10.0.2.2:64121/api/Tickets", JsonConvert.SerializeObject(currentTicket));
                DisplayAlert("Успешно!", "Билет успешно оформлен!", "OK");
            }
        }
    }
}