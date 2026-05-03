using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when attempting to add a component that already exists on the entity.
/// </summary>
public class ComponentAlreadyExistsException : InvalidOperationException
{
    public ComponentAlreadyExistsException(Type componentType, int entityId)
        : base($"Component '{componentType.Name}' already exists for entity {entityId}.") { }
}