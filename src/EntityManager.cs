using ECS.Exceptions;
using System;
using System.Collections.Generic;

namespace ECS;

/// <summary>
/// Manages the lifecycle of entities and their components within the ECS world.
/// Handles entity creation, destruction, component addition, removal, updates, and
/// efficient archetype management for fast queries and system execution.
/// </summary>
internal class EntityManager
{
    /// <summary>
    /// The maximum number of entities supported by this manager.
    /// </summary>
    private readonly int _maxEntities;

    /// <summary>
    /// Queue of available entity IDs for reuse.
    /// </summary>
    private readonly Queue<int> _freeIds;

    /// <summary>
    /// Set of currently active entity IDs.
    /// </summary>
    private readonly HashSet<int> _activeIds;

    /// <summary>
    /// Maps entity IDs to their current component signature (bitmask).
    /// </summary>
    private Dictionary<int, Bit256> _signatureByEntityId;

    /// <summary>
    /// Maps component signatures (bitmask) to their corresponding archetype.
    /// </summary>
    private Dictionary<Bit256, Archetype> _archetypeBySignature;

    /// <summary>
    /// Registry for component type flags and metadata.
    /// </summary>
    private readonly ComponentRegistry _componentRegistry;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityManager"/> class.
    /// </summary>
    /// <param name="componentRegistry">The component registry to use for type flags.</param>
    /// <param name="maxEntities">The maximum number of entities supported.</param>
    public EntityManager(ComponentRegistry componentRegistry, int maxEntities)
    {
        _componentRegistry = componentRegistry;
        _maxEntities = maxEntities;
        _freeIds = new Queue<int>(maxEntities);
        _activeIds = new HashSet<int>();
        _signatureByEntityId = new Dictionary<int, Bit256>();
        _archetypeBySignature = new Dictionary<Bit256, Archetype>();

        for (int i = 0; i < maxEntities; ++i)
        {
            _freeIds.Enqueue(i);
        }
    }

    /// <summary>
    /// Creates a new entity and returns its unique ID.
    /// </summary>
    /// <returns>The unique ID of the created entity.</returns>
    /// <exception cref="MaxEntitiesReachedException">
    /// Thrown if the maximum number of entities is reached.
    /// </exception>
    public int Create()
    {
        if (_freeIds.Count == 0)
        {
            throw new MaxEntitiesReachedException(_maxEntities);
        }

        int id = _freeIds.Dequeue();
        _activeIds.Add(id);
        _signatureByEntityId[id] = Bit256.Zero;

        return id;
    }

    /// <summary>
    /// Destroys the specified entity, removing all its components and freeing its ID for reuse.
    /// </summary>
    /// <param name="id">The ID of the entity to destroy.</param>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    public void Destroy(int id)
    {
        if (!_activeIds.Remove(id))
        {
            throw new EntityNotFoundException(id);
        }

        var oldSignature = _signatureByEntityId[id];

        if (oldSignature != Bit256.Zero)
        {
            var oldArchetype = _archetypeBySignature[oldSignature];

            foreach (var componentArray in oldArchetype.ComponentArrays.Values)
            {
                componentArray.RemoveAt(id);
            }

            oldArchetype.Entities.Remove(id);
        }

        _signatureByEntityId.Remove(id);

        _freeIds.Enqueue(id);
    }

    /// <summary>
    /// Checks if the specified entity is currently alive (active).
    /// </summary>
    /// <param name="id">The entity ID to check.</param>
    /// <returns>True if the entity is alive; otherwise, false.</returns>
    public bool IsAlive(int id) => _activeIds.Contains(id);

    /// <summary>
    /// Gets all currently active entity IDs.
    /// </summary>
    public IEnumerable<int> ActiveEntities => _activeIds;

