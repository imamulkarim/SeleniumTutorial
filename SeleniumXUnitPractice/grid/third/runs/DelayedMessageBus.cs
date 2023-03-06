using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SeleniumXUnitPractice.third.runs
{
	public class DelayedMessageBus : IMessageBus
	{
		private readonly IMessageBus _messageBus;
		private readonly List<IMessageSinkMessage> messages= new List<IMessageSinkMessage>();

		public DelayedMessageBus(IMessageBus messageBus)
		{
			_messageBus = messageBus;
		}

		public void Dispose()
		{
			foreach (var message in messages)
				_messageBus.QueueMessage(message);
		}

		public bool QueueMessage(IMessageSinkMessage message)
		{
			lock(messages)
			{
				messages.Add(message);
			}
			return true;
		}
	}
}
