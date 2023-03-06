


namespace SeleniumXUnitPractice.grid.third
{
	public class DriverAdapter : IDriverAdapter
	{
		IWebDriver _driver;
		WebDriverWait _webDriverWait;
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		public void Start(BrowserType browserType, string testName = "")
		{
			switch (browserType)
			{
				case BrowserType.Chrome:
					new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
					_driver = new ChromeDriver();
					break;
				case BrowserType.FireFox:
					new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.Latest);
					_driver = new FirefoxDriver();
					break;
				default:
					break;
			}


			_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
			_driver.Manage().Window.Maximize();
		}

		public void GotoUrl(string url)
		{
			_driver.Navigate().GoToUrl(url);
		}

		public void validateInnerTextIs(IWebElement resultSpan, string expectedText)
		{
			_webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
		}

		public IWebElement WaitAndFindElement(By locator)
		{
			return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
		}

		public void Dispose()
		{
			_driver.Quit();
		}

		public void ExecuteScript(string name, params object[] args)
		{
			var javascriptExecutor = (IJavaScriptExecutor)_driver;
			javascriptExecutor.ExecuteScript(name, args);
		}
	}
}
