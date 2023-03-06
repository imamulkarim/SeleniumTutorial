

namespace SeleniumXUnitPractice
{
	public class TodoTestParallel : IClassFixture<DriverFixture>
	{
		//IWebDriver _driver;
		//WebDriverWait _webDriverWait;
		//private readonly Actions _actions;
		//public TodoTestParallel()
		//{
		//	new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
		//	_driver = new ChromeDriver();
		//	_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
		//	_actions = new Actions(_driver);
		//}

		private readonly DriverFixture _fixture;

		public TodoTestParallel(DriverFixture fixture)
		{
			this._fixture = fixture;
		}

		//public void Dispose()
		//{
		//	_driver.Quit();
		//}
		//[Fact]
		[Theory]
		[InlineData("Vanilla JS")]
		//[InlineData("JQuery")]
		[InlineData("Dojo")]
		public void VerifyTodoListCreateSuccessfully(string technology)
		{
			_fixture.Driver.Navigate().GoToUrl("https://todomvc.com/");
			//OpenTechnologyApp("React");
			OpenTechnologyApp(technology);
			AddNewToDoItem("Clean the car");
			AddNewToDoItem("Clean the house");
			AddNewToDoItem("Buy ketchup");
			GetItemCheckBox("Buy ketchup").Click();
			AssertLeftItems(2);
		}

		private void AssertLeftItems(int expectedCount)
		{
			var resultSpan = waitAndFindElement(By.XPath("//footer/span"));
			if (expectedCount <= 0)
			{
				validateInnerTextIs(resultSpan, $"{expectedCount} item left");
			}
			else
			{
				validateInnerTextIs(resultSpan, $"{expectedCount} items left");
			}
		}

		private void validateInnerTextIs(IWebElement resultSpan, string expectedText)
		{
			_fixture.WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
		}

		private IWebElement waitAndFindElement(By locator)
		{
			return _fixture.WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
		}

		private IWebElement GetItemCheckBox(string todoItem)
		{
			var checkItem = waitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
			return checkItem;
		}

		private void AddNewToDoItem(string todoItem)
		{
			var todoInput = waitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
			todoInput.SendKeys(todoItem);
			todoInput.SendKeys(Keys.Enter);
			//_actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
		}

		private void OpenTechnologyApp(string name)
		{
			var technolgyLink = waitAndFindElement(By.LinkText(name));
			technolgyLink.Click();
		}
	}
}
