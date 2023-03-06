using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.grid.third.pages
{
	public static class TodoPageApp
	{

		//private readonly DriverAdapter _driver;
		//public TodoPageApp(DriverAdapter driver) {
		//	_driver= driver;
		//}

		public static void AssertLeftItems(int expectedCount)
		{
			var resultSpan = Driver.Value.WaitAndFindElement(By.XPath("//footer/*/span | //footer/span"));
			if (expectedCount <= 0)
			{
				Driver.Value.validateInnerTextIs(resultSpan, $"{expectedCount} item left");
			}
			else
			{
				Driver.Value.validateInnerTextIs(resultSpan, $"{expectedCount} items left");
			}
		}

		public static IWebElement GetItemCheckBox(string todoItem)
		{
			var checkItem = Driver.Value.WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
			return checkItem;
		}

		public static void AddNewToDoItem(string todoItem)
		{
			var todoInput = Driver.Value.WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
			todoInput.SendKeys(todoItem);
			todoInput.SendKeys(Keys.Enter);
			//_actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
		}
		public static ThreadLocal<IDriverAdapter> Driver { get; set; }


	}
}
