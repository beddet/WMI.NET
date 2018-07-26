using System;
using Browser.Model;
using Microsoft.Practices.Prism.Commands;
using WMI.NET.QueryProvider;

namespace Browser.Controls.CustomQuery.ViewModels
{
	public class CustomQueryControlViewModel : NotificationObject
	{
		public CustomQueryControlViewModel()
		{
			RunCommand = new DelegateCommand(RunCommandExecute, RunCommandCanExecute);
		}

		private string _query;
		public string Query
		{
			get { return _query; }
			set
			{
				_query = value;
				OnPropertyChanged(() => Query);
			}
		}

		private int? _maxResults;
		public int? MaxResults
		{
			get { return _maxResults; }
			set
			{
				_maxResults = value;
				OnPropertyChanged(() => MaxResults);
			}
		}

		private void RunCommandExecute()
		{
			ResultInfoText = string.Empty;
			ResultInfoIsError = false;

			int count = -1;
			if (!string.IsNullOrEmpty(Query))
			{
				if (MaxResults.HasValue)
				{
					count = MaxResults.Value;
				}
				try
				{
					ResultText = new LocalWMIQueryProvider().CustomQuery(Query, count);
				}
				catch (Exception exc)
				{
					ResultInfoText = exc.Message;
					ResultInfoIsError = true;
				}
			}
		}

		private string _resultText;
		public string ResultText
		{
			get { return _resultText; }
			set
			{
				_resultText = value;
				OnPropertyChanged(() => ResultText);
			}
		}
		
		private bool _resultInfoIsError;
		public bool ResultInfoIsError
		{
			get { return _resultInfoIsError; }
			set
			{
				_resultInfoIsError = value;
				OnPropertyChanged(() => ResultInfoIsError);
			}
		}

		private string _resultInfoText;
		public string ResultInfoText
		{
			get { return _resultInfoText; }
			set
			{
				_resultInfoText = value;
				OnPropertyChanged(() => ResultInfoText);
			}
		}

		private bool RunCommandCanExecute()
		{
			return true;
		}

		public DelegateCommand RunCommand { get; set; }
	}
}