using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calender
{
	public class DateViewModel : INotifyPropertyChanged
	{
		string dateText;

		public string DateText
		{
			get
			{
				return dateText;
			}

			set
			{
				dateText = value;
				RaisePropertyChanged("DateText");
			}
		}


		//ObservableCollection<string> _names;
		//public ObservableCollection<string> Names
		//{
		//	get
		//	{
		//		return _names;
		//	}

		//	set
		//	{
		//		_names = value;
		//		RaisePropertyChanged("Names");
		//	}
		//}


		public ICommand DateSelected
		{
			get
			{
				return new Command(SelectedDateAction);
			}
		}

		int i = 0;
		public void SelectedDateAction(object obj)
		{
			var date = Convert.ToDateTime(obj);
			DateToShow = date.ToString("D");
		}

		string _dateToShow;
		public string DateToShow
		{
			get
			{
				return _dateToShow;
			}

			set
			{
				_dateToShow = value;
				RaisePropertyChanged("DateToShow");
			}
		}

		public DateViewModel()
		{
			dateText = DateTime.Now.ToString("G");

		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var handler = PropertyChanged;
			if (handler == null) return;
			handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
