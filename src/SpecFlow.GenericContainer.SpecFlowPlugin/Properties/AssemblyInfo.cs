// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

using SpecFlow.GenericContainer.SpecFlowPlugin;
using System.Reflection;
using TechTalk.SpecFlow.Plugins;

[assembly: AssemblyTitle("SpecFlow.GenericContainer")]
[assembly: AssemblyDescription("SpecFlow plugin for using any dependency injection framework for step definitions")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SpecFlow.GenericContainer")]
[assembly: AssemblyCopyright("Copyright © Maarten Kools 2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: RuntimePlugin(typeof(GenericContainerPlugin))]