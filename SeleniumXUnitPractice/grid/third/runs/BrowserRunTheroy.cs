using SeleniumXUnitPractice.third.runs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.third
{
	public class BrowserRunTheroy : IXunitTestCaseDiscoverer
	{
		readonly IMessageSink diagnosticMessageSink;

		public BrowserRunTheroy(IMessageSink diagnosticMessageSink)
		{
			this.diagnosticMessageSink = diagnosticMessageSink;
		}

		public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
		{
			yield return new BrowserRunTestCase(diagnosticMessageSink,discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod);
		}
	}
}
