using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Calender
{
	public partial class CalenderPage : ContentPage
	{
		public DateViewModel ViewModel
		{
			get;
			set;
		}

		public CalenderPage()
		{
			InitializeComponent();
			BindingContext = ViewModel = new DateViewModel();


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//ViewModel.DateText = DateTime.Now.ToString("D");
			//ViewModel.Names = new ObservableCollection<string>();
			//for (int i = 0; i < 30; i++)
			//{
			//	ViewModel.Names.Add("D " + i);
			//}
		}
	}
}
