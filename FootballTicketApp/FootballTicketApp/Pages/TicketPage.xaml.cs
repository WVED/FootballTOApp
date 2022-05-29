using FootballTicketApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTicketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketPage : ContentPage
    {
        List<ClientTicket> tickets = new List<ClientTicket>();
        public TicketPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            var client = new WebClient();
            var response = client.DownloadString("http://10.0.2.2:64121/api/getTickets/" + Manager.loginedClient.Id);
            tickets = JsonConvert.DeserializeObject<List<ClientTicket>>(response);
            LViewTickets.ItemsSource = tickets;
        }

        private void btnCancelTicket_Clicked(object sender, EventArgs e)
        {
            ClientTicket selectedTicket = (sender as Button).BindingContext as ClientTicket;
            DateTime matchDate = tickets.Where(p => p.MatchId == selectedTicket.MatchId).Select(c=>c.match.Date).First();
            if (matchDate <= DateTime.Now)
            {
                DisplayAlert("Ошибка!", "Матч уже прошел, бронь нельзя отменить", "OK");
            }
            else
            {
                var client = new WebClient();
                var response = client.UploadValues("http://10.0.2.2:64121/api/Tickets/" + selectedTicket.Id, "DELETE", new System.Collections.Specialized.NameValueCollection());
                DisplayAlert("Успешно!", "Бронь успешно отменена", "OK");
                OnAppearing();
            }
        }
    }
}