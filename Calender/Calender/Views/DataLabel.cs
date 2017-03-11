using System;
using Xamarin.Forms;

namespace Calender
{
	public class DataLabel : StackLayout
	{
		public DataLabel()
		{
			Label text = new Label();
			text.Text = "Divi";
			this.Children.Add(text);
		}
	}
}
