using System;
using System.Collections;
using System.Collections.Generic;

namespace ECS;

/// <summary>
/// Represents an archetype in the ECS, which is a unique combination of component types (signature).
/// Stores the set of entities matching this signature and the component arrays for each component type.
/// Archetypes enable efficient grouping and iteration of entities with the same component composition.
/// </summary>
internal class Archetype
{
    /// <summary>
    /// The unique signature (bitmask) representing the combination of component types for this archetype.
    /// </summary>
    public Bit256 Signature { get; }

    /// <summary>
    /// The set of entity IDs that belong to this archetype.
    /// </summary>
    public HashSet<int> Entities { get; }

    /// <summary>
    /// Maps component types to their corresponding component arrays for this archetype.
    /// </summary>
    public Dictionary<Type, IComponentArray> ComponentArrays { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Archetype"/> class.
    /// </summary>
    /// <param name="signature">The unique signature (bitmask) for the component combination.</param>
    /// <param name="maxEntities">The maximum number of entities supported by this archetype.</param>
    public Archetype(Bit256 signature)
    {
        Signature = signature;
        Entities = new HashSet<int>();
        ComponentArrays = new Dictionary<Type, IComponentArray>();
    }
}
