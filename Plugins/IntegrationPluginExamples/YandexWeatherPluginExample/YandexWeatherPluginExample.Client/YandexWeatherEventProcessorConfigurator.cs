using Alarus;
using Alarus.RealTimeFrameProviding;
using YandexWeatherPluginExample.Settings;
using YandexWeatherPluginExample.Settings.GeneralSettings;
using YandexWeatherPluginExample.Settings.ChannelSettings;

namespace YandexWeatherPluginExample;

[PluginGUIName(YandexWeatherPluginDefinition.PluginName)]
[PluginHasSettings]
[EventProcessorConfigurator(YandexWeatherPluginDefinition.EventProcessorTypeId)]
internal class YandexWeatherEventProcessorConfigurator : IEventProcessorConfigurator
{
	public PluginSettings SetSettings(PluginSettings settings)
	{
		var yandexWeatherGeneralSettings = settings.generalSettings as YandexWeatherGeneralSettings
										   ?? new YandexWeatherGeneralSettings();
		var yandexWeatherChannelSettings = settings.channelSpecificSettings as YandexWeatherChannelSettings
										   ?? new YandexWeatherChannelSettings();

		var settingsWindow = new SettingsWindow();
		settingsWindow.ApiKey.Text = yandexWeatherGeneralSettings.ApiKey;
		settingsWindow.Delay.Text = yandexWeatherGeneralSettings.Delay.ToString();
		settingsWindow.Lat.Text = yandexWeatherChannelSettings.Lat.ToString();
		settingsWindow.Lon.Text = yandexWeatherChannelSettings.Lon.ToString();

		var result = settingsWindow.ShowDialog();
		if (result == true)
		{
			int delay;
			if (int.TryParse(settingsWindow.Delay.Text, out delay))
			{
				yandexWeatherGeneralSettings.Delay = delay;
			}

			yandexWeatherGeneralSettings.ApiKey = settingsWindow.ApiKey.Text;

			double lat;
			if (double.TryParse(settingsWindow.Lat.Text.Replace('.', ','), out lat))
			{
				yandexWeatherChannelSettings.Lat = lat;
			}

			double lon;
			if (double.TryParse(settingsWindow.Lon.Text.Replace('.', ','), out lon))
			{
				yandexWeatherChannelSettings.Lon = lon;
			}

			settings.generalSettings = yandexWeatherGeneralSettings;
			settings.channelSpecificSettings = yandexWeatherChannelSettings;
		}

		return settings;
	}
}