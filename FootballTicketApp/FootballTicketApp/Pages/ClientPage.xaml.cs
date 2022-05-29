using FootballTicketApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTicketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();
            pickerBirthday.MaximumDate = DateTime.Now.AddYears(-14);
            pickerBirthday.MinimumDate = DateTime.Now.AddYears(-120);
           // if (Manager.loginedClient.FirstName)
            entryLogin.Text = Manager.loginedClient.Login;
            pickerBirthday.Date = Manager.loginedClient.Birthday;
            entryName.Text = Manager.loginedClient.FirstName;
            entrySurname.Text = Manager.loginedClient.LastName;
            entryPassword.Text = Manager.loginedClient.Password;
            pickerBirthday.Date = Manager.loginedClient.Birthday;
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (entryLogin.Text != null && entryName.Text != null && entryPassword.Text != null && entrySurname.Text != null)
            {
                EditClient editClient = new EditClient()
                {
                    Id = Manager.loginedClient.Id,
                    FirstName = entryName.Text,
                    LastName = entrySurname.Text,
                    Login = entryLogin.Text,
                    Password = entryPassword.Text,
                    Birthday = pickerBirthday.Date,
                    Email = entryEmail.Text
                };
                if(!new EmailAddressAttribute().IsValid(entryEmail.Text))
                {
                    DisplayAlert("Ошибка", "Неверный формат Email адреса", "ОК");
                    return;
                }
                var webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var response = webClient.UploadString("http://10.0.2.2:64121/api/editClient", JsonConvert.SerializeObject(editClient));
                DisplayAlert("Успешно!", "Данные сохранены!", "OK");
                Manager.loginedClient.FirstName = editClient.FirstName;
                Manager.loginedClient.LastName = editClient.LastName;
                Manager.loginedClient.Login = editClient.Login;
                Manager.loginedClient.Password = editClient.Password;
                Manager.loginedClient.Birthday = editClient.Birthday;
                Manager.loginedClient.Email = editClient.Email;
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Ошибка!", "Заполните все поля!", "OK");
                return;
            }
        }
    }
}