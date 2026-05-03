using ECS.Exceptions;
using System;
using System.Collections.Generic;

namespace ECS;

/// <summary>
/// A fixed-size, densely packed array supporting fast insertion, removal, and lookup by entity ID.
/// Maintains a dense storage layout by moving the last component into the removed slot on deletion.
/// Optimized for scenarios where fast iteration and compact storage are required, such as ECS entity/component storage.
/// </summary>
/// <typeparam name="T">The type of component stored in the array.</typeparam>
internal class ComponentArray<T> : IComponentArray
{
    private readonly T[] _components;
    private readonly int[] _denseIndexByEntityId;
    private readonly Dictionary<int, int> _entityIdByDenseIndex;
    public int Count { get; private set; }
    private const int _invalidIndex = -1;

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentArray{T}"/> class with the specified capacity.
    /// </summary>
    /// <param name="size">The maximum number of components the array can hold.</param>
    public ComponentArray(int size)
    {
        _components = new T[size];
        _denseIndexByEntityId = new int[size];
        Array.Fill(_denseIndexByEntityId, _invalidIndex);
        _entityIdByDenseIndex = new Dictionary<int, int>();
        Count = 0;
    }

    /// <summary>
    /// Retrieves the component associated with the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID of the component.</param>
    /// <returns>The component associated with the given entity ID.</returns>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the entity ID does not have an associated component in the array.
    /// </exception>
    public T Get(int entityId)
    {
        int denseIndex = _denseIndexByEntityId[entityId];
        if (denseIndex == _invalidIndex)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        return _components[denseIndex];
    }

    /// <summary>
    /// Inserts a component with the specified entity ID.
    /// If the entity ID already exists, the existing component is replaced.
    /// </summary>
    /// <param name="entityId">The entity ID to associate with the component.</param>
    /// <param name="component">The component to insert.</param>
    /// <exception cref="MaxEntitiesReachedException">
    /// Thrown if the array is full and cannot accept more components.
    /// </exception>
    public void Insert(int entityId, T component)
    {
        if (Count >= _components.Length)
        {
            throw new MaxEntitiesReachedException(_components.Length);
        }

        if (_denseIndexByEntityId[entityId] != _invalidIndex)
        {
            RemoveAt(entityId);
        }

        int denseIndex = Count;

        _denseIndexByEntityId[entityId] = denseIndex;
        _entityIdByDenseIndex[denseIndex] = entityId;
        _components[denseIndex] = component;

        ++Count;
    }

    /// <summary>
    /// Updates the component associated with the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID of the component to update.</param>
    /// <param name="component">The new component value.</param>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the entity ID does not have an associated component in the array.
    /// </exception>
    public void Update(int entityId, T component)
    {
        int denseIndex = _denseIndexByEntityId[entityId];
        if (denseIndex == _invalidIndex)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        _components[denseIndex] = component;
    }

    /// <summary>
    /// Removes the component associated with the specified entity ID.
    /// Maintains dense packing by moving the last component into the removed slot.
    /// </summary>
    /// <param name="entityId">The entity ID of the component to remove.</param>
    /// <exception cref="ComponentNotFoundException">
    /// Thrown if the entity ID does not have an associated component in the array.
    /// </exception>
    public void RemoveAt(int entityId)
    {
        int denseIndex = _denseIndexByEntityId[entityId];
        if (denseIndex == _invalidIndex)
        {
            throw new ComponentNotFoundException(typeof(T), entityId);
        }

        int lastDenseIndex = Count - 1;

        if (denseIndex != lastDenseIndex)
        {
            // Move last component to removed slot
            _components[denseIndex] = _components[lastDenseIndex];
            int lastEntityId = _entityIdByDenseIndex[lastDenseIndex];
            _entityIdByDenseIndex[denseIndex] = lastEntityId;
            _denseIndexByEntityId[lastEntityId] = denseIndex;
        }

        // Remove last component
        _components[lastDenseIndex] = default;
        _denseIndexByEntityId[entityId] = _invalidIndex;
        _entityIdByDenseIndex.Remove(lastDenseIndex);

        --Count;
    }

    /// <summary>
    /// Retrieves the component associated with the specified entity ID as an object.
    /// </summary>
    /// <param name="entityId">The entity ID of the component.</param>
    /// <returns>The component as an object.</returns>
    public object GetBoxed(int entityId)
    {
        return Get(entityId);
    }

    /// <summary>
    /// Inserts a component (boxed) with the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID to associate with the component.</param>
    /// <param name="value">The component to insert (as object).</param>
    public void Insert(int entityId, object value)
    {
        Insert(entityId, (T)value);
    }

    /// <summary>
    /// Updates the component (boxed) associated with the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID of the component to update.</param>
    /// <param name="value">The new component value (as object).</param>
    public void Update(int entityId, object value)
    {
        Update(entityId, (T)value);
    }
}
