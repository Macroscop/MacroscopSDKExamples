# Пример плагина Яндекс.Погоды

## Настройка и описание работы

Пример-плагин визуализатора погоды демонстрирует работу плагинов MacroscopSDK EventProcessor (Процессор событий), PluginVisualizer (Визуализатор).<br> 

[YandexWeatherEventProcessor](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Server/YandexWeatherEventProcessor.cs) (EventProcessor) получает информацию о погоде через запрос к YandexWeather API и передаёт это значение в Macroscop через событие [YandexWeatherEvent](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Common/Events/YandexWeatherEvent.cs) (RawEvent). Данное событие отображается в журнале событий Macroscop Клиент.<br>
Информация о названии местности и текущей температуры в ней отображается в ячейке камеры при помощи плагина [YandexWeatherVisualizer](/Plugins/IntegrationPluginExamples/YandexWeatherPluginExample/YandexWeatherPluginExample.Client/YandexWeatherVisualizer.cs) (PluginVisualizer).


Данный плагин можно включить в Macroscop Конфигуратор -> Автоматизация -> Камеры -> Интеграции -> Yandex Weather Plugin.

Данный плагин имеет общие настройки:<br>
&emsp;- ApiKey: токен для доступа к API Яндекс.Погода<br>
&emsp;- Delay: периодичность запросов (задаётся в миллисекундах)

Для каждой камеры можно задать следующие настройки:<br>
&emsp;- lat: широта (в координатах)<br>
&emsp;- lon: долгота (в координатах)

Плагин разделен на 3 части:<br>
&emsp;- Server: инициализация YandexWeatherEventProcessor и запрос к API<br>
&emsp;- Common: событие YandexWeatherEvent, GeneralSettings, ChannelSettings<br>
&emsp;- Client: UI настроек, YandexWeatherEventProcessorConfigurator, YandexWeatherVisualizer (выполняется только на windows)


