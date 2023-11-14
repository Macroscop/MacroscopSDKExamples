using Alarus;

namespace YandexWeatherPluginExample;

internal class PluginDefinition : IPlugin
{
	public Guid Id => new Guid("64DBA32D-424B-4F91-8337-3ECF25C84BD8");

	public string Name => YandexWeatherPluginDefinition.PluginName;
	public string Manufacturer => "Example Company";

	public void Initialize(IPluginHost host)
	{
		host.RegisterEventProcessor(typeof(YandexWeatherEventProcessor));
	}
}