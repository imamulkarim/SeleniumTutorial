using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.grid.third.runs
{
	public class BrowserRunTheroy : IXunitTestCaseDiscoverer
	{
		readonly IMessageSink diagnosticMessageSink;
		readonly TheoryDiscoverer _theoryDiscover;

		public BrowserRunTheroy(IMessageSink diagnosticMessageSink)
		{
			this.diagnosticMessageSink = diagnosticMessageSink;
			_theoryDiscover = new TheoryDiscoverer(diagnosticMessageSink);
		}

		public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
		{
			return _theoryDiscover.Discover(discoveryOptions, testMethod , factAttribute).Select(m=> new BrowserRunTestCase(m));
		}
	}
}
