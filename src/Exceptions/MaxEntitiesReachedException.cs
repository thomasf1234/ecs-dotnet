using System;
using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when attempting to create more entities than the maximum allowed.
/// </summary>
public class MaxEntitiesReachedException : InvalidOperationException
{
    public MaxEntitiesReachedException(int entityLimit)
        : base($"Max entities of {entityLimit} reached.") { }
}
