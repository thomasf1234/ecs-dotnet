using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS;

/// <summary>
/// Defines the contract for an Entity Component System (ECS) world.
/// The world manages entities, components, and systems, and provides
/// methods for entity lifecycle, component management, and system execution.
/// </summary>
public interface IWorld
{
    /// <summary>
    /// Creates a new entity in the world.
    /// </summary>
    /// <returns>The unique identifier of the created entity.</returns>
    int CreateEntity();

    /// <summary>
    /// Destroys the specified entity and removes all its components.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to destroy.</param>
    void DestroyEntity(int id);

    /// <summary>
    /// Returns all entity IDs that have the specified component type.
    /// </summary>
    /// <typeparam name="T1">The component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1>() where T1 : struct;

    /// <summary>
    /// Returns all entity IDs that have both specified component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2>() where T1 : struct where T2 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of three component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3>() where T1 : struct where T2 : struct where T3 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of four component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of five component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of six component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <typeparam name="T6">The sixth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of seven component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <typeparam name="T6">The sixth component type to query for.</typeparam>
    /// <typeparam name="T7">The seventh component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of eight component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <typeparam name="T6">The sixth component type to query for.</typeparam>
    /// <typeparam name="T7">The seventh component type to query for.</typeparam>
    /// <typeparam name="T8">The eighth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of nine component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <typeparam name="T6">The sixth component type to query for.</typeparam>
    /// <typeparam name="T7">The seventh component type to query for.</typeparam>
    /// <typeparam name="T8">The eighth component type to query for.</typeparam>
    /// <typeparam name="T9">The ninth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct;

    /// <summary>
    /// Returns all entity IDs that have the specified combination of ten component types.
    /// </summary>
    /// <typeparam name="T1">The first component type to query for.</typeparam>
    /// <typeparam name="T2">The second component type to query for.</typeparam>
    /// <typeparam name="T3">The third component type to query for.</typeparam>
    /// <typeparam name="T4">The fourth component type to query for.</typeparam>
    /// <typeparam name="T5">The fifth component type to query for.</typeparam>
    /// <typeparam name="T6">The sixth component type to query for.</typeparam>
    /// <typeparam name="T7">The seventh component type to query for.</typeparam>
    /// <typeparam name="T8">The eighth component type to query for.</typeparam>
    /// <typeparam name="T9">The ninth component type to query for.</typeparam>
    /// <typeparam name="T10">The tenth component type to query for.</typeparam>
    /// <returns>An enumerable of entity IDs.</returns>
    IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct;

    /// <summary>
    /// Registers a new component type with the world and returns its unique flag or identifier.
    /// </summary>
    /// <typeparam name="T">The component type to register.</typeparam>
    /// <returns>The unique flag or identifier for the component type.</returns>
    ulong RegisterComponent<T>() where T : struct;

    /// <summary>
    /// Adds a component of the specified type to the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to add the component to.</param>
    /// <param name="component">The component value to add.</param>
    void AddComponent<T>(int entityId, T component) where T : struct;

    /// <summary>
    /// Updates the value of a component of the specified type on the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity whose component to update.</param>
    /// <param name="component">The new component value.</param>
    void UpdateComponent<T>(int entityId, T component) where T : struct;

    /// <summary>
    /// Removes a component of the specified type from the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to remove the component from.</param>
    void RemoveComponent<T>(int entityId) where T : struct;

    /// <summary>
    /// Gets the value of a component of the specified type from the given entity.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity to get the component from.</param>
    /// <returns>The component value.</returns>
    T GetComponent<T>(int entityId) where T : struct;

    /// <summary>
    /// Registers a system with the world. Systems are executed in the order they are registered during update and draw cycles.
    /// </summary>
    /// <param name="system">The system to register.</param>
    void RegisterSystem(System system);

    /// <summary>
    /// Updates all registered systems in the world for the given time context.
    /// </summary>
    /// <param name="timeContext">The current time context for the update.</param>
    void Update(TimeContext timeContext);

    /// <summary>
    /// Draws all registered systems in the world for the given time context.
    /// </summary>
    /// <param name="timeContext">The current time context for the draw.</param>
    void Draw(TimeContext timeContext);

    /// <summary>
    /// Checks if the specified entity has a component of the given type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="entityId">The entity ID to check.</param>
    /// <returns>True if the entity has the component; otherwise, false.</returns>
    /// <exception cref="EntityNotFoundException">Thrown if the entity does not exist.</exception>
    bool HasComponent<T>(int entityId) where T : struct;

    /// <summary>
    /// Gets the component signature (bitmask) for the specified entity.
    /// </summary>
    /// <param name="entityId">The entity ID to query.</param>
    /// <returns>The component signature as a ulong bitmask.</returns>
    /// <exception cref="EntityNotFoundException">Thrown if the entity does not exist.</exception>
    ulong GetSignature(int entityId);
}
