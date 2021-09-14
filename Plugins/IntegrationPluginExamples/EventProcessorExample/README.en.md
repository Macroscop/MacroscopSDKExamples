# Event Processor Plugin Example

## Configuring and common description

Plugin adds module **"External events generating module"**,
generating **CounterEvent** event, which is displayed in Client Event Log. 
Event generating frequency is configured in plugin settings. 
Event has a counter field, which increments according to configured frequency.

Enabling and configuring is performed in Configurator Application:
(Configurator -> Automation -> select camera -> Integrations)

Before that:
- Copy EventProcessorExample.dll in folder Macroscop/Plugins/Integration
- Add plugin to list in file IntegrationPlugins.ioc
