using ECS;
using ECS.Exceptions;

namespace UnitTests
{
    public class EntityManagerTests
    {
        private struct PositionComponent : IComponent { public float X, Y; }
        private struct VelocityComponent : IComponent { public float X, Y; }
        private struct HealthComponent : IComponent { public int Value; }

        private EntityManager CreateManager(int maxEntities = 16)
        {
            var componentRegistry = new ComponentRegistry();
            componentRegistry.Register<PositionComponent>();
            componentRegistry.Register<VelocityComponent>();
            componentRegistry.Register<HealthComponent>();
            return new EntityManager(componentRegistry, maxEntities);
        }

        [Fact]
        public void Create_And_Destroy_Entity()
        {
            var manager = CreateManager();
            int id = manager.Create();
            Assert.True(manager.IsAlive(id));
            manager.Destroy(id);
            Assert.False(manager.IsAlive(id));
            // After destroy, entity should have no signature
            Assert.Throws<EntityNotFoundException>(() => manager.GetSignature(id));

        }

        [Fact]
        public void Destroy_Removes_All_Components()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            manager.Destroy(id);
            // After destroy, entity should not have any components
            Assert.Throws<EntityNotFoundException>(() => manager.GetComponent<PositionComponent>(id));
            Assert.Throws<EntityNotFoundException>(() => manager.GetComponent<VelocityComponent>(id));
            Assert.False(manager.IsAlive(id));
            Assert.Throws<EntityNotFoundException>(() => manager.GetSignature(id));
        }

        [Fact]
        public void Create_Throws_When_Exceeding_MaxEntities()
        {
            var manager = CreateManager(2);
            manager.Create();
            manager.Create();
            Assert.Throws<MaxEntitiesReachedException>(() => manager.Create());
        }

        [Fact]
        public void Destroy_Throws_If_Entity_Not_Alive()
        {
            var manager = CreateManager();
            Assert.Throws<EntityNotFoundException>(() => manager.Destroy(42));
        }

        [Fact]
        public void AddComponent_Adds_And_Retrieves_Component()
        {
            var manager = CreateManager();
            int id = manager.Create();
            var pos = new PositionComponent { X = 1, Y = 2 };
            manager.AddComponent(id, pos);
            var result = manager.GetComponent<PositionComponent>(id);
            Assert.Equal(pos.X, result.X);
            Assert.Equal(pos.Y, result.Y);
        }

