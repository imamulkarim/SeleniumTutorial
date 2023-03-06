using SeleniumXUnitPractice.grid.third;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third.pages
{
	public class TodoPageApp
	{
		private readonly DriverAdapter _driver;
		public TodoPageApp(DriverAdapter driver)
		{
			_driver = driver;
		}

		public void AssertLeftItems(int expectedCount)
		{
			var resultSpan = _driver.WaitAndFindElement(By.XPath("//footer/span"));
			if (expectedCount <= 0)
			{
				_driver.validateInnerTextIs(resultSpan, $"{expectedCount} item left");
			}
			else
			{
				_driver.validateInnerTextIs(resultSpan, $"{expectedCount} items left");
			}
		}

		public IWebElement GetItemCheckBox(string todoItem)
		{
			var checkItem = _driver.WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
			return checkItem;
		}

		public void AddNewToDoItem(string todoItem)
		{
			var todoInput = _driver.WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
			todoInput.SendKeys(todoItem);
			todoInput.SendKeys(Keys.Enter);
			//_actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
		}



	}
}
