using ECS;
using ECS.Exceptions; // Ensure this is included for custom exceptions

namespace UnitTests
{
    public class ComponentArrayTests
    {
        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            var arr = new ComponentArray<int>(5);
            Assert.Equal(0, arr.Count);
            // Try to get an element that doesn't exist
            Assert.Throws<ComponentNotFoundException>(() => arr.Get(0));
        }

        [Fact]
        public void Insert_AddsElement()
        {
            var arr = new ComponentArray<string>(3);
            arr.Insert(1, "A");
            Assert.Equal(1, arr.Count);
            Assert.Equal("A", arr.Get(1));
        }

        [Fact]
        public void Insert_OverwritesExistingId()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 10);
            arr.Insert(0, 20); // Should overwrite
            Assert.Equal(1, arr.Count);
            Assert.Equal(20, arr.Get(0));
        }

        [Fact]
        public void Insert_ThrowsWhenFull()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 1);
            arr.Insert(1, 2);
            Assert.Throws<MaxEntitiesReachedException>(() => arr.Insert(2, 3));
        }

        [Fact]
        public void Get_ThrowsForMissingId()
        {
            var arr = new ComponentArray<int>(2);
            Assert.Throws<ComponentNotFoundException>(() => arr.Get(1));
        }

        [Fact]
        public void RemoveAt_RemovesElement()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 1);
            arr.RemoveAt(0);
            Assert.Equal(0, arr.Count);
            Assert.Throws<ComponentNotFoundException>(() => arr.Get(0));
        }

        [Fact]
        public void RemoveAt_ThrowsForMissingId()
        {
            var arr = new ComponentArray<int>(2);
            Assert.Throws<ComponentNotFoundException>(() => arr.RemoveAt(1));
        }

        [Fact]
        public void RemoveAt_MaintainsPackedProperty()
        {
            var arr = new ComponentArray<int>(3);
            arr.Insert(0, 10);
            arr.Insert(1, 20);
            arr.Insert(2, 30);
            arr.RemoveAt(1); // Remove middle
            Assert.Equal(2, arr.Count);
            // Only 0 and 2 should remain, but 2 should be moved to 1's slot
            Assert.Equal(10, arr.Get(0));
            Assert.Equal(30, arr.Get(2));
        }

        [Fact]
        public void Insert_Remove_Insert_ReusesSlot()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 1);
            arr.RemoveAt(0);
            arr.Insert(1, 2);
            Assert.Equal(1, arr.Count);
            Assert.Equal(2, arr.Get(1));
        }

        [Fact]
        public void MultipleOperations_Consistency()
        {
            var arr = new ComponentArray<string>(4);
            arr.Insert(0, "A");
            arr.Insert(1, "B");
            arr.Insert(2, "C");
            arr.RemoveAt(1);
            arr.Insert(3, "D");
            Assert.Equal(3, arr.Count);
            Assert.Equal("A", arr.Get(0));
            Assert.Equal("C", arr.Get(2));
            Assert.Equal("D", arr.Get(3));
            Assert.Throws<ComponentNotFoundException>(() => arr.Get(1));
        }

        [Fact]
        public void Insert_Remove_Insert_SameId()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 1);
            arr.RemoveAt(0);
            arr.Insert(0, 2);
            Assert.Equal(1, arr.Count);
            Assert.Equal(2, arr.Get(0));
        }

        [Fact]
        public void RemoveAt_LastElement()
        {
            var arr = new ComponentArray<int>(2);
            arr.Insert(0, 1);
            arr.Insert(1, 2);
            arr.RemoveAt(1);
            Assert.Equal(1, arr.Count);
            Assert.Equal(1, arr.Get(0));
            Assert.Throws<ComponentNotFoundException>(() => arr.Get(1));
        }

        [Fact]
        public void Insert_MaxIdWithinBounds()
        {
            var arr = new ComponentArray<int>(3);
            arr.Insert(2, 99);
            Assert.Equal(1, arr.Count);
            Assert.Equal(99, arr.Get(2));
        }

        [Fact]
        public void Insert_OutOfBoundsId_Throws()
        {
            var arr = new ComponentArray<int>(2);
            Assert.Throws<IndexOutOfRangeException>(() => arr.Insert(2, 5));
        }

        [Fact]
        public void Get_OutOfBoundsId_Throws()
        {
            var arr = new ComponentArray<int>(2);
            Assert.Throws<IndexOutOfRangeException>(() => arr.Get(2));
        }

        [Fact]
        public void RemoveAt_OutOfBoundsId_Throws()
        {
            var arr = new ComponentArray<int>(2);
            Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(2));
        }
    }
}