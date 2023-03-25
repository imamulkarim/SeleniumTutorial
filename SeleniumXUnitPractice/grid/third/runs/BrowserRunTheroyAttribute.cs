using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.grid.third.runs
{
	[XunitTestCaseDiscoverer("SeleniumXUnitPractice.grid.third.runs", "SeleniumXUnitPractice.grid.third")]
	public class BrowserRunTheroyAttribute : TheoryAttribute
	{
		//public int MaxRetries { get; set; }
	}
}
