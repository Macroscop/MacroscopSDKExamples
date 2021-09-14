using System;
using System.Runtime.InteropServices;
using Alarus.Action_;
using Alarus.RealTimeFrameProviding;

namespace ExternalActionExample
{
	[ActionGUILocalizedName("Test external action")]
	[ActionTargetHost(ActionTarget.Server)]
	[Guid("4033F971-B8B6-4D2D-A0EB-7723536307D2")]
	[Serializable]
	[AlarusSerializable]
	public class TestExternalAction : ExternalAction
	{
		private int _testNumber;
		public override bool IsConfigurated { get; } = true;
		public override string Description { get; } = string.Empty;

		public int TestNumber
		{
			get { return _testNumber; }
			set { _testNumber = value; }
		}

		public override void Run(RawEvent rawEvent)
		{
			//Do necessary work.

			PluginDefinition.Logger.LogInfo($"Test External Action. TestNumber = {_testNumber}");
		}
	}
}