using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice
{
	public class SeleniumHeadlessTests
	{
		[Fact]
		public void TitleIsEqualToSamplePage_When_NavigateToHome()
		{
			new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

			var chromeOptions = new ChromeOptions();
			chromeOptions.AddArgument("--headless");

			using var _driver = new ChromeDriver(chromeOptions);

			_driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app");
			_driver.Manage().Window.Maximize();

			Assert.Equal("Sample page - lambdatest.com",_driver.Title);
		}
	}
}
