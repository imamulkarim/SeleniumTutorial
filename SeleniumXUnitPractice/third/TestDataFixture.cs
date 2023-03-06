using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third
{
	public class TestDataFixture : IDisposable
	{
		public void Dispose()
		{
			
		}

		public TestDataFixture() {
			var autoFixture = new Fixture();

			itemToAdd = autoFixture.CreateMany<string>(5).ToList();
			itemToCheck = itemToAdd.Skip(3).ToList();
			ExpectedItemsLeft = 3;
		}

		public List<string> itemToAdd { get; set; }
		public List<string> itemToCheck { get; set; }
		public int ExpectedItemsLeft { get; set; }
	}
}
