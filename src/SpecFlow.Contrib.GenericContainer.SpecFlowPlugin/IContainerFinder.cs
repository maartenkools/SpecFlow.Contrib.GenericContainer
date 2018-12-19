using System;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin
{
    internal interface IContainerFinder
    {
        Func<IGenericContainer> GetCreateScenarioContainer();
    }
}