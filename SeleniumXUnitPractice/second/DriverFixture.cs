

namespace SeleniumXUnitPractice.second
{
	public abstract class DriverFixture : IDisposable
	{
		public DriverAdapter Driver { get; set; }
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		public DriverFixture()
		{
			Driver = new DriverAdapter();
			InitializeDriver();
		}

		protected abstract void InitializeDriver();
		public virtual int WaitForElementTimeout { get; set; } = WAIT_FOR_ELEMENT_TIMEOUT;

		public void Dispose()
		{
			Driver.Dispose();
		}
	}
}
