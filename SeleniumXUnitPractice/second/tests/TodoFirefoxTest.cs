

namespace SeleniumXUnitPractice.second
{
	public class TodoFirefoxTest : IClassFixture<FirefoxDriverFixture>
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

		private readonly FirefoxDriverFixture _fixture;

		public TodoFirefoxTest(FirefoxDriverFixture fixture)
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
			_fixture.Driver.GotoUrl("https://todomvc.com/");
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
			var resultSpan = _fixture.Driver.WaitAndFindElement(By.XPath("//footer/span"));
			if (expectedCount <= 0)
			{
				_fixture.Driver.validateInnerTextIs(resultSpan, $"{expectedCount} item left");
			}
			else
			{
				_fixture.Driver.validateInnerTextIs(resultSpan, $"{expectedCount} items left");
			}
		}

		//private void validateInnerTextIs(IWebElement resultSpan, string expectedText)
		//{
		//	_fixture.Driver.WebDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
		//}

		//private IWebElement waitAndFindElement(By locator)
		//{
		//	return _fixture.WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
		//}

		private IWebElement GetItemCheckBox(string todoItem)
		{
			var checkItem = _fixture.Driver.WaitAndFindElement(By.XPath($"//label[text()='{todoItem}']/preceding-sibling::input"));
			return checkItem;
		}

		private void AddNewToDoItem(string todoItem)
		{
			var todoInput = _fixture.Driver.WaitAndFindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
			todoInput.SendKeys(todoItem);
			todoInput.SendKeys(Keys.Enter);
			//_actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
		}

		private void OpenTechnologyApp(string name)
		{
			var technolgyLink = _fixture.Driver.WaitAndFindElement(By.LinkText(name));
			technolgyLink.Click();
		}
	}
}
