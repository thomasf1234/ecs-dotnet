using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when an operation is attempted on an entity that does not exist or is not active.
/// </summary>
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(int entityId)
        : base($"Entity {entityId} not found.") { }
}
