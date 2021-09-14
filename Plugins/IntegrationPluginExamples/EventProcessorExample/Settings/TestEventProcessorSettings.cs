using System;

namespace EventProcessorExample.Settings
{
	[Serializable]
	[AlarusSerializable]
	public class TestEventProcessorSettings
	{
		private int _delay = 5000;

		public int Delay
		{
			get { return _delay; }
			set { _delay = value; }
		}
	}
}