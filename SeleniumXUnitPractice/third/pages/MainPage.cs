using SeleniumXUnitPractice.grid.third;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third.pages
{
	public class MainPage
	{
		private readonly DriverAdapter _driver;
		public MainPage(DriverAdapter driver)
		{
			_driver = driver;
		}

		public string Url => "https://todomvc.com";

		public void Open()
		{
			_driver.GotoUrl(Url);
		}

		public void OpenTechnologyApp(string name)
		{
			var technologyLink = _driver.WaitAndFindElement(By.LinkText(name));
			//if (technologyLink != null)
			{
				technologyLink.Click();
			}
		}



	}
}
