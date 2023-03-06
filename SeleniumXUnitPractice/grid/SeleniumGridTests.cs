using OpenQA.Selenium.Remote;


namespace SeleniumXUnitPractice.grid
{
	public class SeleniumGridTests : IDisposable
	{
		IWebDriver driver;
		private bool _passed = false;
		public static string LT_USERNAME = "imamul.karim"; // Add your LambdaTest username here
		public static string LT_ACCESS_KEY = "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7"; // Add your LambdaTest access key here
		public SeleniumGridTests() {

			ChromeOptions capabilities = new ChromeOptions();
			capabilities.BrowserVersion = "110.0";
			Dictionary<string, object> ltOptions = new Dictionary<string, object>();
			ltOptions.Add("username", "imamul.karim");
			ltOptions.Add("accessKey", "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7");
			ltOptions.Add("platformName", "Windows 10");
			ltOptions.Add("project", "SelenuimPractice");
			ltOptions.Add("name", "BasicGridTest");
			ltOptions.Add("timezone", "UTC+06:00");
			ltOptions.Add("w3c", true);
			ltOptions.Add("plugin", "c#-c#");
			capabilities.AddAdditionalOption("LT:Options", ltOptions);


			//var desiredCapabilities = new ReadOnlyDesiredCapabilities();
			//desiredCapabilities.SetCapability(ChromeOptions.Capability, chromeOptions);

			try
			{
				driver = new RemoteWebDriver(new Uri("http://" + LT_USERNAME + ":" + LT_ACCESS_KEY + "@hub.lambdatest.com/wd/hub"), capabilities);
				driver.Manage().Window.Maximize();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}

		[Fact]
		public void AddNewBirthDayItem()
		{
			try
			{
				((IJavaScriptExecutor)driver).ExecuteScript("lambda-name=Birthdaytest" + DateTime.Now.ToString("d"));

				driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");

				driver.Manage().Window.Maximize();

				IWebElement newInputElement = driver.FindElement(By.Id("sampletodotext"));
				var birthdate = new DateTime(1990, 10, 10);
				newInputElement.SendKeys(birthdate.ToString("d"));

				var addButton = driver.FindElement(By.Id("addbutton"));
				addButton.Click();

				var checkBoxesOptions = driver.FindElement(By.XPath("//li[@ng-repeat]"));
				checkBoxesOptions.Click();

				var optionsText = driver.FindElements(By.XPath("//li[@ng-repeat]/span"));

				Assert.Equal("10/20/1990", optionsText.Last().Text);
			}
			catch (Exception ex)
			{
				_passed = false;
				((IJavaScriptExecutor)driver).ExecuteScript("lambda-exceptions", new List<string>() { ex.Message, ex.StackTrace });
				throw;

			}
			finally
			{
				((IJavaScriptExecutor)driver).ExecuteScript("lambda-status-"+ (_passed ? "passed" : "failed"));
			}
		}

		public void Dispose()
		{
			driver.Quit();
		}
	}
}
