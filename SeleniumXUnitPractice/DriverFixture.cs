

namespace SeleniumXUnitPractice
{
	public class DriverFixture : IDisposable
	{
		public IWebDriver Driver { get; set; }
		public WebDriverWait WebDriverWait { get; set; }
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		public DriverFixture()
		{
			new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
			Driver = new ChromeDriver();
			WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
		}

		public void Dispose()
		{
			Driver.Quit();
		}
	}
}
