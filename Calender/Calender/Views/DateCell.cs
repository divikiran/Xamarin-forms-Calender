using System;
using Xamarin.Forms;

namespace Calender
{
	public class DateCell : StackLayout
	{
		public static readonly BindableProperty DateTextProperty = BindableProperty.Create("DateText", typeof(string), typeof(DateCell), null);

		public string DateText
		{
			get { return (string)GetValue(DateTextProperty); }
			set { SetValue(DateTextProperty, value); }
		}


		public DateCell()
		{
			var label = new Label() { Text = DateText };
			//label.SetBinding(Label.TextProperty, this.DateText);
			this.HorizontalOptions = LayoutOptions.CenterAndExpand;
			this.VerticalOptions = LayoutOptions.CenterAndExpand;
			this.Children.Add(label);
		}


	}
}
