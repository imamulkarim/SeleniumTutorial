

namespace SeleniumXUnitPractice.third
{
	public class TodoFirefoxTest : IClassFixture<FirefoxDriverFixture> , IClassFixture<TestDataFixture> , IClassFixture<PagesFixture>
	{
		

		private readonly FirefoxDriverFixture _fixture;
		private readonly PagesFixture _pageFixture;
		private readonly TestDataFixture _testFixture;

		public TodoFirefoxTest(FirefoxDriverFixture fixture, TestDataFixture testFixture, PagesFixture pageFixture)
		{
			this._fixture = fixture;
			_pageFixture= pageFixture;
			_testFixture = testFixture;
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
			
			_pageFixture.ToDoFacade.VerifyTodoListCreateSuccessfully(technology, _testFixture.itemToAdd, _testFixture.itemToCheck, _testFixture.ExpectedItemsLeft);
		}

	}
}
