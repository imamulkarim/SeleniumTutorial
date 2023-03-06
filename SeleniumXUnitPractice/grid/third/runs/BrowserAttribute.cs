using SeleniumXUnitPractice.grid.third.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.grid.third.runs
{
	internal class BrowserAttribute : BeforeAfterTestAttribute
	{
		public BrowserType Browser { get; set; } = BrowserType.Chrome;

		public BrowserAttribute(BrowserType browser)
		{
			Browser = browser;
		}

		public override void Before(MethodInfo methodUnderTest)
		{
			DriverFixture.Driver.Value?.Dispose();
			DriverFixture.Driver.Value?.Start(Browser, methodUnderTest.Name);
			MainPage.Driver = DriverFixture.Driver;
			TodoPageApp.Driver = DriverFixture.Driver;
			//base.Before(methodUnderTest);
		}
	}
}
