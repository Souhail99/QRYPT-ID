using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QryptIdApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage(string _stringResult)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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
                    break;

                }

            }
        }
    }
}