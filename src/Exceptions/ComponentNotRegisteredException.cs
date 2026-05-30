using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when attempting to access a component that has not been registered in the component registry.
/// </summary>
public class ComponentNotRegisteredException : Exception
{
    public ComponentNotRegisteredException(Type componentType)
        : base($"Component '{componentType.Name}' not registered.") { }
}
