using BoDi;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

namespace SpecFlow.Contrib.GenericContainer.SpecFlowPlugin
{
    public class GenericContainerPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents,
                               RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeGlobalDependencies += (sender, args) =>
                                                               {
                                                                   args.ObjectContainer.RegisterTypeAs<BindingInstanceResolver, ITestObjectResolver>();
                                                                   args.ObjectContainer.RegisterTypeAs<ContainerFinder, IContainerFinder>();
                                                               };

            runtimePluginEvents.CustomizeScenarioDependencies += (sender, args) =>
                                                                 {
                                                                     args.ObjectContainer.RegisterFactoryAs(() =>
                                                                                                            {
                                                                                                                var containerBuilderFinder = args.ObjectContainer.Resolve<IContainerFinder>();
                                                                                                                var containerBuilder = containerBuilderFinder.GetCreateScenarioContainer();
                                                                                                                var container = containerBuilder.Invoke();

                                                                                                                RegisterSpecFlowDependencies(args.ObjectContainer, container);
                                                                                                                
                                                                                                                return container;
                                                                                                            });
                                                                 };
        }

        private static void RegisterSpecFlowDependencies(IObjectContainer objectContainer, IGenericContainer container)
        {
            container.Register(() => objectContainer);
            container.Register(() =>
                               {
                                   var specFlowContainer = container.Resolve<IObjectContainer>();
                                   return specFlowContainer.Resolve<ScenarioContext>();
                               });
            container.Register(() =>
                               {
                                   var specFlowContainer = container.Resolve<IObjectContainer>();
                                   return specFlowContainer.Resolve<FeatureContext>();
                               });
            container.Register(() =>
                               {
                                   var specFlowContainer = container.Resolve<IObjectContainer>();
                                   return specFlowContainer.Resolve<TestThreadContext>();
                               });
        }
    }
}
