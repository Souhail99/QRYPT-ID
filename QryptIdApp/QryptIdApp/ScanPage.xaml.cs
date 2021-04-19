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
		public ScanPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			Button1.IsVisible = true;
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
					  //here goes rsa encryption
					  await Navigation.PushAsync(new InfoPage(stringResult));
				  });
			  };
		}

		
	}
}