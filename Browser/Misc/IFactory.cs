using Browser.Controls.Browse;
using Browser.Controls.CustomQuery;

namespace Browser.Misc
{
	public interface IFactory
	{
		MainWindow CreateMainWindow();
		CustomQueryControl CreateCustomQueryControl();
		OutputControl CreateOutputControl();
		ResultsControl CreateResultsControl();
		BrowseControl CreateBrowseControl();
	}
}