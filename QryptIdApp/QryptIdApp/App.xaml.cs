using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using QryptIdApp.Models;
using QryptIdApp.Repositories;

namespace QryptIdApp
{
    public partial class App : Application
    {
        private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
        public static UserRepository UserRepo = new UserRepository(dbPath);
        //public static List<User> users;


        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LoadingScreen());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
 
