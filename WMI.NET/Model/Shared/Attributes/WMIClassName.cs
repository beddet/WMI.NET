using System;

namespace WMI.NET.Model.Shared.Attributes
{
	public class WMIClassName : Attribute
	{
		public string Name { get; set; }
		public bool IsQueryable { get; set; }

		public WMIClassName(string name, bool isQueryable)
		{
			Name = name;
			IsQueryable = isQueryable;
		}
	}
}