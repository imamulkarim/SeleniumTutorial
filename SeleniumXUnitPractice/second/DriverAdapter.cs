


namespace SeleniumXUnitPractice.second
{
	public class DriverAdapter : IDisposable
	{
		IWebDriver _driver;
		WebDriverWait _webDriverWait;
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
		
		public void Start(BrowserType browserType)
		{
			switch (browserType)
			{
				case BrowserType.Chrome:
					new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
					_driver = new ChromeDriver();
					break;
				case BrowserType.FireFox:
					var config = new FirefoxConfig();
					new DriverManager().SetUpDriver(config, VersionResolveStrategy.Latest);
					_driver = new FirefoxDriver();
					break;
				default:
					break;
			}

			
			_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
			_driver.Manage().Window.Maximize();
		}

		public void GotoUrl(string url) { 
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
	}
}
