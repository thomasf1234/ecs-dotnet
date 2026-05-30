using System.Diagnostics;
using ECS;

namespace PerformanceTests
{
    public class WorldPerformance2Tests
    {
        // Define 10 unique components
        private struct C1 : IComponent { public int Value; }
        private struct C2 : IComponent { public int Value; }
        private struct C3 : IComponent { public int Value; }
        private struct C4 : IComponent { public int Value; }
        private struct C5 : IComponent { public int Value; }
        private struct C6 : IComponent { public int Value; }
        private struct C7 : IComponent { public int Value; }
        private struct C8 : IComponent { public int Value; }
        private struct C9 : IComponent { public int Value; }
        private struct C10 : IComponent { public int Value; }

        // System definitions
        private class SystemC1C2 : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<C1, C2>())
                {
                    var c1 = world.GetComponent<C1>(id);
                    var c2 = world.GetComponent<C2>(id);
                    c1.Value += c2.Value;
                    world.UpdateComponent(id, c1);
                }
            }
        }
        private class SystemC3C4C5 : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<C3, C4, C5>())
                {
                    var c3 = world.GetComponent<C3>(id);
                    c3.Value++;
                    world.UpdateComponent(id, c3);
                }
            }
        }
        private class SystemC6C7C8C9 : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<C6, C7, C8, C9>())
                {
                    var c6 = world.GetComponent<C6>(id);
                    c6.Value--;
                    world.UpdateComponent(id, c6);
                }
            }
        }
        private class SystemC10 : ECS.System
        {
            public override void Update(IWorld world, TimeContext timeContext)
            {
                foreach (var id in world.GetEntities<C10>())
                {
                    var c10 = world.GetComponent<C10>(id);
                    c10.Value *= 2;
                    world.UpdateComponent(id, c10);
                }
            }
        }

        [Fact]
        public void Exhaustive_Archetype_Performance_99Percentile()
        {
            const int entityCount = 10000;
            const int frameCount = 1000;

            var world = new World(entityCount);

            var registry = new ComponentRegistry();
            world.RegisterComponent<C1>();
            world.RegisterComponent<C2>();
            world.RegisterComponent<C3>();
            world.RegisterComponent<C4>();
            world.RegisterComponent<C5>();
            world.RegisterComponent<C6>();
            world.RegisterComponent<C7>();
            world.RegisterComponent<C8>();
            world.RegisterComponent<C9>();
            world.RegisterComponent<C10>();
            

            // Distribute entities across many archetypes (combinations of components)
            var random = new Random(42);
            for (int i = 0; i < entityCount; i++)
            {
                int id = world.CreateEntity();
                // Each entity gets a random combination of 3-6 components
                var components = Enumerable.Range(1, 10).OrderBy(_ => random.Next()).Take(random.Next(3, 7)).ToArray();
                foreach (var c in components)
                {
                    switch (c)
                    {
                        case 1: world.AddComponent(id, new C1 { Value = i }); break;
                        case 2: world.AddComponent(id, new C2 { Value = i }); break;
                        case 3: world.AddComponent(id, new C3 { Value = i }); break;
                        case 4: world.AddComponent(id, new C4 { Value = i }); break;
                        case 5: world.AddComponent(id, new C5 { Value = i }); break;
                        case 6: world.AddComponent(id, new C6 { Value = i }); break;
                        case 7: world.AddComponent(id, new C7 { Value = i }); break;
                        case 8: world.AddComponent(id, new C8 { Value = i }); break;
                        case 9: world.AddComponent(id, new C9 { Value = i }); break;
                        case 10: world.AddComponent(id, new C10 { Value = i }); break;
                    }
                }
            }

            // Register systems
            world.RegisterSystem(new SystemC1C2());
            world.RegisterSystem(new SystemC3C4C5());
            world.RegisterSystem(new SystemC6C7C8C9());
            world.RegisterSystem(new SystemC10());

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

            Console.WriteLine($"[Exhaustive] 99th percentile frame time: {percentile99:F2} ms (target < 16.6ms for 60fps)");

            Assert.True(percentile99 < 16.6, $"[Exhaustive] 99th percentile frame time exceeded 16.6ms: {percentile99:F2} ms");
        }
    }
}