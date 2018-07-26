using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Righthand.RealtimeGraph;
using WMI.NET.Model.Win32.OperatingSystem.FileSystem.LogicalDisk;

namespace Browser.Controls.Demo
{
	/// <summary>
	/// Interaction logic for DemoControl.xaml
	/// </summary>
	public partial class DemoControl : UserControl
	{
		private readonly ViewModel _model;

		public DemoControl(ViewModel model)
		{
			_model = model;
			InitializeComponent();
			Graph.SeriesSource = _model.List;
		}
	}

	public class RealtimeGraphItem : IGraphItem
	{
		public int Time { get; set; }
		public double Value { get; set; }
	}

	public class ViewModel
	{
		public BindingList<RealtimeGraphItem> List;

		public ViewModel()
		{
			List = new BindingList<RealtimeGraphItem>();
		}
	}
}
