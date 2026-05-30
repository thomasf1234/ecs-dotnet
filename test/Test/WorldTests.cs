using ECS;
using ECS.Exceptions;

namespace UnitTests
{
    public class WorldTests
    {
        private struct PositionComponent : IComponent { public int X, Y; }
        private struct VelocityComponent : IComponent { public int X, Y; }
        private struct HealthComponent : IComponent { public int Value; }
        private struct TagAComponent : IComponent { }
        private struct TagBComponent : IComponent { }
        // System: Moves entities by velocity
        private class SimplePhysicsSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<PositionComponent, VelocityComponent>())
                {
                    var pos = world.GetComponent<PositionComponent>(id);
                    var vel = world.GetComponent<VelocityComponent>(id);
                    pos.X += (int)(vel.X * timeContext.DeltaTime);
                    pos.Y += (int)(vel.Y * timeContext.DeltaTime);
                    world.UpdateComponent(id, pos);
                }
            }
        }

        // System: Decreases health by 1 per frame
        private class DamageSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<HealthComponent>())
                {
                    var health = world.GetComponent<HealthComponent>(id);
                    health.Value -= 1;
                    world.UpdateComponent(id, health);
                }
            }
        }

        // System: Sets Position to (0,0) for all entities with TagA
        private class ResetPositionSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<PositionComponent, TagAComponent>())
                {
                    world.UpdateComponent(id, new PositionComponent { X = 0, Y = 0 });
                }
            }
        }

        // System: Decreases health by 2 per frame (for exhaustive test)
        private class HealthDecaySystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<HealthComponent>())
                {
                    var health = world.GetComponent<HealthComponent>(id);
                    health.Value -= 2;
                    world.UpdateComponent(id, health);
                }
            }
        }

        // System: Does nothing, just ensures query works
        private class TagASystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<TagAComponent>())
                {
                    // No-op
                }
            }
        }

        // System: Doubles position
        private class DoublePositionSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<PositionComponent>())
                {
                    var pos = world.GetComponent<PositionComponent>(id);
                    pos.X *= 2;
                    pos.Y *= 2;
                    world.UpdateComponent(id, pos);
                }
            }
        }

        [Fact]
        public void SimplePhysicsSystem_UpdatesEntitiesCorrectly()
        {
            var world = new World(16);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();

            world.AddComponent(id1, new PositionComponent { X = 0, Y = 0 });
            world.AddComponent(id1, new VelocityComponent { X = 1, Y = 0 });

            world.AddComponent(id2, new PositionComponent { X = 10, Y = 10 });
            world.AddComponent(id2, new VelocityComponent { X = 0, Y = -2 });
            world.RegisterSystem(new SimplePhysicsSystem());

            for (int frame = 0; frame < 5; frame++)
            {
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
            }

            var pos1 = world.GetComponent<PositionComponent>(id1);
            Assert.Equal(5, pos1.X);
            Assert.Equal(0, pos1.Y);

            var pos2 = world.GetComponent<PositionComponent>(id2);
            Assert.Equal(10, pos2.X);
            Assert.Equal(0, pos2.Y);
        }

        [Fact]
        public void MultipleSystems_MultipleComponents_ArchetypeTransitions()
        {
            var world = new World(32);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            world.RegisterComponent<HealthComponent>();
            world.RegisterComponent<TagAComponent>();
            world.RegisterComponent<TagBComponent>();
            

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            int id3 = world.CreateEntity();

            world.AddComponent(id1, new PositionComponent { X = 0, Y = 0 });
            world.AddComponent(id1, new VelocityComponent { X = 1, Y = 2 });
            world.AddComponent(id1, new HealthComponent { Value = 10 });

            world.AddComponent(id2, new PositionComponent { X = 5, Y = 5 });
            world.AddComponent(id2, new HealthComponent { Value = 20 });
            world.AddComponent(id2, new TagAComponent());

            world.AddComponent(id3, new PositionComponent { X = 10, Y = 10 });
            world.AddComponent(id3, new VelocityComponent { X = -1, Y = 0 });
            world.AddComponent(id3, new TagBComponent());

            world.RegisterSystem(new SimplePhysicsSystem());
            world.RegisterSystem(new DamageSystem());
            world.RegisterSystem(new ResetPositionSystem());

            for (int frame = 0; frame < 3; frame++)
            {
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
            }

            var pos1 = world.GetComponent<PositionComponent>(id1);
            var health1 = world.GetComponent<HealthComponent>(id1);
            Assert.Equal(3, pos1.X);
            Assert.Equal(6, pos1.Y);
            Assert.Equal(7, health1.Value);

            var pos2 = world.GetComponent<PositionComponent>(id2);
            var health2 = world.GetComponent<HealthComponent>(id2);
            Assert.Equal(0, pos2.X);
            Assert.Equal(0, pos2.Y);
            Assert.Equal(17, health2.Value);

            var pos3 = world.GetComponent<PositionComponent>(id3);
            Assert.Equal(7, pos3.X);
            Assert.Equal(10, pos3.Y);

            world.RemoveComponent<VelocityComponent>(id1);
            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 4 });
            var pos1After = world.GetComponent<PositionComponent>(id1);
            var health1After = world.GetComponent<HealthComponent>(id1);
            Assert.Equal(3, pos1After.X);
            Assert.Equal(6, pos1After.Y);
            Assert.Equal(6, health1After.Value);

            world.AddComponent(id3, new TagAComponent());
            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 5 });
            var pos3After = world.GetComponent<PositionComponent>(id3);
            Assert.Equal(0, pos3After.X);
            Assert.Equal(0, pos3After.Y);
        }

        [Fact]
        public void EntitiesWithDifferentArchetypes_AreQueriedCorrectly()
        {
            var world = new World(16);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            world.RegisterComponent<HealthComponent>();
            world.RegisterComponent<TagAComponent>();
            world.RegisterComponent<TagBComponent>();
            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            int id3 = world.CreateEntity();
            int id4 = world.CreateEntity();

            world.AddComponent(id1, new PositionComponent { X = 1, Y = 2 });
            world.AddComponent(id1, new VelocityComponent { X = 1, Y = 1 });
            world.AddComponent(id1, new HealthComponent { Value = 10 });

            world.AddComponent(id2, new PositionComponent { X = 3, Y = 4 });
            world.AddComponent(id2, new HealthComponent { Value = 20 });
            world.AddComponent(id2, new TagAComponent());
            world.AddComponent(id3, new PositionComponent { X = 5, Y = 6 });
            world.AddComponent(id3, new VelocityComponent { X = 0, Y = -1 });
            world.AddComponent(id3, new TagBComponent());

            world.AddComponent(id4, new HealthComponent { Value = 30 });
            world.AddComponent(id4, new TagAComponent());
            world.AddComponent(id4, new TagBComponent());

            Assert.Equal(3, world.GetEntities<HealthComponent>().Count());
            Assert.Equal(2, world.GetEntities<PositionComponent, VelocityComponent>().Count());
            Assert.Equal(2, world.GetEntities<TagAComponent>().Count());
            Assert.Single(world.GetEntities<PositionComponent, TagBComponent>());
            Assert.Single(world.GetEntities<HealthComponent, TagBComponent>());
            Assert.Empty(world.GetEntities<PositionComponent, TagAComponent, TagBComponent>());
        }

        [Fact]
        public void AddRemoveComponent_ArchetypeTransition_AndDataPreservation()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            world.RegisterComponent<HealthComponent>();

            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            world.AddComponent(id, new HealthComponent { Value = 100 });
            world.AddComponent(id, new VelocityComponent { X = 5, Y = 6 });
            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent, HealthComponent>());
            var pos = world.GetComponent<PositionComponent>(id);
            var health = world.GetComponent<HealthComponent>(id);
            var vel = world.GetComponent<VelocityComponent>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(100, health.Value);
            Assert.Equal(5, vel.X);
            Assert.Equal(6, vel.Y);

            world.RemoveComponent<HealthComponent>(id);
            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent>());
            Assert.Throws<ComponentNotFoundException>(() => world.GetComponent<HealthComponent>(id));
            pos = world.GetComponent<PositionComponent>(id);
            vel = world.GetComponent<VelocityComponent>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(5, vel.X);
            Assert.Equal(6, vel.Y);
        }

        [Fact]
        public void UpdateComponent_UpdatesDataWithoutArchetypeChange()
        {
            var world = new World(4);
            world.RegisterComponent<PositionComponent>();

            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            var pos = world.GetComponent<PositionComponent>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);

            world.UpdateComponent(id, new PositionComponent { X = 10, Y = 20 });
            pos = world.GetComponent<PositionComponent>(id);
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        [Fact]
        public void SystemOrder_AffectsState()
        {
            var world = new World(4);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            
            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 0, Y = 0 });
            world.AddComponent(id, new VelocityComponent { X = 1, Y = 0 });

            world.RegisterSystem(new SimplePhysicsSystem());
            world.RegisterSystem(new DoublePositionSystem());

            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 1 });
            var pos = world.GetComponent<PositionComponent>(id);
            Assert.Equal(2, pos.X);
            Assert.Equal(0, pos.Y);

            var world2 = new World(4);
            world2.RegisterComponent<PositionComponent>();
            world2.RegisterComponent<VelocityComponent>();

            int id2 = world2.CreateEntity();
            world2.AddComponent(id2, new PositionComponent { X = 0, Y = 0 });
            world2.AddComponent(id2, new VelocityComponent { X = 1, Y = 0 });
            world2.RegisterSystem(new DoublePositionSystem());
            world2.RegisterSystem(new SimplePhysicsSystem());

            world2.Update(new TimeContext { DeltaTime = 1, TotalTime = 1 });
            var pos2 = world2.GetComponent<PositionComponent>(id2);
            Assert.Equal(1, pos2.X);
            Assert.Equal(0, pos2.Y);
        }

        [Fact]
        public void ArchetypeTransition_AddAndRemoveComponents()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            
            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            Assert.Single(world.GetEntities<PositionComponent>());
            Assert.Empty(world.GetEntities<VelocityComponent>());

            world.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent>());
            Assert.Single(world.GetEntities<PositionComponent>());
            Assert.Single(world.GetEntities<VelocityComponent>());

            world.RemoveComponent<VelocityComponent>(id);
            Assert.Single(world.GetEntities<PositionComponent>());
            Assert.Empty(world.GetEntities<PositionComponent, VelocityComponent>());
            Assert.Empty(world.GetEntities<VelocityComponent>());
        }

        [Fact]
        public void DestroyEntity_RemovesFromAllQueries()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();

            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            world.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });

            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent>());
            world.DestroyEntity(id);
            Assert.Empty(world.GetEntities<PositionComponent, VelocityComponent>());
            Assert.Empty(world.GetEntities<PositionComponent>());
            Assert.Empty(world.GetEntities<VelocityComponent>());
        }

        [Fact]
        public void DestroyEntity_RemovesAllComponentsAndFromAllQueries()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            world.RegisterComponent<HealthComponent>();

            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            world.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            world.AddComponent(id, new HealthComponent { Value = 10 });

            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent, HealthComponent>());
            world.DestroyEntity(id);
            Assert.Empty(world.GetEntities<PositionComponent, VelocityComponent, HealthComponent>());
            Assert.Empty(world.GetEntities<PositionComponent>());
            Assert.Empty(world.GetEntities<VelocityComponent>());
            Assert.Empty(world.GetEntities<HealthComponent>());
        }

        [Fact]
        public void QueryingNonexistentEntities_ReturnsEmpty()
        {
            var world = new World(4);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            
            Assert.Empty(world.GetEntities<PositionComponent>());
            Assert.Empty(world.GetEntities<VelocityComponent>());
            Assert.Empty(world.GetEntities<PositionComponent, VelocityComponent>());
        }

        [Fact]
        public void MultipleEntities_SameArchetype_IndependentState()
        {
            var world = new World(4);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();     

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            world.AddComponent(id1, new PositionComponent { X = 0, Y = 0 });
            world.AddComponent(id1, new VelocityComponent { X = 1, Y = 0 });
            world.AddComponent(id2, new PositionComponent { X = 10, Y = 10 });
            world.AddComponent(id2, new VelocityComponent { X = 0, Y = -1 });

            world.RegisterSystem(new SimplePhysicsSystem());
            world.Update(new TimeContext { DeltaTime = 2, TotalTime = 2 });

            var pos1 = world.GetComponent<PositionComponent>(id1);
            var pos2 = world.GetComponent<PositionComponent>(id2);
            Assert.Equal(2, pos1.X);
            Assert.Equal(0, pos1.Y);
            Assert.Equal(10, pos2.X);
            Assert.Equal(8, pos2.Y);
        }

        [Fact]
        public void GetEntities_MultipleCombinations_ReturnsCorrectEntities()
        {
            var world = new World(16);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            world.RegisterComponent<HealthComponent>();
            
            // Create entities with different combinations
            int id1 = world.CreateEntity(); // Position, Velocity, Health
            int id2 = world.CreateEntity(); // Position, Velocity
            int id3 = world.CreateEntity(); // Position, Health
            int id4 = world.CreateEntity(); // Velocity, Health
            int id5 = world.CreateEntity(); // Position only
            int id6 = world.CreateEntity(); // Velocity only
            int id7 = world.CreateEntity(); // Health only

            world.AddComponent(id1, new PositionComponent { X = 1, Y = 1 });
            world.AddComponent(id1, new VelocityComponent { X = 2, Y = 2 });
            world.AddComponent(id1, new HealthComponent { Value = 10 });

            world.AddComponent(id2, new PositionComponent { X = 2, Y = 2 });
            world.AddComponent(id2, new VelocityComponent { X = 3, Y = 3 });

            world.AddComponent(id3, new PositionComponent { X = 3, Y = 3 });
            world.AddComponent(id3, new HealthComponent { Value = 20 });

            world.AddComponent(id4, new VelocityComponent { X = 4, Y = 4 });
            world.AddComponent(id4, new HealthComponent { Value = 30 });

            world.AddComponent(id5, new PositionComponent { X = 5, Y = 5 });

            world.AddComponent(id6, new VelocityComponent { X = 6, Y = 6 });
            world.AddComponent(id7, new HealthComponent { Value = 40 });

            // Single component queries
            Assert.Equal(new[] { id1, id2, id3, id5 }, world.GetEntities<PositionComponent>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id2, id4, id6 }, world.GetEntities<VelocityComponent>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id3, id4, id7 }, world.GetEntities<HealthComponent>().OrderBy(x => x));

            // Two component queries (partial combinations)
            Assert.Equal(new[] { id1, id2 }, world.GetEntities<PositionComponent, VelocityComponent>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id3 }, world.GetEntities<PositionComponent, HealthComponent>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id4 }, world.GetEntities<VelocityComponent, HealthComponent>().OrderBy(x => x));

            // Three component query (full combination)
            Assert.Single(world.GetEntities<PositionComponent, VelocityComponent, HealthComponent>());
            Assert.Equal(id1, world.GetEntities<PositionComponent, VelocityComponent, HealthComponent>().First());
        }

        [Fact]
        public void HasComponent_ReturnsTrue_If_Component_Exists()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            int id = world.CreateEntity();
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            Assert.True(world.HasComponent<PositionComponent>(id));
            Assert.False(world.HasComponent<VelocityComponent>(id));
        }

        [Fact]
        public void HasComponent_Throws_If_EntityNotFound()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            int id = world.CreateEntity();
            world.DestroyEntity(id);
            Assert.Throws<EntityNotFoundException>(() => world.HasComponent<PositionComponent>(id));
        }

        [Fact]
        public void GetSignature_ReturnsCorrectSignature()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            world.RegisterComponent<VelocityComponent>();
            int id = world.CreateEntity();
            // No components yet
            Assert.Equal(Bit256.Zero, world.GetSignature(id));
            world.AddComponent(id, new PositionComponent { X = 1, Y = 2 });
            var sigWithPosition = world.GetSignature(id);
            Assert.NotEqual(Bit256.Zero, sigWithPosition);
            world.AddComponent(id, new VelocityComponent { X = 3, Y = 4 });
            var sigWithBoth = world.GetSignature(id);
            Assert.NotEqual(sigWithPosition, sigWithBoth);
        }

        [Fact]
        public void GetSignature_Throws_If_EntityNotFound()
        {
            var world = new World(8);
            world.RegisterComponent<PositionComponent>();
            int id = world.CreateEntity();
            world.DestroyEntity(id);
            Assert.Throws<EntityNotFoundException>(() => world.GetSignature(id));
        }
    }
}