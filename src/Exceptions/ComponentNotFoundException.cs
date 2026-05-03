using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when an operation is attempted on a component that does not exist on the entity.
/// </summary>
public class ComponentNotFoundException : Exception
{
    public ComponentNotFoundException(Type componentType, int entityId)
        : base($"Component '{componentType.Name}' not found for entity {entityId}.") { }
}
