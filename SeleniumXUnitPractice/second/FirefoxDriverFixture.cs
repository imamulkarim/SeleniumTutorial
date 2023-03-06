using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.second
{
	public class FirefoxDriverFixture : DriverFixture
	{
		protected override void InitializeDriver()
		{
			Driver.Start(BrowserType.FireFox);
		}

		public override int WaitForElementTimeout => 30; 
	}
}
