using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.grid.third.pages
{
	public static class MainPage
	{
		//private readonly DriverAdapter _driver;
		//public MainPage(DriverAdapter driver) {
		//	_driver= driver;
		//}

		//public string Url => "https://todomvc.com";

		//public void Open()
		//{
		//	_driver.GotoUrl(Url);
		//}

		//public void OpenTechnologyApp(string name)
		//{
		//	var technologyLink = _driver.WaitAndFindElement(By.LinkText(name));
		//	//if (technologyLink != null)
		//	{
		//		technologyLink.Click();
		//	}
		//}
		public static ThreadLocal<IDriverAdapter> Driver { get; set; }

		public static void Open() => Driver.Value.GotoUrl("https://todomvc.com");

		public static void OpenTechnologyApp(string name)
		{
			var technologyLink = Driver.Value.WaitAndFindElement(By.LinkText(name));
			//if (technologyLink != null)
			{
				technologyLink.Click();
			}
		}
	}
}
