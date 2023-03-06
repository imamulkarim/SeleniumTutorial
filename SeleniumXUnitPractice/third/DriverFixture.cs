

namespace SeleniumXUnitPractice.third
{
	public abstract class DriverFixture : IDisposable
	{
		public static ThreadLocal<DriverAdapter> Driver { get; set; }
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		public DriverFixture()
		{
			Driver = new ThreadLocal<DriverAdapter>(()=> new DriverAdapter());
			InitializeDriver();
		}

		protected abstract void InitializeDriver();
		public virtual int WaitForElementTimeout { get; set; } = WAIT_FOR_ELEMENT_TIMEOUT;

		public void Dispose()
		{
			Driver.Value.Dispose();
		}
	}
}
