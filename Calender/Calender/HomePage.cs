using System;

using Xamarin.Forms;

namespace Calender
{
	public class HomePage : ContentPage
	{
		public HomePage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

