using Alarus;
using YandexWeatherPluginExample.Events;
using System.Runtime.InteropServices;

namespace YandexWeatherPluginExample;

[PluginGUIName(PluginName)]
[Guid("0A069D9D-A8C3-4AD7-9AB9-42E33840F75A")]
public class YandexWeatherPluginDefinition : IPlugin
{
	public const string PluginName = "Yandex weather plugin";

	public Guid Id => new Guid("BA0C04C9-E9C4-432E-8E49-4F872CA31875");

	public string Name => PluginName;

	public string Manufacturer => "Example Company";

	public static IMcLogger Logger { get; private set; }

	public const string EventProcessorTypeId = "A7CCFFC9-108F-47F1-A5B7-9532B9BD1193";

	public void Initialize(IPluginHost host)
	{
		host.RegisterExternalEvent(typeof(YandexWeatherEvent));
		Logger = host.GetLogManager()
			.GetLogger("WeatherPlugin");
	}
}