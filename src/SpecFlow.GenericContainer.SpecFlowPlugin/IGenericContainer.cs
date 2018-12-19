using System;

namespace SpecFlow.GenericContainer.SpecFlowPlugin
{
    public interface IGenericContainer
    {
        void Register<TService>(Func<TService> instanceCreator) where TService : class;
        object Resolve(Type bindingType);
        TService Resolve<TService>() where TService : class;
    }
}
