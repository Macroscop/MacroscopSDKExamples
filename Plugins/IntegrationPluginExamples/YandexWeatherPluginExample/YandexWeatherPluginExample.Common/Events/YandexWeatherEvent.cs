using System.Runtime.InteropServices;
using Alarus.RealTimeFrameProviding;
using Alarus.Events;

namespace YandexWeatherPluginExample.Events;

[Guid("2BE06060-4C04-4EA8-B24E-90525482B84A")]
[Serializable]
[AlarusSerializable]
[EventLocalizedName("YandexWeatherEvent")]
[EventTreePath("EventTree.User", "EventTree.Client")]
[EventSaveable(EventSaveMode.SpecialAndUnifiedLog, "yandexweather")]
public class YandexWeatherEvent : RawEvent
{
	[EventFieldSaveableOrScenariesUsable(orderNum: 0, indexable: false, isUnifiedLogField: true)]
	[EventFieldLocalizedName("Temperature")]
	public int Temperature;

	[EventFieldSaveableOrScenariesUsable(orderNum: 1, indexable: false, isUnifiedLogField: true)]
	[EventFieldLocalizedName("City")]
	public string City;

	public YandexWeatherEvent(int temperature, string city)
	{
		Temperature = temperature;
		City = city;
	}

	public override EventTextDescription GetDescription(IToStringConverter converter)
	{
		var eventText = $"Current temperature - {Temperature}°C, Current city - {City}";
		var eventDescription = new EventTextDescription(eventText);
		return eventDescription;
	}
}