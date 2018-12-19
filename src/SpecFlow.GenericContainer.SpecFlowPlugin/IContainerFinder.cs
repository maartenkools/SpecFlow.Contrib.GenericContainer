using System;

namespace SpecFlow.GenericContainer.SpecFlowPlugin
{
    internal interface IContainerFinder
    {
        Func<IGenericContainer> GetCreateScenarioContainer();
    }
}