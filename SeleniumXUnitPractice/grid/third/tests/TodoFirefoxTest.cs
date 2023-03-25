

using SeleniumXUnitPractice.grid.third.runs;

namespace SeleniumXUnitPractice.grid.third
{
	public class TodoFirefoxTest : IClassFixture<DriverFixture>,IClassFixture<TestDataFixture> 
	{
		
		//3.34
		//private readonly FirefoxDriverFixture _fixture;
		//private readonly PagesFixture _pageFixture;
		private readonly TestDataFixture _testFixture;

		public TodoFirefoxTest(
			DriverFixture fixture, 
			TestDataFixture testFixture
			//,PagesFixture pageFixture
			)
		{
			//this._fixture = fixture;
			//_pageFixture= pageFixture;
			_testFixture = testFixture;
		}

		//public void Dispose()
		//{
		//	_driver.Quit();
		//}
		//[Fact]
		//[Theory]
		[BrowserRunTheroy]
		[InlineData("Vanilla JS")]
		//[InlineData("JQuery")]
		[InlineData("Dojo")]
		[Browser(BrowserType.FireFox)]
		public void VerifyTodoListCreateSuccessfully(string technology)
		{
			
			ToDoFacade.VerifyTodoListCreateSuccessfully(technology, _testFixture.itemToAdd, _testFixture.itemToCheck, _testFixture.ExpectedItemsLeft);
		}

	}
}
