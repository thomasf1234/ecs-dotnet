using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS;

/// <summary>
/// Represents the main implementation of the <see cref="IWorld"/> interface for the Entity Component System (ECS) framework.
/// The <c>World</c> class manages the lifecycle of entities, components, and systems, providing methods for entity creation,
/// destruction, component management, and system execution. It acts as the central hub for all ECS operations, delegating
/// responsibilities to the <see cref="EntityManager"/> and <see cref="ComponentRegistry"/>.
/// </summary>
public class World : IWorld
{
    /// <summary>
    /// The manager responsible for entity lifecycle and component storage.
    /// </summary>
    private readonly EntityManager _entityManager;

    /// <summary>
    /// The registry responsible for component type registration and bit flag assignment.
    /// </summary>
    private readonly ComponentRegistry _componentRegistry;

    /// <summary>
    /// The list of registered systems, executed in the order of registration.
    /// </summary>
    private readonly List<System> _systems;

    /// <summary>
    /// Initializes a new instance of the <see cref="World"/> class with a specified maximum number of entities.
    /// </summary>
    /// <param name="maxEntities">The maximum number of entities supported by this world.</param>
    public World(int maxEntities)
    {
        _componentRegistry = new ComponentRegistry();
        _entityManager = new EntityManager(_componentRegistry, maxEntities);
        _systems = new List<System>();
    }

    /// <inheritdoc/>
    public int CreateEntity()
    {
        return _entityManager.Create();
    }

    /// <inheritdoc/>
    public void DestroyEntity(int id)
    {
        _entityManager.Destroy(id);
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1>() where T1 : struct, IComponent
    {
        return _entityManager.GetEntities<T1>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2>() where T1 : struct, IComponent where T2 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent where T9 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
    }

    /// <inheritdoc/>
    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() where T1 : struct, IComponent where T2 : struct, IComponent where T3 : struct, IComponent where T4 : struct, IComponent where T5 : struct, IComponent where T6 : struct, IComponent where T7 : struct, IComponent where T8 : struct, IComponent where T9 : struct, IComponent where T10 : struct, IComponent
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
    }

    /// <inheritdoc/>
    public Bit256 RegisterComponent<T>() where T : struct, IComponent
    {
        return _componentRegistry.Register<T>();
    }

    /// <inheritdoc/>
    public void AddComponent<T>(int entityId, T component) where T : struct, IComponent
    {
        _entityManager.AddComponent(entityId, component);
    }

    /// <inheritdoc/>
    public void UpdateComponent<T>(int entityId, T component) where T : struct, IComponent
    {
        _entityManager.UpdateComponent(entityId, component);
    }

    /// <inheritdoc/>
    public void RemoveComponent<T>(int entityId) where T : struct, IComponent
    {
        _entityManager.RemoveComponent<T>(entityId);
    }

    /// <inheritdoc/>
    public T GetComponent<T>(int entityId) where T : struct, IComponent
    {
        return _entityManager.GetComponent<T>(entityId);
    }

    /// <inheritdoc/>
    public bool HasComponent<T>(int entityId) where T : struct, IComponent
    {
        return _entityManager.HasComponent<T>(entityId);
    }

    /// <inheritdoc/>
    public Bit256 GetSignature(int entityId)
    {
        return _entityManager.GetSignature(entityId);
    }

    /// <inheritdoc/>
    public void RegisterSystem(System system)
    {
        _systems.Add(system);
    }

    /// <summary>
    /// Updates all registered systems in the world for the given time context.
    /// Each system's <see cref="System.Update"/> method is called in the order of registration.
    /// </summary>
    /// <param name="timeContext">The current time context for the update.</param>
    public void Update(TimeContext timeContext)
    {
        foreach (var system in _systems)
        {
            system.Update(this, timeContext);
        }
    }

    /// <summary>
    /// Draws all registered systems in the world for the given time context.
    /// Each system's <see cref="System.Draw"/> method is called in the order of registration.
    /// </summary>
    /// <param name="timeContext">The current time context for the draw.</param>
    public void Draw(TimeContext timeContext)
    {
        foreach (var system in _systems)
        {
            system.Draw(this, timeContext);
        }
    }
}
