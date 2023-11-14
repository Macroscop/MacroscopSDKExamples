# Yandex Weather Plugin Example

## Configuring and description

The example weather visualizer plugin demonstrates the work of MacroscopSDK plugins EventProcessor, PluginVisualizer. 

[YandexWeatherEventProcessor](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Server/YandexWeatherEventProcessor.cs) (Event Processor) receives weather information via a request to the Yandex Weather API and passes this value to Macroscop via the [YandexWeatherEvent](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Common/Events/YandexWeatherEvent.cs) (RawEvent) event. This event is displayed in the Macroscop Client event log.<br>
Information about the name of the location and the current temperature in it is displayed in the camera cell using the [YandexWeatherVisualizer](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Client/YandexWeatherVisualizer.cs) (PluginVisualizer) plugin.

This plugin can be enabled in Macroscop Configurator - Automation - Cameras - Integrations - Yandex Weather Plugin.

This plugin has common settings:<br>
&emsp;- ApiKey: token to access the Yandex.Weather API<br>
&emsp;- Delay: frequency of requests (set in milliseconds)

The following settings can be set for each camera:<br>
&emsp;- lat: latitude (in coordinates)<br>
&emsp;- lon: longitude (in coordinates)

The plugin is divided into 3 parts:<br>
&emsp;- Server: YandexWeatherEventProcessor initialization and API request<br>
&emsp;- Common: YandexWeatherEvent, GeneralSettings, ChannelSettings<br>
&emsp;- Client: UI settings, YandexWeatherEventProcessorConfigurator, YandexWeatherVisualizer (runs on windows only)