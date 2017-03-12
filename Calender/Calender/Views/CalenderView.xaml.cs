using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calender
{
	public partial class CalenderView : ContentView
	{

		public static BindableProperty ItemSelectedCommandProperty = 
			BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CalenderView),null);
		
		public ICommand ItemSelectedCommand
		{
			get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
			set { SetValue(ItemSelectedCommandProperty, value); }
		}


		public DateTime CurrentDate { get; private set; }

		public int CurrentMonth { get; private set; }

		public int CurrentYear { get; private set; }

		public int CurrentNoOfDaysInAMonth { get; private set; }

		public DayOfWeek CurrentDayOfTheWeek { get; private set; }

		public int CurrentDay { get; private set; }

		void Gi_SwipeLeft(object sender, EventArgs e)
		{
			CurrentDate = DateTime.Now.Date;
			CurrentMonth++;
			if (CurrentMonth > 12)
			{
				CurrentMonth = 1;
				CurrentYear++;
			}

			CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
			CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);

			LoadCalender();
		}

		void Gi_SwipeRight(object sender, EventArgs e)
		{
			CurrentDate = DateTime.Now.Date;
			CurrentMonth--;
			if (CurrentMonth < 1)
			{
				CurrentMonth = 12;
				CurrentYear--;
			}

			CurrentDay = DateTime.Now.Day;
			CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
			CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);

			LoadCalender();
		}

		public Grid CalenderViewControl
		{
			get;
			set;
		}

		public GestureFrame gi
		{
			get;
			set;
		}

		public CalenderView()
		{
			InitializeComponent();

			gi = new GestureFrame
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 1,
			};

			gi.SwipeLeft += Gi_SwipeLeft;
			gi.SwipeRight += Gi_SwipeRight;

			CurrentDate = DateTime.Now.Date;
			CurrentMonth = DateTime.Now.Month;
			CurrentYear = DateTime.Now.Year;
			CurrentDay = DateTime.Now.Day;
			CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
			CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);

			LoadCalender();
		}

		public void LoadCalender()
		{
			CalenderViewControl = new Grid()
			{
				BackgroundColor = Color.Gray,
				ColumnSpacing = 2,
				RowSpacing = 2,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
			var curMonthName = monthNames[CurrentMonth - 1];

			var rightSwipe = new Image() { Source = "Right.png", HeightRequest = 30, WidthRequest = 30, BackgroundColor = Color.White };
			var leftSwipe = new Image() { Source = "Left.png", HeightRequest=30, WidthRequest =30, BackgroundColor =Color.White, };

			TapGestureRecognizer rightTap = new TapGestureRecognizer();
			rightTap.Tapped += Gi_SwipeLeft;
			rightSwipe.GestureRecognizers.Add(rightTap);

			TapGestureRecognizer leftTap = new TapGestureRecognizer();
			leftTap.Tapped += Gi_SwipeRight;
			leftSwipe.GestureRecognizers.Add(leftTap);

			CalenderViewControl.Children.Add(leftSwipe, 0, 0);

			var monthLabel = new Label() { Text = curMonthName.ToString() + " " + CurrentYear.ToString(), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand, };
			var stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(monthLabel);
			CalenderViewControl.Children.Add(stack, 1, 0);
			Grid.SetColumnSpan(stack, 5);

			CalenderViewControl.Children.Add(rightSwipe, 6, 0);	

			var weekDay = new Label() { Text = "Sun", TextColor = Color.Red, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 0, 1);

			weekDay = new Label() { Text = "Mon", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 1, 1);

			weekDay = new Label() { Text = "Tue", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 2, 1);

			weekDay = new Label() { Text = "Wed", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 3, 1);

			weekDay = new Label() { Text = "Thu", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 4, 1);

			weekDay = new Label() { Text = "Fri", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 5, 1);

			weekDay = new Label() { Text = "Sat", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
			stack = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
			stack.Children.Add(weekDay);
			CalenderViewControl.Children.Add(stack, 6, 1);

			CurrentDay = (CurrentMonth == DateTime.Now.Month && CurrentYear == DateTime.Now.Year) ? DateTime.Now.Day : 0;
			var startDaytoPrintInCalender = -1;
			switch (CurrentDayOfTheWeek)
			{
				case DayOfWeek.Sunday:
					startDaytoPrintInCalender = 0;
					break;

				case DayOfWeek.Monday:
					startDaytoPrintInCalender = 1;
					break;

				case DayOfWeek.Tuesday:
					startDaytoPrintInCalender = 2;
					break;

				case DayOfWeek.Wednesday:
					startDaytoPrintInCalender = 3;
					break;

				case DayOfWeek.Thursday:
					startDaytoPrintInCalender = 4;
					break;

				case DayOfWeek.Friday:
					startDaytoPrintInCalender = 5;
					break;

				case DayOfWeek.Saturday:
					startDaytoPrintInCalender = 6;
					break;

				default:
					startDaytoPrintInCalender = -1;
					break;
			}

			Label dateLabel = null;
			Frame frame = null;
			bool startDaySelected = false;
			int day = 1;
			for (int i = 2; i < 8; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (!startDaySelected)
					{
						if (j >= startDaytoPrintInCalender)
						{
							startDaySelected = true;
						}
					}
					else
					{
						day++;
					}

					if (day > CurrentNoOfDaysInAMonth && j == 0)
					{
						break;
					}

					frame = new Frame() { HasShadow = false, Padding = 0, BackgroundColor = CurrentDay == day ? Color.Gray : Color.Transparent, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
					dateLabel = new Label() { Text = startDaySelected && day <= CurrentNoOfDaysInAMonth ? (day).ToString() : string.Empty, TextColor = j == 0 ? Color.Red : Color.Default,  FontSize = 18, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
					frame.Content = dateLabel;

					stack = new StackLayout() { BackgroundColor = CurrentDay == day ? Color.FromHex("bf3122") : Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
					stack.Children.Add(dateLabel);

					if (startDaySelected && day <= CurrentNoOfDaysInAMonth)
					{
						TapGestureRecognizer dateTap = new TapGestureRecognizer();
						var dateTime = new DateTime(CurrentYear, CurrentMonth, day);
						//dateTap.SetBinding(TapGestureRecognizer.CommandProperty, "DateSelected");
						dateTap.Tapped += (sender, e) => {
							if (ItemSelectedCommand != null && ItemSelectedCommand.CanExecute(null))
							{
								ItemSelectedCommand.Execute(dateTime);
							}
						};


						dateTap.CommandParameter = dateTime;
						stack.GestureRecognizers.Add(dateTap);
					}	

					CalenderViewControl.Children.Add(stack, j, i);
				}
			}
			gi.Content = CalenderViewControl;
			this.Content = gi;
		}
	}
}