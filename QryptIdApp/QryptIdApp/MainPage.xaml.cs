using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Xamarin.Forms;
using QryptIdApp.Models;
using QryptIdApp.Repositories;

namespace QryptIdApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
          
            
        }
        public async void Button_Clicked(object sender, EventArgs e)
        {
           User user =  App.UserRepo.LoginValidate(emailEntry.Text,pwEntry.Text);
            if (user!= null)
            {
                var loginPage = new LoginPage(user);
                await Navigation.PushAsync(loginPage);
            }
            else
            {
                ErrorMessage.Text = "Error";

            }
        }

    }
}