    /// <summary>
    /// Returns all entity IDs that have the specified component type.
    /// </summary>
    /// <typeparam name="T1">The component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    public IEnumerable<int> GetEntities<T1>() where T1 : struct, IComponent
    {
        var componentFlag = _componentRegistry.GetFlag<T1>();
        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            // If our archetype contains the component flag
            if ((signature & componentFlag) == componentFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    /// <summary>
    /// Returns all entity IDs that have both specified component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    public IEnumerable<int> GetEntities<T1, T2>() where T1 : struct, IComponent where T2 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var combinedFlag = componentFlag1 | componentFlag2;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            // If our archetype contains the combined flag
            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var componentFlag6 = _componentRegistry.GetFlag<T6>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5 | componentFlag6;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var componentFlag6 = _componentRegistry.GetFlag<T6>();
        var componentFlag7 = _componentRegistry.GetFlag<T7>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5 | componentFlag6 | componentFlag7;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var componentFlag6 = _componentRegistry.GetFlag<T6>();
        var componentFlag7 = _componentRegistry.GetFlag<T7>();
        var componentFlag8 = _componentRegistry.GetFlag<T8>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5 | componentFlag6 | componentFlag7 | componentFlag8;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent where T9 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var componentFlag6 = _componentRegistry.GetFlag<T6>();
        var componentFlag7 = _componentRegistry.GetFlag<T7>();
        var componentFlag8 = _componentRegistry.GetFlag<T8>();
        var componentFlag9 = _componentRegistry.GetFlag<T9>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5 | componentFlag6 | componentFlag7 | componentFlag8 | componentFlag9;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent where T9 : struct, IComponent where T10 : struct, IComponent
    {
        var componentFlag1 = _componentRegistry.GetFlag<T1>();
        var componentFlag2 = _componentRegistry.GetFlag<T2>();
        var componentFlag3 = _componentRegistry.GetFlag<T3>();
        var componentFlag4 = _componentRegistry.GetFlag<T4>();
        var componentFlag5 = _componentRegistry.GetFlag<T5>();
        var componentFlag6 = _componentRegistry.GetFlag<T6>();
        var componentFlag7 = _componentRegistry.GetFlag<T7>();
        var componentFlag8 = _componentRegistry.GetFlag<T8>();
        var componentFlag9 = _componentRegistry.GetFlag<T9>();
        var componentFlag10 = _componentRegistry.GetFlag<T10>();
        var combinedFlag = componentFlag1 | componentFlag2 | componentFlag3 | componentFlag4 | componentFlag5 | componentFlag6 | componentFlag7 | componentFlag8 | componentFlag9 | componentFlag10;

        foreach (var item in _archetypeBySignature)
        {
            var signature = item.Key;
            var archetype = item.Value;

            if ((signature & combinedFlag) == combinedFlag)
            {
                foreach (var entityId in archetype.Entities)
                {
                    yield return entityId;
                }
            }
        }
    }

    /// <summary>
    /// Adds a component of the specified type to the given entity.
    /// If the entity already has the component, an exception is thrown.
    /// Handles archetype transitions and component data migration.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to add the component to.</param>
    /// <param name="component">The component value to add.</param>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    /// <exception cref="ComponentAlreadyExistsException">
    /// Thrown if the component already exists on the entity.
    /// </exception>
    public void AddComponent<T>(int entityId, T component) where T : struct, IComponent
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out var oldSignature))
        {
            throw new EntityNotFoundException(entityId);
        }

        var componentFlag = _componentRegistry.GetFlag<T>();
        var newSignature = oldSignature | componentFlag;

        if (newSignature == oldSignature)
        {
            throw new ComponentAlreadyExistsException(typeof(T), entityId);
        }

        // Create new archetype if it doesn't exist
        if (!_archetypeBySignature.TryGetValue(newSignature, out var newArchetype))
        {
            newArchetype = new Archetype(newSignature);
            _archetypeBySignature.Add(newSignature, newArchetype);
        }

        // Transfer components from old archetype to new archetype (old archetype must exist if the entity has the signature)
        if (oldSignature != Bit256.Zero)
        {
            var oldArchetype = _archetypeBySignature[oldSignature];
            foreach (var item in oldArchetype.ComponentArrays)
            {
                var componentType = item.Key;
                var componentArray = item.Value;

                // Create new component array for the new archetype if it doesn't exist
                if (!newArchetype.ComponentArrays.ContainsKey(componentType))
                {
                    var componentArrayType = typeof(ComponentArray<>).MakeGenericType(componentType);
                    var componentArrayInstance = (IComponentArray)Activator.CreateInstance(componentArrayType, _maxEntities)!;
                    newArchetype.ComponentArrays[componentType] = componentArrayInstance;
                }

                var _component = componentArray.GetBoxed(entityId);
                newArchetype.ComponentArrays[componentType].Insert(entityId, _component);
                componentArray.RemoveAt(entityId);
            }

            // Remove entity from the old archetype
            oldArchetype.Entities.Remove(entityId);
        }

        // Create new component array for the new archetype if it doesn't exist
        if (!newArchetype.ComponentArrays.ContainsKey(typeof(T)))
        {
            newArchetype.ComponentArrays[typeof(T)] = new ComponentArray<T>(_maxEntities);
        }

        // Insert new component to new archetype
        newArchetype.ComponentArrays[typeof(T)].Insert(entityId, component);

        // Add entity to the new archetype
        newArchetype.Entities.Add(entityId);

