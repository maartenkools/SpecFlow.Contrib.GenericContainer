using BoDi;
using System;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow.GenericContainer.SpecFlowPlugin
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
