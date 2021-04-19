using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QryptIdApp
{
    public class LoadingScreen : ContentPage
    {
         Image SplashImage;
        public LoadingScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var container = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "logoAppj.jpg",
                HeightRequest = 120,
                WidthRequest = 150,
                
                
            };
            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.47, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            container.Children.Add(SplashImage);
            this.Content = container;
            this.BackgroundColor = Color.FromHex("#00376C");

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(1, 2000);
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }
    }
}