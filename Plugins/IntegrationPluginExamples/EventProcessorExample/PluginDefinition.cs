using System;
using Alarus;
using EventProcessorExample.Events;

namespace EventProcessorExample
{
	public class PluginDefinition : IPlugin
	{
		public Guid Id => new Guid("87C33587-4CEA-4950-97CC-C9A7C8668CD6");

		public string Name => "Event processor example";

		public string Manufacturer => "Example Company";

		public void Initialize(IPluginHost host)
		{
			host.RegisterExternalEvent(typeof(CounterEvent));
			host.RegisterEventProcessor(typeof(TestEventProcessor));
		}
	}
}