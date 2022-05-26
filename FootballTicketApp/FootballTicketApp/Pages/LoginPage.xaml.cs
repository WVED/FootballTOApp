using MySql.Data.MySqlClient;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FootballTicketApp.Models;

namespace FootballTicketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnAuth_Clicked(object sender, EventArgs e)
        {
            if (loginEntry.Text != null && passwordEntry.Text != null)
            {
                var webClient = new WebClient();
                var response = webClient.DownloadString("http://10.0.2.2:64121/api/Clients");
                var clients = JsonConvert.DeserializeObject<List<Client>>(response);
                foreach(Client client in clients)
                {
                    if(client.Login == loginEntry.Text && client.Password == passwordEntry.Text)
                    {
                        Manager.loginedClient = client;
                        Navigation.PushAsync(new TabbedMainPage());
                    }
                    else if (loginEntry.Text == null || passwordEntry.Text == null)
                    {
                        DisplayAlert("Ошибка!", "Введены неверные данные!", "OK");
                        return;
                    }
                }
            }
        }

        private void btnReg_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}