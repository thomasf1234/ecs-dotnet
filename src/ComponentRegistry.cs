namespace ECS;

/// <summary>
/// Manages the registration and bit flag assignment of up to 64 unique component types.
/// Each component type is assigned a unique bit position within a 64-bit mask (ulong),
/// enabling efficient bitwise operations for entity-component systems.
/// </summary>
internal class ComponentRegistry
{
    /// <summary>
    /// The maximum number of unique component types supported (64).
    /// </summary>
    public const int MaxComponents = sizeof(ulong) * 8;

    private readonly Dictionary<Type, ulong> _typeToBit = new();
    private int _nextBit = 0;

    /// <summary>
    /// Registers a new component type and assigns it a unique bit flag.
    /// Throws an exception if the type is already registered or if the maximum is exceeded.
    /// </summary>
    /// <typeparam name="T">The component type to register (must be a struct).</typeparam>
    /// <returns>The unique bit flag assigned to the component type.</returns>
    public ulong Register<T>() where T : struct
    {
        var type = typeof(T);

        if (_typeToBit.ContainsKey(type))
        {
            throw new InvalidOperationException($"Component type {type} is already registered.");
        }

        if (_nextBit >= MaxComponents)
        {
            throw new InvalidOperationException($"Maximum of {MaxComponents} component types supported.");
        }

        // Assign the next available bit to this component type
        ulong bit = 1UL << _nextBit;
        _nextBit++;
        _typeToBit[type] = bit;

        return bit;
    }

    /// <summary>
    /// Retrieves the bit flag assigned to a registered component type.
    /// Throws an exception if the type is not registered.
    /// </summary>
    /// <typeparam name="T">The component type to query (must be a struct).</typeparam>
    /// <returns>The bit flag assigned to the component type.</returns>
    public ulong GetFlag<T>() where T : struct
    {
        if (!_typeToBit.TryGetValue(typeof(T), out ulong flag))
        {
            throw new InvalidOperationException($"Component type {typeof(T)} is not registered.");
        }

        return flag;
    }

    /// <summary>
    /// Attempts to retrieve the bit flag assigned to a registered component type.
    /// Returns true if the type is registered; otherwise, returns false.
    /// </summary>
    /// <typeparam name="T">The component type to query (must be a struct).</typeparam>
    /// <param name="flag">The bit flag assigned to the component type, or 0 if not registered.</param>
    /// <returns>True if the type is registered; otherwise, false.</returns>
    public bool TryGetFlag<T>(out ulong flag) where T : struct
    {
        return _typeToBit.TryGetValue(typeof(T), out flag);
    }
}
