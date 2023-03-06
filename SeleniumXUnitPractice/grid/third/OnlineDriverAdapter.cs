


using OpenQA.Selenium.Remote;

namespace SeleniumXUnitPractice.grid.third
{
	public class OnlineDriverAdapter : IDriverAdapter
	{
		IWebDriver _driver;
		WebDriverWait _webDriverWait;
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		private bool _passed = false;
		public static string LT_USERNAME = "imamul.karim"; // Add your LambdaTest username here
		public static string LT_ACCESS_KEY = "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7"; // Add your LambdaTest access key here

		public void Start(BrowserType browserType, string testName = "")
		{

			dynamic capabilities = default(ChromeOptions);
			capabilities.BrowserVersion = "110.0";
			


			switch (browserType)
			{
				case BrowserType.Chrome:
					capabilities = new ChromeOptions();
					capabilities.BrowserVersion = "110.0";
					break;
				case BrowserType.FireFox:
					capabilities = new FirefoxOptions();
					capabilities.BrowserVersion = "90.0";
					break;
				default:
					break;
			}
			
			Dictionary<string, object> ltOptions = new Dictionary<string, object>();
			ltOptions.Add("username", "imamul.karim");
			ltOptions.Add("accessKey", "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7");
			ltOptions.Add("platformName", "Windows 10");
			ltOptions.Add("project", "SelenuimPractice");
			ltOptions.Add("build", Guid.NewGuid().ToString());
			ltOptions.Add("name", testName);
			ltOptions.Add("timezone", "UTC+06:00");
			ltOptions.Add("w3c", true);
			ltOptions.Add("plugin", "c#-c#");
			capabilities.AddAdditionalOption("LT:Options", ltOptions);

			_driver = new RemoteWebDriver(new Uri("http://" + LT_USERNAME + ":" + LT_ACCESS_KEY + "@hub.lambdatest.com/wd/hub"), capabilities);

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
			_driver?.Quit();
		}

		public void ExecuteScript(string name, params object[] args)
		{
			var javascriptExecutor = (IJavaScriptExecutor)_driver;
			javascriptExecutor.ExecuteScript(name, args);
		}
	}
}
