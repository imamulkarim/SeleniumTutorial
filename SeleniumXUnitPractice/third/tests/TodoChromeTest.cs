

namespace SeleniumXUnitPractice.third
{
	public class TodoChromeTest : IClassFixture<ChromeDriverFixture> , IClassFixture<PagesFixture>
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

		private readonly ChromeDriverFixture _fixture;
		private readonly PagesFixture _pageFixture;

		public TodoChromeTest(ChromeDriverFixture fixture, PagesFixture pageFixture)
		{
			this._fixture = fixture;
			_pageFixture = pageFixture;
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
			//_fixture.Driver.Value.GotoUrl("https://todomvc.com/");
			////OpenTechnologyApp("React");
			//OpenTechnologyApp(technology);
			//AddNewToDoItem("Clean the car");
			//AddNewToDoItem("Clean the house");
			//AddNewToDoItem("Buy ketchup");
			//GetItemCheckBox("Buy ketchup").Click();
			//AssertLeftItems(2);
			var itemsToAdd = new List<string>() { "Clean the car", "Clean the house", "Buy ketchup" };
			var itemsToCheck = new List<string>() {  "Buy ketchup" };

			_pageFixture.ToDoFacade.VerifyTodoListCreateSuccessfully(technology,itemsToAdd,itemsToCheck,2);
		}

	}
}
