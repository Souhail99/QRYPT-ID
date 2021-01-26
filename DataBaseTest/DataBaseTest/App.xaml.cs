using System;
using System.Collections.Generic;
using System.IO;
using DataBaseTest.Models;
using DataBaseTest.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBaseTest
{
    public partial class App : Application
    {
        private string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");
        public static UserRepository UserRepository { get; private set; }
       

        public App()
        {
            InitializeComponent();
            UserRepository = new UserRepository(dbPath);
            List<User> users = UserRepository.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user.Id);
            }
            
            MainPage = new MainPage();
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
