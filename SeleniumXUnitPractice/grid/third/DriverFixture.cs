

namespace SeleniumXUnitPractice.grid.third
{
	public abstract class DriverFixture : IDisposable
	{
		public static ThreadLocal<IDriverAdapter> Driver { get; set; }
		public static ThreadLocal<string> TestName { get; set; }
		private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;

		public DriverFixture()
		{
#if (DEBUG)
			Driver = new ThreadLocal<IDriverAdapter>(()=> new DriverAdapter());
#elif (RELEASE)
			Driver = new ThreadLocal<IDriverAdapter>(()=> new CloudDriverAdapter());
#else
	throw new Exception("Invlaid arguments")
#endif
			//InitializeDriver();
		}

		//protected abstract void InitializeDriver();
		public virtual int WaitForElementTimeout { get; set; } = WAIT_FOR_ELEMENT_TIMEOUT;

		public void Dispose()
		{
			Driver.Value.Dispose();
		}
	}
}
