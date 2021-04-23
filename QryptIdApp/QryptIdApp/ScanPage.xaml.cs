using QryptIdApp.Models;
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
	public partial class ScanPage : ContentPage
	{
		User _user;
		public ScanPage(User user)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			Button1.IsVisible = true;
			_user = user;
		}
		private async void Button_Clicked(object sender, EventArgs e)
		{
			var scan = new ZXingScannerPage();
			scan.BackgroundColor = Color.FromHex("#00376C");
			NavigationPage.SetHasNavigationBar(scan, false);
			await Navigation.PushAsync(scan);
			scan.OnScanResult += (result) =>
			  {
				  Device.BeginInvokeOnMainThread(async () =>
				  {
					  string stringResult = result.Text;
                      try
					  {
						  stringResult = App.UserRepo.Decrypt(stringResult, _user);
					  }
                      catch(Exception ex)
                      {
						  stringResult = "erreur";
                      }
					  await Navigation.PushAsync(new InfoPage(stringResult));
				  });
			  };
		}

		
	}
}