using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Browser.Misc;

namespace Browser.Model
{
	public class BaseControl : UserControl
	{
		public BaseControl()
		{
			_controls = new Dictionary<Type, UserControl>();
		}

		private IDictionary<Type, UserControl> _controls;

		public T AddControl<T>(UserControl control) where T : UserControl
		{
			Type type = typeof(T);
			if (_controls.ContainsKey(type))
			{
				throw new Exception("Dictionary already contains the key");
			}
			_controls.Add(type, control);
			return _controls.Get<T>();
		}

		public T Load<T>() where T : UserControl
		{
			return _controls.Get<T>();
		}
	}
}