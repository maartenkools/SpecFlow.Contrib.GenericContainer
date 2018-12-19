using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin.Tests
{
    public static class Dependencies
    {
        [ScenarioDependencies]
        public static IGenericContainer CreateContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.DefaultLifestyle = Lifestyle.Singleton;

            container.Register<ICalculator, Calculator>();

            foreach (var type in typeof(Dependencies).Assembly
                                                     .GetTypes()
                                                     .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))))
            {
                container.Register(type);
            }

            return new SimpleInjectorContainer(container);
        }
    }
}