        [Fact]
        public void AddComponent_Throws_If_Already_Added()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            Assert.Throws<ComponentAlreadyExistsException>(() => manager.AddComponent(id, new PositionComponent { X = 3, Y = 4 }));
        }

        [Fact]
        public void AddComponent_Throws_If_EntityNotFound()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 }));
        }

        [Fact]
        public void UpdateComponent_Throws_If_EntityNotFound()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.UpdateComponent(id, new PositionComponent { X = 1, Y = 2 }));
        }

        [Fact]
        public void GetComponent_Throws_If_EntityNotFound()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.GetComponent<PositionComponent>(id));
        }

        [Fact]
        public void IsAlive_ReturnsFalse_For_Destroyed_Entity()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.False(manager.IsAlive(id));
        }

        [Fact]
        public void Destroy_Throws_If_Entity_Destroyed_Twice()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.Destroy(id));
        }

        [Fact]
        public void Add_Multiple_Components_And_Retrieve()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            var pos = manager.GetComponent<PositionComponent>(id);
            var vel = manager.GetComponent<VelocityComponent>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(3, vel.X);
            Assert.Equal(4, vel.Y);
        }

        [Fact]
        public void AddComponent_Moves_Entity_To_New_Archetype()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            var pos1 = manager.GetComponent<PositionComponent>(id);
            manager.AddComponent(id, new VelocityComponent { X = 5, Y = 6 });
            var pos2 = manager.GetComponent<PositionComponent>(id);
            var vel = manager.GetComponent<VelocityComponent>(id);
            Assert.Equal(pos1.X, pos2.X);
            Assert.Equal(pos1.Y, pos2.Y);
            Assert.Equal(5, vel.X);
            Assert.Equal(6, vel.Y);
        }

        [Fact]
        public void ActiveEntities_Reflects_Created_And_Destroyed()
        {
            var manager = CreateManager();
            int id1 = manager.Create();
            int id2 = manager.Create();
            Assert.Contains(id1, manager.ActiveEntities);
            Assert.Contains(id2, manager.ActiveEntities);
            manager.Destroy(id1);
            Assert.DoesNotContain(id1, manager.ActiveEntities);
            Assert.Contains(id2, manager.ActiveEntities);
        }

        [Fact]
        public void AddComponent_And_Destroy_Entity_Removes_From_Archetype()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.Destroy(id);
            Assert.False(manager.IsAlive(id));
            // Should throw because the entity and its components are removed
            Assert.Throws<EntityNotFoundException>(() => manager.GetComponent<PositionComponent>(id));
            Assert.Throws<EntityNotFoundException>(() => manager.GetSignature(id));
        }

        [Fact]
        public void RemoveComponent_Removes_Component_And_Entity_If_Last()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.RemoveComponent<PositionComponent>(id);
            Assert.Throws<ComponentNotFoundException>(() => manager.GetComponent<PositionComponent>(id));
            Assert.True(manager.IsAlive(id));
        }

        [Fact]
        public void RemoveComponent_Removes_Only_Specified_Component()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            manager.RemoveComponent<PositionComponent>(id);
            Assert.Throws<ComponentNotFoundException>(() => manager.GetComponent<PositionComponent>(id));
            var vel = manager.GetComponent<VelocityComponent>(id);
            Assert.Equal(3, vel.X);
            Assert.Equal(4, vel.Y);
        }

        [Fact]
        public void RemoveComponent_Then_AddComponent_Works()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.RemoveComponent<PositionComponent>(id);
            manager.AddComponent(id, new PositionComponent { X = 5, Y = 6 });
            var pos = manager.GetComponent<PositionComponent>(id);
            Assert.Equal(5, pos.X);
            Assert.Equal(6, pos.Y);
        }

        [Fact]
        public void RemoveComponent_Throws_If_Entity_Has_No_Components()
        {
            var manager = CreateManager();
            int id = manager.Create();
            Assert.Throws<ComponentNotFoundException>(() => manager.RemoveComponent<PositionComponent>(id));
        }

        [Fact]
        public void RemoveComponent_Throws_If_Component_Not_Present()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            Assert.Throws<ComponentNotFoundException>(() => manager.GetComponent<VelocityComponent>(id));
            Assert.Throws<ComponentNotFoundException>(() => manager.RemoveComponent<VelocityComponent>(id));
        }

        [Fact]
        public void RemoveComponent_Multiple_Components_Leaves_Others_Intact()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            manager.AddComponent(id, new HealthComponent { Value = 100 });
            manager.RemoveComponent<VelocityComponent>(id);
            var pos = manager.GetComponent<PositionComponent>(id);
            var health = manager.GetComponent<HealthComponent>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(100, health.Value);
            Assert.Throws<ComponentNotFoundException>(() => manager.GetComponent<VelocityComponent>(id));
        }

        [Fact]
        public void RemoveComponent_Entity_Archetype_Transition_Is_Correct()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            var signatureWithBoth = manager.GetSignature(id);
            manager.RemoveComponent<VelocityComponent>(id);
            var signatureWithPositionComponent = manager.GetSignature(id);
            Assert.NotEqual(signatureWithBoth, signatureWithPositionComponent);
            manager.RemoveComponent<PositionComponent>(id);
            var signatureWithNone = manager.GetSignature(id);
            Assert.NotEqual(signatureWithPositionComponent, signatureWithNone);
        }

        [Fact]
        public void HasComponent_ReturnsTrue_If_Component_Exists()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            Assert.True(manager.HasComponent<PositionComponent>(id));
            Assert.False(manager.HasComponent<VelocityComponent>(id));
        }

        [Fact]
        public void HasComponent_Throws_If_EntityNotFound()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.HasComponent<PositionComponent>(id));
        }

        [Fact]
        public void GetSignature_ReturnsCorrectSignature()
        {
            var manager = CreateManager();
            int id = manager.Create();
            // No components yet
            Assert.Equal(Bit256.Zero, manager.GetSignature(id));
            manager.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            var sigWithPositionComponent = manager.GetSignature(id);
            Assert.NotEqual(Bit256.Zero, sigWithPositionComponent);
            manager.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            var sigWithBoth = manager.GetSignature(id);
            Assert.NotEqual(sigWithPositionComponent, sigWithBoth);
        }

        [Fact]
        public void GetSignature_Throws_If_EntityNotFound()
        {
            var manager = CreateManager();
            int id = manager.Create();
            manager.Destroy(id);
            Assert.Throws<EntityNotFoundException>(() => manager.GetSignature(id));
        }
    }
}
