namespace YandexWeatherPluginExample.Settings.ChannelSettings;

[Serializable]
[AlarusSerializable]
public class YandexWeatherChannelSettings
{
	private const double DefaultLat = 55.75396;
	private const double DefaultLon = 37.620393;

	private double _lat = DefaultLat;
	private double _lon = DefaultLon;

	public double Lat
	{
		get { return _lat; }
		set { _lat = value; }
	}

	public double Lon
	{
		get { return _lon; }
		set { _lon = value; }
	}
}