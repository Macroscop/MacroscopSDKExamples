using Timer = System.Timers.Timer;
using System.Runtime.InteropServices;
using System.Timers;
using Alarus;
using Alarus.RealTimeFrameProviding;
using YandexWeatherPluginExample.Events;
using YandexWeatherPluginExample.Settings.GeneralSettings;
using YandexWeatherPluginExample.Settings.ChannelSettings;
using System.Globalization;

namespace YandexWeatherPluginExample;

[PluginGUIName(YandexWeatherPluginDefinition.PluginName)]
[PluginHasSettings]
[Guid(YandexWeatherPluginDefinition.EventProcessorTypeId)]
public class YandexWeatherEventProcessor : EventProcessor
{
	private YandexWeatherChannelSettings _channelSettings = new();
	private YandexWeatherGeneralSettings _generalSettings = new();
	private static readonly HttpClient Client = new();
	private Timer _timer;

	public override void Initialize(PluginSettings settings)
	{
		var isSettingsInitialized = settings.generalSettings != null && settings.channelSpecificSettings != null;

		if (!isSettingsInitialized)
			return;

		_generalSettings = (YandexWeatherGeneralSettings)settings.generalSettings;
		_channelSettings = (YandexWeatherChannelSettings)settings.channelSpecificSettings;

		_timer = new Timer(_generalSettings.Delay);
		_timer.Elapsed += OnTimedEvent;
		_timer.AutoReset = true;
		_timer.Enabled = true;
	}

	public override PluginSettings SetSettings(PluginSettings settings)
	{
		throw new NotImplementedException("SetSettings moved to IEventProcessorConfigurator");
	}

	public override void Dispose()
	{
		if (_timer == null)
			return;
		_timer.Elapsed -= OnTimedEvent;
		_timer.Stop();
		_timer.Dispose();
	}

	private async void OnTimedEvent(object sender, ElapsedEventArgs e)
	{
		try
		{
			var requestApi = GetApiUrl(_channelSettings.Lat, _channelSettings.Lon);
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(requestApi),
				Method = HttpMethod.Get,
			};
			request.Headers.Add("X-Yandex-API-Key", _generalSettings.ApiKey);
			var weatherResponse = await Client.SendAsync(request);
			var weatherJson = await weatherResponse.Content.ReadAsStringAsync();
			var weather = System.Text.Json.JsonDocument.Parse(weatherJson);
			var temperature = weather.RootElement
				.GetProperty("fact")
				.GetProperty("temp")
				.GetInt32();
			var city = weather.RootElement
				.GetProperty("info")
				.GetProperty("tzinfo")
				.GetProperty("name")
				.GetString();

			var yandexWeatherEvent = new YandexWeatherEvent(temperature, city);
			GenerateEvent(externalEvent: yandexWeatherEvent, generateAlarm: false);
		}
		catch (Exception ex)
		{
			YandexWeatherPluginDefinition.Logger.LogException(ex, "Error getting weather");
		}
	}

	private string GetApiUrl(double lat, double lon, string lang = "en_US")
	{
		return
			$"https://api.weather.yandex.ru/v2/forecast?lat={lat.ToString(CultureInfo.InvariantCulture)}&lon={lon.ToString(CultureInfo.InvariantCulture)}&lang={lang}&limit=7&hours=false&extra=false";
	}
}