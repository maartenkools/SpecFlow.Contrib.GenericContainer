# SpecFlow.GenericContainer
A SpecFlow plugin that provides a generic way to implement a custom DI container

[![Build status](https://ci.appveyor.com/api/projects/status/jlhywg2nulwescgy/branch/master?svg=true)](https://ci.appveyor.com/project/maartenkools/specflow-genericcontainer/branch/master)
[![NuGet status](https://img.shields.io/nuget/v/SpecFlow.Contrib.GenericContainer.svg)](https://www.nuget.org/packages/SpecFlow.Contrib.GenericContainer/)

# Usage
1. Create a class that implements the `IGenericContainer` interface and wraps your DI container.
2. Create a class that contains a static function with the `ScenarioDependenciesAttribute` that configures the container, and returns your `IGenericContainer` implementation.

# Example
## SimpleInjector
```csharp
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
```
```csharp
public static class Dependencies
{
  [ScenarioDependencies]
  public static IGenericContainer CreateContainer()
  {
    var container = new Container();
    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
    container.Options.DefaultLifestyle = Lifestyle.Singleton;

    // Add your registrations here

    foreach (var type in typeof(Dependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))))
    {
      container.Register(type);
    }

    return new SimpleInjectorContainer(container);
  }
}
```