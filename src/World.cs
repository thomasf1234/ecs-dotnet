using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS;

public class World : IWorld
{
    private readonly EntityManager _entityManager;
    private readonly ComponentRegistry _componentRegistry;
    private readonly List<System> _systems;
    public World(int maxEntities)
    {
        _componentRegistry = new ComponentRegistry();
        _entityManager = new EntityManager(_componentRegistry, maxEntities);
        _systems = new List<System>();
    }
    public int CreateEntity()
    {
        return _entityManager.Create();
    }
    public void DestroyEntity(int id)
    {
        _entityManager.Destroy(id);
    }
    public IEnumerable<int> GetEntities<T1>() where T1 : struct
    {
        return _entityManager.GetEntities<T1>();
    }

    public IEnumerable<int> GetEntities<T1,T2>() where T1 : struct where T2 : struct
    {
        return _entityManager.GetEntities<T1, T2>();
    }
    public IEnumerable<int> GetEntities<T1, T2, T3>() where T1 : struct where T2 : struct where T3 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
    }

    public IEnumerable<int> GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct
    {
        return _entityManager.GetEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
    }
    public ulong RegisterComponent<T>() where T : struct
    {
        return _componentRegistry.Register<T>();
    }
    public void AddComponent<T>(int entityId, T component) where T : struct
    {
        _entityManager.AddComponent(entityId, component);
    }
    public void UpdateComponent<T>(int entityId, T component) where T : struct
    {
        _entityManager.UpdateComponent(entityId, component);
    }

    public void RemoveComponent<T>(int entityId) where T : struct
    {
        _entityManager.RemoveComponent<T>(entityId);
    }

    public T GetComponent<T>(int entityId) where T : struct
    {
        return _entityManager.GetComponent<T>(entityId);
    }

    public bool HasComponent<T>(int entityId) where T : struct
    {
        return _entityManager.HasComponent<T>(entityId);
    }

    public ulong GetSignature(int entityId)
    {
        return _entityManager.GetSignature(entityId);
    }

    public void RegisterSystem(System system)
    {
        _systems.Add(system);
    }

    public void Update(TimeContext timeContext)
    {
        foreach (var system in _systems)
        {
            system.Update(this, timeContext);
        }
    }

    public void Draw(TimeContext timeContext)
    {
        foreach (var system in _systems)
        {
            system.Draw(this, timeContext);
        }
    }
}
