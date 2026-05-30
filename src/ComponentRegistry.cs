using ECS.Exceptions;

namespace ECS;

/// <summary>
/// Manages the registration and bit flag assignment of up to 256 unique component types.
/// Each component type is assigned a unique bit position within a 256-bit mask,
/// enabling efficient bitwise operations for entity-component systems.
/// </summary>
internal class ComponentRegistry
{
    /// <summary>
    /// The maximum number of unique component types supported.
    /// </summary>
    public const int MaxComponents = 256;

    private readonly Dictionary<Type, Bit256> _typeToFlag = new();
    private int _nextBit = 0;

    /// <summary>
    /// Registers a new component type and assigns it a unique bit flag.
    /// Throws a <see cref="ECS.Exceptions.ComponentAlreadyRegisteredException"/> if the type is already registered,
    /// or a <see cref="ECS.Exceptions.MaxComponentsRegisteredException"/> if the maximum is exceeded.
    /// </summary>
    /// <typeparam name="T">The component type to register (must be a struct).</typeparam>
    /// <returns>
    /// The unique bit flag assigned to the component type as a <see cref="Bit256"/>,
    /// with only one bit set.
    /// </returns>
    public Bit256 Register<T>() where T : struct
    {
        var type = typeof(T);

        if (_typeToFlag.ContainsKey(type))
        {
            throw new ComponentAlreadyRegisteredException(type);
        }

        if (_nextBit >= MaxComponents)
        {
            throw new MaxComponentsRegisteredException(MaxComponents);
        }

        // Assign the next available bit to this component type
        var flag = new Bit256();
        byte bit = (byte)_nextBit++;
        flag[bit] = true;
        _typeToFlag[type] = flag;

        return flag;
    }

    /// <summary>
    /// Retrieves the bit flag assigned to a registered component type.
    /// Throws a <see cref="ECS.Exceptions.ComponentNotRegisteredException"/> if the type is not registered.
    /// </summary>
    /// <typeparam name="T">The component type to query (must be a struct).</typeparam>
    /// <returns>
    /// The bit flag assigned to the component type as a <see cref="Bit256"/>,
    /// with only one bit set.
    /// </returns>
    public Bit256 GetFlag<T>() where T : struct
    {
        if (!_typeToFlag.TryGetValue(typeof(T), out Bit256 flag))
        {
            throw new ComponentNotRegisteredException(typeof(T));
        }

        return flag;
    }

    /// <summary>
    /// Attempts to retrieve the bit flag assigned to a registered component type.
    /// Returns true if the type is registered; otherwise, returns false.
    /// </summary>
    /// <typeparam name="T">The component type to query (must be a struct).</typeparam>
    /// <param name="flag">
    /// The bit flag assigned to the component type as a <see cref="Bit256"/>,
    /// with only one bit set, or zero if not registered.
    /// </param>
    /// <returns>True if the type is registered; otherwise, false.</returns>
    public bool TryGetFlag<T>(out Bit256 flag) where T : struct
    {
        return _typeToFlag.TryGetValue(typeof(T), out flag);
    }
}
