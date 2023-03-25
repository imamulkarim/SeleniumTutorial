using OpenQA.Selenium.DevTools.V108.WebAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.grid.third.runs
{

	public class BrowserRunTestCase : LongLivedMarshalByRefObject , IXunitTestCase
	{
		public string DisplayName { get { return testCase.DisplayName; } }

		public string SkipReason { get { return testCase.SkipReason; } }

		public ISourceInformation SourceInformation { 
			get { return testCase.SourceInformation; } 
			set { testCase.SourceInformation = value; } 
		}
		public ITestMethod TestMethod { get { return testCase.TestMethod; } }
		public object[] TestMethodArguments { get { return testCase.TestMethodArguments; } }

		public Dictionary<string, List<string>> Traits
		{
			get { return testCase.Traits; }
		}

		public Exception InitializationException { get; set; }
		public int Timeout { get; set; }
		public IMethodInfo Method => throw new NotImplementedException();

		public string UniqueID => throw new NotImplementedException();

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
		public BrowserRunTestCase()
		{
		}

		IXunitTestCase testCase;

		public BrowserRunTestCase(IXunitTestCase testCase)
		{
			this.testCase = testCase;
		}

		public Task<RunSummary> RunAsync(
			IMessageSink diagnosticMessageSink,
			IMessageBus messageBus,
			object[] constructorArgument,
			ExceptionAggregator aggregator,
			CancellationTokenSource cancellationToken
			)
		{
			var delayedMessageBus = new DelayedMessageBus(messageBus);
			var summary = testCase.RunAsync(diagnosticMessageSink, messageBus, constructorArgument, aggregator, cancellationToken);
			//testCase.DisplayName
			DriverFixture.Driver.Value?.ExecuteScript($"lalbda-name={testCase.DisplayName}");
			if(aggregator.HasExceptions || summary.Result.Failed != 0)
			{
#if (RELEASE)
	            try {
				DriverFixture.Driver.Value?.ExecuteScript($"lalbda-status-failed");
				DriverFixture.Driver.Value?.ExecuteScript($"lalbda-exceptions", $"{aggregator.ToException()?.Message}{Environment.NewLine}{aggregator.ToException()?.StackTrace}");
				} 
				catch (Exception ex) {
				 Console.WriteLine(ex);
				}
#endif
				delayedMessageBus.Dispose();
			}
			else
			{
#if (RELEASE)
				DriverFixture.Driver.Value?.ExecuteScript($"lalbda-status-passed");
#endif

			}
			return summary;
		}
		public void Deserialize(IXunitSerializationInfo info)
		{
			testCase = info.GetValue<IXunitTestCase>("InnerTestCase");
		}

		public void Serialize(IXunitSerializationInfo info)
		{
			info.AddValue("InnerTestCase", testCase);
		}
		//[EditorBrowsable(EditorBrowsableState.Never)]
		//[Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
		//public BrowserRunTestCase() { }

		//public BrowserRunTestCase(IMessageSink diagnosticMessageSink, TestMethodDisplay testMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod)
		//	: base(diagnosticMessageSink, testMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
		//{

		//}

		//// This method is called by the xUnit test framework classes to run the test case. We will do the
		//// loop here, forwarding on to the implementation in XunitTestCase to do the heavy lifting. We will
		//// continue to re-run the test until the aggregator has an error (meaning that some internal error
		//// condition happened), or the test runs without failure, or we've hit the maximum number of tries.
		//public override async Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink,
		//												IMessageBus messageBus,
		//												object[] constructorArguments,
		//												ExceptionAggregator aggregator,
		//												CancellationTokenSource cancellationTokenSource)
		//{
		//	var runCount = 0;

		//	while (true)
		//	{
		//		// This is really the only tricky bit: we need to capture and delay messages (since those will
		//		// contain run status) until we know we've decided to accept the final result;
		//		var delayedMessageBus = new DelayedMessageBus(messageBus);

		//		var summary = await base.RunAsync(diagnosticMessageSink, delayedMessageBus, constructorArguments, aggregator, cancellationTokenSource);

		//		diagnosticMessageSink.OnMessage(new DiagnosticMessage("Execution of '{0}' failed (attempt #{1}), retrying...", DisplayName, runCount));
		//	}
		//}

		//public override void Serialize(IXunitSerializationInfo data)
		//{
		//	base.Serialize(data);
		//}

		//public override void Deserialize(IXunitSerializationInfo data)
		//{
		//	base.Deserialize(data);
		//}

	}
}
