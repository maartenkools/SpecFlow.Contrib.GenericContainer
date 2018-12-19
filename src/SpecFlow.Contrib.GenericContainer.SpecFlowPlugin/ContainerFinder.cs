using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow.Bindings;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin
{
    internal class ContainerFinder : IContainerFinder
    {
        private readonly IBindingRegistry _bindingRegistry;
        private readonly Lazy<Func<IGenericContainer>> _createScenarioContainer;

        public ContainerFinder(IBindingRegistry bindingRegistry)
        {
            _bindingRegistry = bindingRegistry ?? throw new ArgumentNullException(nameof(bindingRegistry));
            _createScenarioContainer = new Lazy<Func<IGenericContainer>>(FindCreateScenarioContainer, true);
        }

        private Func<IGenericContainer> FindCreateScenarioContainer()
        {
            var assemblies = _bindingRegistry.GetBindingAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var methodInfo in type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                                                   .Where(m => Attribute.IsDefined(m, typeof(ScenarioDependenciesAttribute))))
                    {
                        return () => (IGenericContainer)methodInfo.Invoke(null, null);
                    }
                }
            }

            return null;
        }

        public Func<IGenericContainer> GetCreateScenarioContainer()
        {
            var builder = _createScenarioContainer.Value;
            if (builder == null)
            {
                throw new Exception("Unable to find scenario dependencies! Mark a static method that returns an IGenericContainer with [ScenarioDependencies]!");
            }
            return builder;
        }
    }
}