using Alarus;
using Alarus.GUI;
using Alarus.RealTimeFrameProviding;
using System.Windows.Controls;
using System.Windows.Media;
using YandexWeatherPluginExample.Events;

namespace YandexWeatherPluginExample;

public class YandexWeatherVisualizer : PluginVisualiser
{
	private TextBlock _weatherTextBlock;

	public YandexWeatherVisualizer(Guid analystPluginId)
		: base(analystPluginId)
	{
	}

	public override DrawingVisual NullableDrawingVisual => null;

	public override void Initialize(Guid channelId, IPluginClientToolSet pluginClientToolset, IPluginVisualizerSet visualiserSet)
	{
		base.Initialize(channelId, pluginClientToolset, visualiserSet);
		_weatherTextBlock = new TextBlock();
		ControlsContrainer.Children.Add(_weatherTextBlock);
		_weatherTextBlock.Text = "Current weather: Unknown";
		_weatherTextBlock.FontSize = 20;
		_weatherTextBlock.Background = Brushes.Brown;
		_weatherTextBlock.Foreground = Brushes.Bisque;
		Canvas.SetTop(_weatherTextBlock, 20);
		Canvas.SetLeft(_weatherTextBlock, 20);
	}

	public override async void ProcessEvent(Guid channelId, RawEvent chEv, bool isAlarm)
	{
		if (chEv is not YandexWeatherEvent yandexWeatherEvent)
			return;

		await UpdateWeatherTextBlockAsync(yandexWeatherEvent);
	}

	public override void Clear()
	{
	}

	private async Task UpdateWeatherTextBlockAsync(YandexWeatherEvent yandexWeatherEvent)
	{
		await _weatherTextBlock.Dispatcher.InvokeAsync(() =>
		{
			_weatherTextBlock.Text = $"Current temperature: {yandexWeatherEvent.Temperature}°C "
									 + Environment.NewLine
									 + $"Current city: {yandexWeatherEvent.City}";
		});
	}
}