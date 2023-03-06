using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.third
{
	[XunitTestCaseDiscoverer("SeleniumXUnitPractice.third.BrowserRunAttribute", "SeleniumXUnitPractice.third")]
	public class BrowserRunAttribute
	{
		public int MaxRetries { get; set; }
	}
}
