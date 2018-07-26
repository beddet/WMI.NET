namespace Browser.Model
{
	public class ListViewFrontend
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return Value;
		}
	}
}