        // Update new signature
        _signatureByEntityId[entityId] = newSignature;
    }

    /// <summary>
    /// Updates the value of a component of the specified type on the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity whose component to update.</param>
    /// <param name="component">The new component value.</param>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the component does not exist on the entity.
    /// </exception>
    public void UpdateComponent<T>(int entityId, T component) where T : struct, IComponent
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out var signature))
        {
            throw new EntityNotFoundException(entityId);
        }

        var componentFlag = _componentRegistry.GetFlag<T>();

        if ((signature & componentFlag) != componentFlag)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        // Transfer components from old archetype to new archetype (old archetype must exist if the entity has the signature)
        var archetype = _archetypeBySignature[signature];

        archetype.ComponentArrays[typeof(T)].Update(entityId, component);
    }

    /// <summary>
    /// Removes a component of the specified type from the given entity.
    /// Handles archetype transitions and component data migration.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to remove the component from.</param>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the component does not exist on the entity.
    /// </exception>
    public void RemoveComponent<T>(int entityId) where T : struct, IComponent
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out var oldSignature))
        {
            throw new EntityNotFoundException(entityId);
        }

        var componentFlag = _componentRegistry.GetFlag<T>();
        var newSignature = oldSignature & ~componentFlag; // BITWISE oldSignature AND (NOT componentFlag) to remove componentFlag

        if (newSignature == oldSignature)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        // Transfer components from old archetype to new archetype (old archetype must exist if the entity has the signature)
        var oldArchetype = _archetypeBySignature[oldSignature];

        if (newSignature == Bit256.Zero)
        {
            foreach (var componentArray in oldArchetype.ComponentArrays.Values)
            {
                componentArray.RemoveAt(entityId);
            }
        }
        else
        {
            // Create new archetype if it doesn't exist
            if (!_archetypeBySignature.TryGetValue(newSignature, out var newArchetype))
            {
                newArchetype = new Archetype(newSignature);
                _archetypeBySignature.Add(newSignature, newArchetype);
            }

            // Transfer components from old archetype to new archetype except the removed component
            foreach (var item in oldArchetype.ComponentArrays)
            {
                var componentType = item.Key;
                var componentArray = item.Value;

                if (componentType == typeof(T))
                {
                    componentArray.RemoveAt(entityId);
                    continue;
                }

                // Create new component array for the new archetype if it doesn't exist
                if (!newArchetype.ComponentArrays.ContainsKey(componentType))
                {
                    var componentArrayType = typeof(ComponentArray<>).MakeGenericType(componentType);
                    var componentArrayInstance = (IComponentArray)Activator.CreateInstance(componentArrayType, _maxEntities)!;
                    newArchetype.ComponentArrays[componentType] = componentArrayInstance;
                }

                var _component = componentArray.GetBoxed(entityId);
                newArchetype.ComponentArrays[componentType].Insert(entityId, _component);
                componentArray.RemoveAt(entityId);
            }

            // Add entity to the new archetype
            newArchetype.Entities.Add(entityId);
        }

        // Remove entity from the old archetype
        oldArchetype.Entities.Remove(entityId);

        // Remove archetype if it has no entities
        if (oldArchetype.Entities.Count == 0)
        {
            _archetypeBySignature.Remove(oldSignature);
        }

        // Update new signature
        _signatureByEntityId[entityId] = newSignature;
    }

    /// <summary>
    /// Gets the value of a component of the specified type from the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to get the component from.</param>
    /// <returns>The component value.</returns>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the component does not exist on the entity.
    /// </exception>
    public T GetComponent<T>(int entityId) where T : struct, IComponent
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out Bit256 signature))
        {
            throw new EntityNotFoundException(entityId);
        }

        var componentFlag = _componentRegistry.GetFlag<T>();
        if ((signature & componentFlag) != componentFlag)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        var archetype = _archetypeBySignature[signature];
        var component = ((ComponentArray<T>)archetype.ComponentArrays[typeof(T)]).Get(entityId);

        return component;
    }

    /// <summary>
    /// Checks if the specified entity has a component of the given type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity ID to check.</param>
    /// <returns>True if the entity has the component; otherwise, false.</returns>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    public bool HasComponent<T>(int entityId) where T : struct, IComponent
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out var signature))
        {
            throw new EntityNotFoundException(entityId);
        }
        var componentFlag = _componentRegistry.GetFlag<T>();
        return (signature & componentFlag) == componentFlag;
    }

    /// <summary>
    /// Gets the component signature (bitmask) for the specified entity.
    /// </summary>
    /// <param name="entityId">The entity ID to query.</param>
    /// <returns>The component signature as a ulong bitmask.</returns>
    /// <exception cref="EntityNotFoundException">
    /// Thrown if the entity does not exist.
    /// </exception>
    public Bit256 GetSignature(int entityId)
    {
        if (!_signatureByEntityId.TryGetValue(entityId, out var signature))
        {
            throw new EntityNotFoundException(entityId);
        }
        return signature;
    }
}
