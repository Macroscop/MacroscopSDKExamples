using System;
using System.Runtime.InteropServices;
using Alarus.Events;
using Alarus.RealTimeFrameProviding;

namespace EventProcessorExample.Events
{
	[Serializable]
	[AlarusSerializable]
	[Guid("538B11AE-D583-4A03-BEF9-B52E48DBB778")]
	[EventLocalizedName("Counter event")]
	[EventTreePath("EventTree.User", "EventTree.Client")]
	[EventSaveable(EventSaveMode.SpecialAndUnifiedLog, "counter")]
	public class CounterEvent : RawEvent
	{
		[EventFieldSaveableOrScenariesUsable(orderNum: 0, indexable: true)]
		[EventFieldLocalizedName("Counter")]
		public int Counter;

		public CounterEvent(int count)
		{
			Counter = count;
		}

		public override EventTextDescription GetDescription(IToStringConverter converter)
		{
			var eventText = $"Counter = {Counter}";
			var eventDescription = new EventTextDescription(eventText);
			return eventDescription;
		}
	}
}