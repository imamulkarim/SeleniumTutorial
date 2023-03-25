using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using NUnit.Framework;

namespace SeleniumNUnitPractice
{
	public class SeleniumUnitTest
	{
		//
		IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new EdgeDriver();
		}

		[Test, Order(1)]
		public void ValidateTheMessageIsDisplayed()
		{
			driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/simple-form-demo");
			driver.FindElement(By.Id("user-message")).SendKeys("LambdaTest rules");
			driver.FindElement(By.Id("showInput")).Click();
			Assert.IsTrue(driver.FindElement(By.Id("message")).Text.Equals("LambdaTest rules"), "The expected message was not displayed.");
		}

		[Test]
		public void ValidateTheSumIsDisplayed()
		{
			driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/simple-form-demo");
			driver.FindElement(By.Id("sum1")).SendKeys("1");
			driver.FindElement(By.Id("sum2")).SendKeys("2");
			driver.FindElement(By.XPath("//button[text()='Get values']")).Click();
			Assert.IsTrue(driver.FindElement(By.Id("addmessage")).Text.Equals("3"), "The expected sum was not displayed.");
		}
		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}

	}
}