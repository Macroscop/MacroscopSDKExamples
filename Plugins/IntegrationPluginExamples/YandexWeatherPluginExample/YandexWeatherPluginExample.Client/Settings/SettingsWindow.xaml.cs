using System.Windows;

namespace YandexWeatherPluginExample.Settings;

internal partial class SettingsWindow : Window
{
	internal SettingsWindow() => InitializeComponent();

	private void OKButton_Click(object sender, RoutedEventArgs e)
	{
		DialogResult = true;
		Close();
	}

	private void CancelButton_Click(object sender, RoutedEventArgs e)
	{
		DialogResult = false;
		Close();
	}
}