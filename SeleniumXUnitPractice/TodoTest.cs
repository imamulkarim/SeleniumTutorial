
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass , MaxParallelThreads =4)]
namespace SeleniumXUnitPractice
{
	public class TodoTest : IDisposable
	{
		IWebDriver _driver;
		WebDriverWait _webDriverWait;
		int WAIT_FOR_ELEMENT_TIMEOUT = 30;
		private readonly Actions _actions;
		public TodoTest()
		{
			new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
			_driver = new ChromeDriver();
			_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
			_actions = new Actions(_driver);
		}

		public void Dispose()
		{
			_driver.Quit();
		}
		//[Fact]
		[Theory]
		[InlineData("Backbone.js")]
		[InlineData("AngularJS")]
		[InlineData("React")]
		public void VerifyTodoListCreateSuccessfully(string technology)
		{
			_driver.Navigate().GoToUrl("https://todomvc.com/");
			//OpenTechnologyApp("React");
			OpenTechnologyApp(technology);
			AddNewToDoItem("Clean the car");
			AddNewToDoItem("Clean the house");
			AddNewToDoItem("Buy ketchup");
			GetItemCheckBox("Buy ketchup").Click() ;
			AssertLeftItems(2);
		}

		private void AssertLeftItems(int expectedCount)
		{
			var resultSpan = waitAndFindElement(By.XPath("//footer/span"));
			if(expectedCount <= 0)
			{
				validateInnerTextIs(resultSpan, $"{expectedCount} item left");
			}
			else
			{
				validateInnerTextIs(resultSpan, $"{expectedCount} items left");
			}
		}

		private void validateInnerTextIs(IWebElement resultSpan,string expectedText)
		{
			_webDriverWait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
		}

		private IWebElement waitAndFindElement(By locator)
		{
			return _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
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
			_actions.Click(todoInput).SendKeys(Keys.Enter).Perform();
		}

		private void OpenTechnologyApp(string name)
		{
			var technolgyLink = waitAndFindElement(By.LinkText(name));
			technolgyLink.Click();
		}
	}
}