# Integration plugins

1. Download and install Macroscop Standalone from [our site](https://macroscop.com/podderzhka/distributivy).
2. Install Your purchased license or ask a trial developement license by email info@macroscop.com.
3. Create an environment variable named MacroscopFolder, whose value contains the path to the Macroscop Standalone folder.
4. Clone repository and Compile solution (for [YandexWeatherPluginExample](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample) run configuration *YandexWeatherPlugin.Client Standalone*)<br>
5. Copy result DLLs to Macroscop Instalation Plugins folder (only for [EventProcessorExample]((/Plugins/IntegrationPluginExamples/EventProcessorExample)), [ExternalActionExample](/Plugins/IntegrationPluginExamples/ExternalActionExample)).
6. Add your plugin to the ioc file. ioc files are located in the root of the installed application. IntegrationPlugins.ioc - List of integration plug-ins with other subsystems.<br>
Example of adding a plugin using YandexWeatherPluginExample as an example:
```
<Plugin FileName="Plugins/Integration/YandexWeatherExample/YandexWeatherPluginExample.Common.dll">
	<Conditions>
		<OSType>Windows</OSType>
		<AppType>Any</AppType>
	</Conditions>
</Plugin>
<Plugin FileName="Plugins/Integration/YandexWeatherExample/YandexWeatherPluginExample.Server.dll">
	<Conditions>
		<OSType>Windows</OSType>
		<AppType>Server</AppType>
	</Conditions>
</Plugin>
<Plugin FileName="Plugins/Integration/YandexWeatherExample/YandexWeatherPluginExample.Client.dll">
	<Conditions>
		<OSType>Windows</OSType>
		<AppType>Client</AppType>
	</Conditions>
</Plugin>
```
7. Start Macroscop and debug plugin if needed.

### P.S. All configurations available for launch are in the file [launchSettings.json](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Client/Properties/launchSettings.json)