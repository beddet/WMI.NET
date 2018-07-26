using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Browser.Misc;
using NUnit.Framework;

namespace UnitTests.DictionaryTests
{
	public partial class DictionaryTests
	{
		[TestFixture]
		public class Get
		{
			public IDictionary<Type, UserControl> Dictionary;

			[Test]
			public void DictionaryMayNotBeNull()
			{
				Dictionary = null;
				Assert.Throws<ArgumentNullException>(() => Dictionary.Get<UserControl>());
			}

			[Test]
			public void DictionaryDoesNotContainKey()
			{
				Dictionary = new Dictionary<Type, UserControl>();
				Assert.Throws<KeyNotFoundException>(() => Dictionary.Get<UserControl>());
			}
		}
	}
}