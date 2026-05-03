using ECS;
using ECS.Exceptions;

namespace UnitTests
{
    public class WorldTests
    {
        private struct Position { public int X, Y; }
        private struct Velocity { public int X, Y; }
        private struct Health { public int Value; }
        private struct TagA { }
        private struct TagB { }

        // System: Moves entities by velocity
        private class SimplePhysicsSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<Position, Velocity>())
                {
                    var pos = world.GetComponent<Position>(id);
                    var vel = world.GetComponent<Velocity>(id);
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
                foreach (var id in world.GetEntities<Health>())
                {
                    var health = world.GetComponent<Health>(id);
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
                foreach (var id in world.GetEntities<Position, TagA>())
                {
                    world.UpdateComponent(id, new Position { X = 0, Y = 0 });
                }
            }
        }

        // System: Decreases health by 2 per frame (for exhaustive test)
        private class HealthDecaySystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<Health>())
                {
                    var health = world.GetComponent<Health>(id);
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
                foreach (var id in world.GetEntities<TagA>())
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
                foreach (var id in world.GetEntities<Position>())
                {
                    var pos = world.GetComponent<Position>(id);
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
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();

            world.AddComponent(id1, new Position { X = 0, Y = 0 });
            world.AddComponent(id1, new Velocity { X = 1, Y = 0 });

            world.AddComponent(id2, new Position { X = 10, Y = 10 });
            world.AddComponent(id2, new Velocity { X = 0, Y = -2 });

            world.RegisterSystem(new SimplePhysicsSystem());

            for (int frame = 0; frame < 5; frame++)
            {
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
            }

            var pos1 = world.GetComponent<Position>(id1);
            Assert.Equal(5, pos1.X);
            Assert.Equal(0, pos1.Y);

            var pos2 = world.GetComponent<Position>(id2);
            Assert.Equal(10, pos2.X);
            Assert.Equal(0, pos2.Y);
        }

        [Fact]
        public void MultipleSystems_MultipleComponents_ArchetypeTransitions()
        {
            var world = new World(32);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();
            world.RegisterComponent<TagA>();
            world.RegisterComponent<TagB>();
            

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            int id3 = world.CreateEntity();

            world.AddComponent(id1, new Position { X = 0, Y = 0 });
            world.AddComponent(id1, new Velocity { X = 1, Y = 2 });
            world.AddComponent(id1, new Health { Value = 10 });

            world.AddComponent(id2, new Position { X = 5, Y = 5 });
            world.AddComponent(id2, new Health { Value = 20 });
            world.AddComponent(id2, new TagA());

            world.AddComponent(id3, new Position { X = 10, Y = 10 });
            world.AddComponent(id3, new Velocity { X = -1, Y = 0 });
            world.AddComponent(id3, new TagB());

            world.RegisterSystem(new SimplePhysicsSystem());
            world.RegisterSystem(new DamageSystem());
            world.RegisterSystem(new ResetPositionSystem());

            for (int frame = 0; frame < 3; frame++)
            {
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
            }

            var pos1 = world.GetComponent<Position>(id1);
            var health1 = world.GetComponent<Health>(id1);
            Assert.Equal(3, pos1.X);
            Assert.Equal(6, pos1.Y);
            Assert.Equal(7, health1.Value);

            var pos2 = world.GetComponent<Position>(id2);
            var health2 = world.GetComponent<Health>(id2);
            Assert.Equal(0, pos2.X);
            Assert.Equal(0, pos2.Y);
            Assert.Equal(17, health2.Value);

            var pos3 = world.GetComponent<Position>(id3);
            Assert.Equal(7, pos3.X);
            Assert.Equal(10, pos3.Y);

            world.RemoveComponent<Velocity>(id1);
            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 4 });
            var pos1After = world.GetComponent<Position>(id1);
            var health1After = world.GetComponent<Health>(id1);
            Assert.Equal(3, pos1After.X);
            Assert.Equal(6, pos1After.Y);
            Assert.Equal(6, health1After.Value);

            world.AddComponent(id3, new TagA());
            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 5 });
            var pos3After = world.GetComponent<Position>(id3);
            Assert.Equal(0, pos3After.X);
            Assert.Equal(0, pos3After.Y);
        }

        [Fact]
        public void EntitiesWithDifferentArchetypes_AreQueriedCorrectly()
        {
            var world = new World(16);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();
            world.RegisterComponent<TagA>();
            world.RegisterComponent<TagB>();

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            int id3 = world.CreateEntity();
            int id4 = world.CreateEntity();

            world.AddComponent(id1, new Position { X = 1, Y = 2 });
            world.AddComponent(id1, new Velocity { X = 1, Y = 1 });
            world.AddComponent(id1, new Health { Value = 10 });

            world.AddComponent(id2, new Position { X = 3, Y = 4 });
            world.AddComponent(id2, new Health { Value = 20 });
            world.AddComponent(id2, new TagA());

            world.AddComponent(id3, new Position { X = 5, Y = 6 });
            world.AddComponent(id3, new Velocity { X = 0, Y = -1 });
            world.AddComponent(id3, new TagB());

            world.AddComponent(id4, new Health { Value = 30 });
            world.AddComponent(id4, new TagA());
            world.AddComponent(id4, new TagB());

            Assert.Equal(3, world.GetEntities<Health>().Count());
            Assert.Equal(2, world.GetEntities<Position, Velocity>().Count());
            Assert.Equal(2, world.GetEntities<TagA>().Count());
            Assert.Single(world.GetEntities<Position, TagB>());
            Assert.Single(world.GetEntities<Health, TagB>());
            Assert.Empty(world.GetEntities<Position, TagA, TagB>());
        }

        [Fact]
        public void AddRemoveComponent_ArchetypeTransition_AndDataPreservation()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();

            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            world.AddComponent(id, new Health { Value = 100 });

            world.AddComponent(id, new Velocity { X = 5, Y = 6 });
            Assert.Single(world.GetEntities<Position, Velocity, Health>());
            var pos = world.GetComponent<Position>(id);
            var health = world.GetComponent<Health>(id);
            var vel = world.GetComponent<Velocity>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(100, health.Value);
            Assert.Equal(5, vel.X);
            Assert.Equal(6, vel.Y);

            world.RemoveComponent<Health>(id);
            Assert.Single(world.GetEntities<Position, Velocity>());
            Assert.Throws<ComponentNotFoundException>(() => world.GetComponent<Health>(id));
            pos = world.GetComponent<Position>(id);
            vel = world.GetComponent<Velocity>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(5, vel.X);
            Assert.Equal(6, vel.Y);
        }

        [Fact]
        public void UpdateComponent_UpdatesDataWithoutArchetypeChange()
        {
            var world = new World(4);
            world.RegisterComponent<Position>();

            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            var pos = world.GetComponent<Position>(id);
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);

            world.UpdateComponent(id, new Position { X = 10, Y = 20 });
            pos = world.GetComponent<Position>(id);
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        [Fact]
        public void SystemOrder_AffectsState()
        {
            var world = new World(4);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            
            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 0, Y = 0 });
            world.AddComponent(id, new Velocity { X = 1, Y = 0 });

            world.RegisterSystem(new SimplePhysicsSystem());
            world.RegisterSystem(new DoublePositionSystem());

            world.Update(new TimeContext { DeltaTime = 1, TotalTime = 1 });
            var pos = world.GetComponent<Position>(id);
            Assert.Equal(2, pos.X);
            Assert.Equal(0, pos.Y);

            var world2 = new World(4);
            world2.RegisterComponent<Position>();
            world2.RegisterComponent<Velocity>();

            int id2 = world2.CreateEntity();
            world2.AddComponent(id2, new Position { X = 0, Y = 0 });
            world2.AddComponent(id2, new Velocity { X = 1, Y = 0 });
            world2.RegisterSystem(new DoublePositionSystem());
            world2.RegisterSystem(new SimplePhysicsSystem());

            world2.Update(new TimeContext { DeltaTime = 1, TotalTime = 1 });
            var pos2 = world2.GetComponent<Position>(id2);
            Assert.Equal(1, pos2.X);
            Assert.Equal(0, pos2.Y);
        }

        [Fact]
        public void ArchetypeTransition_AddAndRemoveComponents()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            
            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            Assert.Single(world.GetEntities<Position>());
            Assert.Empty(world.GetEntities<Velocity>());

            world.AddComponent(id, new Velocity { X = 3, Y = 4 });
            Assert.Single(world.GetEntities<Position, Velocity>());
            Assert.Single(world.GetEntities<Position>());
            Assert.Single(world.GetEntities<Velocity>());

            world.RemoveComponent<Velocity>(id);
            Assert.Single(world.GetEntities<Position>());
            Assert.Empty(world.GetEntities<Position, Velocity>());
            Assert.Empty(world.GetEntities<Velocity>());
        }

        [Fact]
        public void DestroyEntity_RemovesFromAllQueries()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();

            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            world.AddComponent(id, new Velocity { X = 3, Y = 4 });

            Assert.Single(world.GetEntities<Position, Velocity>());
            world.DestroyEntity(id);
            Assert.Empty(world.GetEntities<Position, Velocity>());
            Assert.Empty(world.GetEntities<Position>());
            Assert.Empty(world.GetEntities<Velocity>());
        }

        [Fact]
        public void DestroyEntity_RemovesAllComponentsAndFromAllQueries()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();

            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            world.AddComponent(id, new Velocity { X = 3, Y = 4 });
            world.AddComponent(id, new Health { Value = 10 });

            Assert.Single(world.GetEntities<Position, Velocity, Health>());
            world.DestroyEntity(id);
            Assert.Empty(world.GetEntities<Position, Velocity, Health>());
            Assert.Empty(world.GetEntities<Position>());
            Assert.Empty(world.GetEntities<Velocity>());
            Assert.Empty(world.GetEntities<Health>());
        }

        [Fact]
        public void QueryingNonexistentEntities_ReturnsEmpty()
        {
            var world = new World(4);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            
            Assert.Empty(world.GetEntities<Position>());
            Assert.Empty(world.GetEntities<Velocity>());
            Assert.Empty(world.GetEntities<Position, Velocity>());
        }

        [Fact]
        public void MultipleEntities_SameArchetype_IndependentState()
        {
            var world = new World(4);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();     

            int id1 = world.CreateEntity();
            int id2 = world.CreateEntity();
            world.AddComponent(id1, new Position { X = 0, Y = 0 });
            world.AddComponent(id1, new Velocity { X = 1, Y = 0 });
            world.AddComponent(id2, new Position { X = 10, Y = 10 });
            world.AddComponent(id2, new Velocity { X = 0, Y = -1 });

            world.RegisterSystem(new SimplePhysicsSystem());
            world.Update(new TimeContext { DeltaTime = 2, TotalTime = 2 });

            var pos1 = world.GetComponent<Position>(id1);
            var pos2 = world.GetComponent<Position>(id2);
            Assert.Equal(2, pos1.X);
            Assert.Equal(0, pos1.Y);
            Assert.Equal(10, pos2.X);
            Assert.Equal(8, pos2.Y);
        }

        [Fact]
        public void GetEntities_MultipleCombinations_ReturnsCorrectEntities()
        {
            var world = new World(16);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();
            
            // Create entities with different combinations
            int id1 = world.CreateEntity(); // Position, Velocity, Health
            int id2 = world.CreateEntity(); // Position, Velocity
            int id3 = world.CreateEntity(); // Position, Health
            int id4 = world.CreateEntity(); // Velocity, Health
            int id5 = world.CreateEntity(); // Position only
            int id6 = world.CreateEntity(); // Velocity only
            int id7 = world.CreateEntity(); // Health only

            world.AddComponent(id1, new Position { X = 1, Y = 1 });
            world.AddComponent(id1, new Velocity { X = 2, Y = 2 });
            world.AddComponent(id1, new Health { Value = 10 });

            world.AddComponent(id2, new Position { X = 2, Y = 2 });
            world.AddComponent(id2, new Velocity { X = 3, Y = 3 });

            world.AddComponent(id3, new Position { X = 3, Y = 3 });
            world.AddComponent(id3, new Health { Value = 20 });

            world.AddComponent(id4, new Velocity { X = 4, Y = 4 });
            world.AddComponent(id4, new Health { Value = 30 });

            world.AddComponent(id5, new Position { X = 5, Y = 5 });

            world.AddComponent(id6, new Velocity { X = 6, Y = 6 });

            world.AddComponent(id7, new Health { Value = 40 });

            // Single component queries
            Assert.Equal(new[] { id1, id2, id3, id5 }, world.GetEntities<Position>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id2, id4, id6 }, world.GetEntities<Velocity>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id3, id4, id7 }, world.GetEntities<Health>().OrderBy(x => x));

            // Two component queries (partial combinations)
            Assert.Equal(new[] { id1, id2 }, world.GetEntities<Position, Velocity>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id3 }, world.GetEntities<Position, Health>().OrderBy(x => x));
            Assert.Equal(new[] { id1, id4 }, world.GetEntities<Velocity, Health>().OrderBy(x => x));

            // Three component query (full combination)
            Assert.Single(world.GetEntities<Position, Velocity, Health>());
            Assert.Equal(id1, world.GetEntities<Position, Velocity, Health>().First());
        }

        [Fact]
        public void HasComponent_ReturnsTrue_If_Component_Exists()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            int id = world.CreateEntity();
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            Assert.True(world.HasComponent<Position>(id));
            Assert.False(world.HasComponent<Velocity>(id));
        }

        [Fact]
        public void HasComponent_Throws_If_EntityNotFound()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            int id = world.CreateEntity();
            world.DestroyEntity(id);
            Assert.Throws<EntityNotFoundException>(() => world.HasComponent<Position>(id));
        }

        [Fact]
        public void GetSignature_ReturnsCorrectSignature()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            int id = world.CreateEntity();
            // No components yet
            Assert.Equal(0UL, world.GetSignature(id));
            world.AddComponent(id, new Position { X = 1, Y = 2 });
            ulong sigWithPosition = world.GetSignature(id);
            Assert.NotEqual(0UL, sigWithPosition);
            world.AddComponent(id, new Velocity { X = 3, Y = 4 });
            ulong sigWithBoth = world.GetSignature(id);
            Assert.NotEqual(sigWithPosition, sigWithBoth);
        }

        [Fact]
        public void GetSignature_Throws_If_EntityNotFound()
        {
            var world = new World(8);
            world.RegisterComponent<Position>();
            int id = world.CreateEntity();
            world.DestroyEntity(id);
            Assert.Throws<EntityNotFoundException>(() => world.GetSignature(id));
        }
    }
}