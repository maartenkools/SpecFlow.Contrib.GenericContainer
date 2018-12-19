using System;
using BoDi;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin
{
    internal class BindingInstanceResolver : ITestObjectResolver
    {
        public object ResolveBindingInstance(Type bindingType, IObjectContainer container)
        {
            var componentContext = container.Resolve<IGenericContainer>();
            return componentContext.Resolve(bindingType);
        }
    }
}
