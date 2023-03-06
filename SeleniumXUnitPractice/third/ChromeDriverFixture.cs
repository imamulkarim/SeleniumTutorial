using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumXUnitPractice.third
{
	public class ChromeDriverFixture : DriverFixture
	{
		protected override void InitializeDriver()
		{
			Driver.Value.Start(BrowserType.Chrome);
		}

		public override int WaitForElementTimeout => 40; 
	}
}
