namespace SeleniumXUnitPractice.grid.third
{
	public interface IDriverAdapter : IDisposable
	{
		void GotoUrl(string url);
		void Start(BrowserType browserType,string testName="");
		void validateInnerTextIs(IWebElement resultSpan, string expectedText);
		IWebElement WaitAndFindElement(By locator);
		void ExecuteScript(string name, params object[] args);
	}
}