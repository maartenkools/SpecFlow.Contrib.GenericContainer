using System;
using SimpleInjector;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin.Tests
{
    public class SimpleInjectorContainer : IGenericContainer
    {
        private readonly Container _container;

        public SimpleInjectorContainer(Container container)
        {
            _container = container;
        }

        public void Register<TService>(Func<TService> instanceCreator)
            where TService : class
        {
            _container.Register(instanceCreator);
        }

        public object Resolve(Type bindingType)
        {
            return _container.GetInstance(bindingType);
        }

        public TService Resolve<TService>()
            where TService : class
        {
            return _container.GetInstance<TService>();
        }
    }
}
