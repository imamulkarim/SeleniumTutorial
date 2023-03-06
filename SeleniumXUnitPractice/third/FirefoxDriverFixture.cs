using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third
{
	public class FirefoxDriverFixture : DriverFixture
	{
		protected override void InitializeDriver()
		{
			Driver.Value.Start(BrowserType.FireFox);
		}

		public override int WaitForElementTimeout => 30; 
	}
}
