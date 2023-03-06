using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;

namespace SeleniumNUnitPractice
{
	
	public class SeleniumGridTest
	{
		IWebDriver driver;

		public static string gridURL = "@hub.lambdatest.com/wd/hub";
		public static string LT_USERNAME = "imamul.karim"; // Add your LambdaTest username here
		public static string LT_ACCESS_KEY = "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7"; // Add your LambdaTest access key here


		[SetUp]
		public void Setup()
		{
			//driver = new EdgeDriver();
			ChromeOptions capabilities = new ChromeOptions();
			capabilities.BrowserVersion = "110.0";
			Dictionary<string, object> ltOptions = new Dictionary<string, object>();
			ltOptions.Add("username", "imamul.karim");
			ltOptions.Add("accessKey", "3l9iKv6PJimn3XKwGGclAKUjwkGKUKXRAYoEYEJNPEK4akYld7");
			ltOptions.Add("platformName", "Windows 10");
			ltOptions.Add("project", "Untitled");
			ltOptions.Add("w3c", true);
			ltOptions.Add("plugin", "c#-c#");
			capabilities.AddAdditionalOption("LT:Options", ltOptions);


			//var desiredCapabilities = new ReadOnlyDesiredCapabilities();
			//desiredCapabilities.SetCapability(ChromeOptions.Capability, chromeOptions);

			try
			{
				driver = new RemoteWebDriver(new Uri("http://" + LT_USERNAME + ":" + LT_ACCESS_KEY + "@hub.lambdatest.com/wd/hub") , capabilities);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			//var desiredCapabilities = new DesiredCapabilities("Chrome","101", "Windows 11");
			////desiredCapabilities.SetCapability("browserName", "Chrome");
			////desiredCapabilities.SetCapability("platform", "Windows 11");
			////desiredCapabilities.SetCapability("version", "101.0");
			//desiredCapabilities.SetCapability("screenResolution", "1280x800");
			//desiredCapabilities.SetCapability("user", LT_USERNAME);
			//desiredCapabilities.SetCapability("accessKey", LT_ACCESS_KEY);
			//desiredCapabilities.SetCapability("build", "Selenium C-Sharp");
			//desiredCapabilities.SetCapability("name", "Selenium Test");
			//driver = new RemoteWebDriver(new Uri("https://" + LT_USERNAME + ":" + LT_ACCESS_KEY + gridURL), capabilities, TimeSpan.FromSeconds(600));


		}

		[Test]
		public void ValidateTheMessageIsDisplayed()
		{
			driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/simple-form-demo");
			driver.FindElement(By.Id("user-message")).SendKeys("LambdaTest rules");
			driver.FindElement(By.Id("showInput")).Click();
			Assert.IsTrue(driver.FindElement(By.Id("message")).Text.Equals("LambdaTest rules"), "The expected message was not displayed.");
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}

	}
}
