using System;
using Alarus;

namespace ExternalActionExample
{
	[PluginGUIName("External action plugin example")]
	public class PluginDefinition : IPlugin
	{
		public static IMcLogger Logger { get; set; }
		public Guid Id => new Guid("D80F7A8D-D343-4ECC-8496-70DB5B56E829");

		public string Name => "Test external action module";

		public string Manufacturer => "Example Company";

		public void Initialize(IPluginHost host)
		{
			host.RegisterExternalAction(typeof(TestExternalAction));
			Logger = host.GetLogManager().GetLogger("Test external action module");
		}
	}
}