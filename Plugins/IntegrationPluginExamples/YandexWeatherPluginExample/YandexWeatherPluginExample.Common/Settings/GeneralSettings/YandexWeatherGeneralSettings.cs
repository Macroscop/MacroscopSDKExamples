namespace YandexWeatherPluginExample.Settings.GeneralSettings;

[Serializable]
[AlarusSerializable]
public class YandexWeatherGeneralSettings
{
	private const string DefaultToken = "Your key for YandexAPI Weather";
	private const int DefaultDelayMs = 60000;

	private string _apiKey = DefaultToken;
	private int _delay = DefaultDelayMs;

	public string ApiKey
	{
		get { return _apiKey; }
		set { _apiKey = value; }
	}

	public int Delay
	{
		get { return _delay; }
		set { _delay = value; }
	}
}