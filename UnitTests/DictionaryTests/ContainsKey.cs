using System;
using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace UnitTests.DictionaryTests
{
	public partial class DictionaryTests
	{
		[TestFixture]
		public class ContainsKey
		{
			public IDictionary<int, int> Dictionary;

			[Test]
			public void DictionaryMayNotBeNull()
			{
				Dictionary = null;
				int value;
				Assert.Throws<ArgumentNullException>(() => Dictionary.ContainsKey(5, out value));
			}

			[Test]
			public void DictionaryDoesNotContainKey()
			{
				Dictionary = new Dictionary<int, int>();
				int value;
				bool t = Dictionary.ContainsKey(5, out value);
				Assert.False(t);
			}

			[Test]
			public void DictionaryContainsValue()
			{
				Dictionary = new Dictionary<int, int>();
				Dictionary.Add(5, 42);
				int value;
				bool t = Dictionary.ContainsKey(5, out value);
				Assert.True(t);
				Assert.AreEqual(42, value);
			}
		}
	}
}