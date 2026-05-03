using System.Diagnostics;
using ECS;

namespace PerformanceTests
{
    public class WorldPerformanceTests
    {
        private struct Position { public int X, Y; }
        private struct Velocity { public int X, Y; }
        private struct Health { public int Value; }

        // Simple system that moves entities by their velocity
        private class SimplePhysicsSystem : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<Position, Velocity>())
                {
                    var pos = world.GetComponent<Position>(id);
                    var vel = world.GetComponent<Velocity>(id);
                    pos.X += vel.X;
                    pos.Y += vel.Y;
                    world.UpdateComponent(id, pos);
                }
            }
        }

        [Fact]
        public void CreateAndUpdate_10000Entities_Performance_98Percentile()
        {
            const int entityCount = 10000;
            const int frameCount = 1000;
            var world = new World(entityCount);
            world.RegisterComponent<Position>();
            world.RegisterComponent<Velocity>();
            world.RegisterComponent<Health>();
            

            // Create entities and add components
            for (int i = 0; i < entityCount; i++)
            {
                int id = world.CreateEntity();
                world.AddComponent(id, new Position { X = i, Y = i });
                if (i % 2 == 0)
                    world.AddComponent(id, new Velocity { X = 1, Y = 1 });
                if (i % 3 == 0)
                    world.AddComponent(id, new Health { Value = 100 });
            }

            // Register the system
            world.RegisterSystem(new SimplePhysicsSystem());

            // Warm up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            var frameTimes = new double[frameCount];
            var sw = new Stopwatch();

            for (int frame = 0; frame < frameCount; frame++)
            {
                sw.Restart();
                world.Update(new TimeContext { DeltaTime = 1, TotalTime = frame + 1 });
                sw.Stop();
                frameTimes[frame] = sw.Elapsed.TotalMilliseconds;
            }

            // Calculate 99th percentile
            var sorted = frameTimes.OrderBy(x => x).ToArray();
            int idx99 = (int)(frameCount * 0.99) - 1;
            double percentile99 = sorted[idx99];

            Console.WriteLine($"99th percentile frame time: {percentile99:F2} ms (target < 16.6ms for 60fps)");

            Assert.True(percentile99 < 16.6, $"98th percentile frame time exceeded 16.6ms: {percentile99:F2} ms");
        }
    }
}