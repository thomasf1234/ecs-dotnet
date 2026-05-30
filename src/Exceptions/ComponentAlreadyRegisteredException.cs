using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when attempting to register a component that is already registered.
/// </summary>
public class ComponentAlreadyRegisteredException : InvalidOperationException
{
    public ComponentAlreadyRegisteredException(Type componentType)
        : base($"Component '{componentType.Name}' already registered.") { }
}