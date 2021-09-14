using System.Windows;

namespace EventProcessorExample.Settings
{
	public partial class SettingsWindow
	{
		public SettingsWindow()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}