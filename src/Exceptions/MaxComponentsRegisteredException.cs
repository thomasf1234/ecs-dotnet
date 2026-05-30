using System;

namespace ECS.Exceptions;

/// <summary>
/// Thrown when attempting to register more components than the maximum allowed.
/// </summary>
public class MaxComponentsRegisteredException : InvalidOperationException
{
    public MaxComponentsRegisteredException(int limit)
        : base($"Max registered components of {limit} reached.") { }
}
