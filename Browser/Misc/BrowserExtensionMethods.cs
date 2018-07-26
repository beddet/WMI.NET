using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Browser.Misc
{
	public static class BrowserExtensionMethods
	{
		public static T Get<T>(this IDictionary<Type, UserControl> source) where T : UserControl
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			Type type = typeof (T);
			if (source.ContainsKey(type))
			{
				return (T)source[type];
			}

			throw new KeyNotFoundException(string.Format("Could not find element matching key = {0}", type.Name));
		}
	}
}