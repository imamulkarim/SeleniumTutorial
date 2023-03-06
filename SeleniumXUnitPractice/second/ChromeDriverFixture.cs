using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.second
{
	public class ChromeDriverFixture : DriverFixture
	{
		protected override void InitializeDriver()
		{
			Driver.Start(BrowserType.Chrome);
		}

		public override int WaitForElementTimeout => 40; 
	}
}
