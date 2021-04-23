using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QryptIdApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage(string _stringResult)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            bool done = false;
            for (int i = 0; i < App.UserRepo.GetUsers().Count(); i++)
            {

                mycode.Text = "Carte nationale d'identité n°" + _stringResult;
                if (_stringResult == App.UserRepo.GetUsers()[i].Id.ToString())
                {
                    NomPrenom.Text = App.UserRepo.GetUsers()[i].Prenoms + " " + App.UserRepo.GetUsers()[i].Nom.ToUpper();
                    Birthday.Text = "né(e) le "+ App.UserRepo.GetUsers()[i].Birthday;
                    Taille.Text = "Taille: " + App.UserRepo.GetUsers()[i].Taille + " cm";
                    Sexe.Text = "Sexe: " + App.UserRepo.GetUsers()[i].Sexe;
                    IdPhoto.Source = App.UserRepo.GetUsers()[i].Photo;
                    IdPhoto.HeightRequest = 200;
                    IdPhoto.WidthRequest = 200;
                    done = true;
                    break;

                }

            }
			if (!done)
            {
                mycode.Text = "Erreur";
                Sexe.Text = "Aucune CNI ne correspond à ce QR code";

                IdPhoto.Source = "warning.png";
                    // ErrorMessage.Text = "Aucune carte d'identité ne correspond à ce QR code";
            }
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            scan.BackgroundColor = Color.FromHex("#00376C");
            //NavigationPage.SetHasNavigationBar(scan, false);
            await Navigation.PopAsync();
            /*scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    string stringResult = result.Text;
                    await Navigation.PushAsync(new InfoPage(stringResult));
                });
            };*/
        }
    }
}