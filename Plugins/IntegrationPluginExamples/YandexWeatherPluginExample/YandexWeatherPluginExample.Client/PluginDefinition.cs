using Alarus;
using System.Runtime.InteropServices;

namespace YandexWeatherPluginExample;

[PluginGUIName(YandexWeatherPluginDefinition.PluginName)]
[Guid("85D52150-BD22-406C-940D-A68BE888928B")]
[PluginHasSettings]
internal class PluginDefinition : IPlugin
{
	public Guid Id => new Guid("A9BC4585-FBEE-45E8-8073-E298ADF0D24B");

	public string Name => YandexWeatherPluginDefinition.PluginName;

	public string Manufacturer => "Example Company";

	public void Initialize(IPluginHost host)
	{
		var requiredPluginIDs = new List<Guid>
		{
			Guid.Parse(YandexWeatherPluginDefinition.EventProcessorTypeId)
		};

		var eventProcessorTypeId = Guid.Parse(YandexWeatherPluginDefinition.EventProcessorTypeId);
		host.RegisterEventProcessorConfigurator(eventProcessorTypeId,
			typeof(YandexWeatherEventProcessorConfigurator));
		host.RegisterRTVisualizer(typeof(YandexWeatherVisualizer), requiredPluginIDs);
	}
}