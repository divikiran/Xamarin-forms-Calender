using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


		ObservableCollection<string> _names;
		public ObservableCollection<string> Names
		{
			get
			{
				return _names;
			}

			set
			{
				_names = value;
				RaisePropertyChanged("Names");
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
