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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnReg_Clicked(object sender, EventArgs e)
        {
            if (nameEntry.Text == null || surnameEntry.Text == null || loginEntry.Text == null || passwordEntry.Text == null)
            {
                DisplayAlert("Ошибка!", "Заполните все поля!", "OK");
            }
            else
            {
                Client currentClient = new Client();
                currentClient.FirstName = nameEntry.Text;
                currentClient.LastName = surnameEntry.Text;
                currentClient.Login = loginEntry.Text;
                currentClient.Password = passwordEntry.Text;
                var webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var response = webClient.UploadString("http://10.0.2.2:64121/api/Clients", JsonConvert.SerializeObject(currentClient));
                DisplayAlert("Успешно!", "Вы успешно зарегистрировались!", "OK");
                Navigation.PushAsync(new TabbedMainPage());
            }
        }
    }
}