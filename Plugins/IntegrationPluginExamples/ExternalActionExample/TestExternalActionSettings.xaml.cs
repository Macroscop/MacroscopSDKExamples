using System.Windows.Controls;
using Alarus.GUI.Action_;

namespace ExternalActionExample
{
	[RegisterSettingsControl(typeof(TestExternalAction))]
	public partial class TestExternalActionSettings : UserControl
	{
		public TestExternalActionSettings()
		{
			InitializeComponent();
		}
	}
}