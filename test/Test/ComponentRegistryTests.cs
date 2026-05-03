using ECS;

namespace UnitsTests;

public class ComponentRegistryTests
{
    private struct TestComponent1 { }
    private struct TestComponent2 { }
    private struct TestComponent3 { }
    private struct TestComponent4 { }
    private struct TestComponent5 { }
    private struct TestComponent6 { }
    private struct TestComponent7 { }
    private struct TestComponent8 { }
    private struct TestComponent9 { }
    private struct TestComponent10 { }
    private struct TestComponent11 { }
    private struct TestComponent12 { }
    private struct TestComponent13 { }
    private struct TestComponent14 { }
    private struct TestComponent15 { }
    private struct TestComponent16 { }
    private struct TestComponent17 { }
    private struct TestComponent18 { }
    private struct TestComponent19 { }
    private struct TestComponent20 { }
    private struct TestComponent21 { }
    private struct TestComponent22 { }
    private struct TestComponent23 { }
    private struct TestComponent24 { }
    private struct TestComponent25 { }
    private struct TestComponent26 { }
    private struct TestComponent27 { }
    private struct TestComponent28 { }
    private struct TestComponent29 { }
    private struct TestComponent30 { }
    private struct TestComponent31 { }
    private struct TestComponent32 { }
    private struct TestComponent33 { }
    private struct TestComponent34 { }
    private struct TestComponent35 { }
    private struct TestComponent36 { }
    private struct TestComponent37 { }
    private struct TestComponent38 { }
    private struct TestComponent39 { }
    private struct TestComponent40 { }
    private struct TestComponent41 { }
    private struct TestComponent42 { }
    private struct TestComponent43 { }
    private struct TestComponent44 { }
    private struct TestComponent45 { }
    private struct TestComponent46 { }
    private struct TestComponent47 { }
    private struct TestComponent48 { }
    private struct TestComponent49 { }
    private struct TestComponent50 { }
    private struct TestComponent51 { }
    private struct TestComponent52 { }
    private struct TestComponent53 { }
    private struct TestComponent54 { }
    private struct TestComponent55 { }
    private struct TestComponent56 { }
    private struct TestComponent57 { }
    private struct TestComponent58 { }
    private struct TestComponent59 { }
    private struct TestComponent60 { }
    private struct TestComponent61 { }
    private struct TestComponent62 { }
    private struct TestComponent63 { }
    private struct TestComponent64 { }
    private struct TestComponent65 { }

    [Fact]
    public void RegisterComponent_AssignsUniqueFlags()
    {
        var componentRegistry = new ComponentRegistry();

        ulong flag1 = componentRegistry.Register<TestComponent1>();
        ulong flag2 = componentRegistry.Register<TestComponent2>();
        ulong flag3 = componentRegistry.Register<TestComponent3>();
        ulong flag4 = componentRegistry.Register<TestComponent4>();
        ulong flag5 = componentRegistry.Register<TestComponent5>();
        ulong flag6 = componentRegistry.Register<TestComponent6>();
        ulong flag7 = componentRegistry.Register<TestComponent7>();
        ulong flag8 = componentRegistry.Register<TestComponent8>();
        ulong flag9 = componentRegistry.Register<TestComponent9>();
        ulong flag10 = componentRegistry.Register<TestComponent10>();
        ulong flag11 = componentRegistry.Register<TestComponent11>();
        ulong flag12 = componentRegistry.Register<TestComponent12>();
        ulong flag13 = componentRegistry.Register<TestComponent13>();
        ulong flag14 = componentRegistry.Register<TestComponent14>();
        ulong flag15 = componentRegistry.Register<TestComponent15>();
        ulong flag16 = componentRegistry.Register<TestComponent16>();
        ulong flag17 = componentRegistry.Register<TestComponent17>();
        ulong flag18 = componentRegistry.Register<TestComponent18>();
        ulong flag19 = componentRegistry.Register<TestComponent19>();
        ulong flag20 = componentRegistry.Register<TestComponent20>();
        ulong flag21 = componentRegistry.Register<TestComponent21>();
        ulong flag22 = componentRegistry.Register<TestComponent22>();
        ulong flag23 = componentRegistry.Register<TestComponent23>();
        ulong flag24 = componentRegistry.Register<TestComponent24>();
        ulong flag25 = componentRegistry.Register<TestComponent25>();
        ulong flag26 = componentRegistry.Register<TestComponent26>();
        ulong flag27 = componentRegistry.Register<TestComponent27>();
        ulong flag28 = componentRegistry.Register<TestComponent28>();
        ulong flag29 = componentRegistry.Register<TestComponent29>();
        ulong flag30 = componentRegistry.Register<TestComponent30>();
        ulong flag31 = componentRegistry.Register<TestComponent31>();
        ulong flag32 = componentRegistry.Register<TestComponent32>();
        ulong flag33 = componentRegistry.Register<TestComponent33>();
        ulong flag34 = componentRegistry.Register<TestComponent34>();
        ulong flag35 = componentRegistry.Register<TestComponent35>();
        ulong flag36 = componentRegistry.Register<TestComponent36>();
        ulong flag37 = componentRegistry.Register<TestComponent37>();
        ulong flag38 = componentRegistry.Register<TestComponent38>();
        ulong flag39 = componentRegistry.Register<TestComponent39>();
        ulong flag40 = componentRegistry.Register<TestComponent40>();
        ulong flag41 = componentRegistry.Register<TestComponent41>();
        ulong flag42 = componentRegistry.Register<TestComponent42>();
        ulong flag43 = componentRegistry.Register<TestComponent43>();
        ulong flag44 = componentRegistry.Register<TestComponent44>();
        ulong flag45 = componentRegistry.Register<TestComponent45>();
        ulong flag46 = componentRegistry.Register<TestComponent46>();
        ulong flag47 = componentRegistry.Register<TestComponent47>();
        ulong flag48 = componentRegistry.Register<TestComponent48>();
        ulong flag49 = componentRegistry.Register<TestComponent49>();
        ulong flag50 = componentRegistry.Register<TestComponent50>();
        ulong flag51 = componentRegistry.Register<TestComponent51>();
        ulong flag52 = componentRegistry.Register<TestComponent52>();
        ulong flag53 = componentRegistry.Register<TestComponent53>();
        ulong flag54 = componentRegistry.Register<TestComponent54>();
        ulong flag55 = componentRegistry.Register<TestComponent55>();
        ulong flag56 = componentRegistry.Register<TestComponent56>();
        ulong flag57 = componentRegistry.Register<TestComponent57>();
        ulong flag58 = componentRegistry.Register<TestComponent58>();
        ulong flag59 = componentRegistry.Register<TestComponent59>();
        ulong flag60 = componentRegistry.Register<TestComponent60>();
        ulong flag61 = componentRegistry.Register<TestComponent61>();
        ulong flag62 = componentRegistry.Register<TestComponent62>();
        ulong flag63 = componentRegistry.Register<TestComponent63>();
        ulong flag64 = componentRegistry.Register<TestComponent64>();

        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001UL, flag1);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000010UL, flag2);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000100UL, flag3);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00001000UL, flag4);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00010000UL, flag5);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00100000UL, flag6);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_01000000UL, flag7);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_10000000UL, flag8);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000001_00000000UL, flag9);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000010_00000000UL, flag10);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000100_00000000UL, flag11);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00001000_00000000UL, flag12);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00010000_00000000UL, flag13);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00100000_00000000UL, flag14);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_01000000_00000000UL, flag15);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_10000000_00000000UL, flag16);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000001_00000000_00000000UL, flag17);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000010_00000000_00000000UL, flag18);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000100_00000000_00000000UL, flag19);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00001000_00000000_00000000UL, flag20);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00010000_00000000_00000000UL, flag21);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00100000_00000000_00000000UL, flag22);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_01000000_00000000_00000000UL, flag23);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_10000000_00000000_00000000UL, flag24);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000001_00000000_00000000_00000000UL, flag25);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000010_00000000_00000000_00000000UL, flag26);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000100_00000000_00000000_00000000UL, flag27);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00001000_00000000_00000000_00000000UL, flag28);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00010000_00000000_00000000_00000000UL, flag29);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00100000_00000000_00000000_00000000UL, flag30);
        Assert.Equal(0b00000000_00000000_00000000_00000000_01000000_00000000_00000000_00000000UL, flag31);
        Assert.Equal(0b00000000_00000000_00000000_00000000_10000000_00000000_00000000_00000000UL, flag32);
        Assert.Equal(0b00000000_00000000_00000000_00000001_00000000_00000000_00000000_00000000UL, flag33);
        Assert.Equal(0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000000UL, flag34);
        Assert.Equal(0b00000000_00000000_00000000_00000100_00000000_00000000_00000000_00000000UL, flag35);
        Assert.Equal(0b00000000_00000000_00000000_00001000_00000000_00000000_00000000_00000000UL, flag36);
        Assert.Equal(0b00000000_00000000_00000000_00010000_00000000_00000000_00000000_00000000UL, flag37);
        Assert.Equal(0b00000000_00000000_00000000_00100000_00000000_00000000_00000000_00000000UL, flag38);
        Assert.Equal(0b00000000_00000000_00000000_01000000_00000000_00000000_00000000_00000000UL, flag39);
        Assert.Equal(0b00000000_00000000_00000000_10000000_00000000_00000000_00000000_00000000UL, flag40);
        Assert.Equal(0b00000000_00000000_00000001_00000000_00000000_00000000_00000000_00000000UL, flag41);
        Assert.Equal(0b00000000_00000000_00000010_00000000_00000000_00000000_00000000_00000000UL, flag42);
        Assert.Equal(0b00000000_00000000_00000100_00000000_00000000_00000000_00000000_00000000UL, flag43);
        Assert.Equal(0b00000000_00000000_00001000_00000000_00000000_00000000_00000000_00000000UL, flag44);
        Assert.Equal(0b00000000_00000000_00010000_00000000_00000000_00000000_00000000_00000000UL, flag45);
        Assert.Equal(0b00000000_00000000_00100000_00000000_00000000_00000000_00000000_00000000UL, flag46);
        Assert.Equal(0b00000000_00000000_01000000_00000000_00000000_00000000_00000000_00000000UL, flag47);
        Assert.Equal(0b00000000_00000000_10000000_00000000_00000000_00000000_00000000_00000000UL, flag48);
        Assert.Equal(0b00000000_00000001_00000000_00000000_00000000_00000000_00000000_00000000UL, flag49);
        Assert.Equal(0b00000000_00000010_00000000_00000000_00000000_00000000_00000000_00000000UL, flag50);
        Assert.Equal(0b00000000_00000100_00000000_00000000_00000000_00000000_00000000_00000000UL, flag51);
        Assert.Equal(0b00000000_00001000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag52);
        Assert.Equal(0b00000000_00010000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag53);
        Assert.Equal(0b00000000_00100000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag54);
        Assert.Equal(0b00000000_01000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag55);
        Assert.Equal(0b00000000_10000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag56);
        Assert.Equal(0b00000001_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag57);
        Assert.Equal(0b00000010_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag58);
        Assert.Equal(0b00000100_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag59);
        Assert.Equal(0b00001000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag60);
        Assert.Equal(0b00010000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag61);
        Assert.Equal(0b00100000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag62);
        Assert.Equal(0b01000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag63);
        Assert.Equal(0b10000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag64);
    }

    [Fact]
    public void RegisterComponent_ThrowsIfAlreadyRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        componentRegistry.Register<TestComponent1>();
        var ex = Assert.Throws<InvalidOperationException>(() => componentRegistry.Register<TestComponent1>());
        Assert.Contains("already registered", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void RegisterComponent_ThrowsWhenExceedingMaxComponents()
    {
        var componentRegistry = new ComponentRegistry();

        componentRegistry.Register<TestComponent1>();
        componentRegistry.Register<TestComponent2>();
        componentRegistry.Register<TestComponent3>();
        componentRegistry.Register<TestComponent4>();
        componentRegistry.Register<TestComponent5>();
        componentRegistry.Register<TestComponent6>();
        componentRegistry.Register<TestComponent7>();
        componentRegistry.Register<TestComponent8>();
        componentRegistry.Register<TestComponent9>();
        componentRegistry.Register<TestComponent10>();
        componentRegistry.Register<TestComponent11>();
        componentRegistry.Register<TestComponent12>();
        componentRegistry.Register<TestComponent13>();
        componentRegistry.Register<TestComponent14>();
        componentRegistry.Register<TestComponent15>();
        componentRegistry.Register<TestComponent16>();
        componentRegistry.Register<TestComponent17>();
        componentRegistry.Register<TestComponent18>();
        componentRegistry.Register<TestComponent19>();
        componentRegistry.Register<TestComponent20>();
        componentRegistry.Register<TestComponent21>();
        componentRegistry.Register<TestComponent22>();
        componentRegistry.Register<TestComponent23>();
        componentRegistry.Register<TestComponent24>();
        componentRegistry.Register<TestComponent25>();
        componentRegistry.Register<TestComponent26>();
        componentRegistry.Register<TestComponent27>();
        componentRegistry.Register<TestComponent28>();
        componentRegistry.Register<TestComponent29>();
        componentRegistry.Register<TestComponent30>();
        componentRegistry.Register<TestComponent31>();
        componentRegistry.Register<TestComponent32>();
        componentRegistry.Register<TestComponent33>();
        componentRegistry.Register<TestComponent34>();
        componentRegistry.Register<TestComponent35>();
        componentRegistry.Register<TestComponent36>();
        componentRegistry.Register<TestComponent37>();
        componentRegistry.Register<TestComponent38>();
        componentRegistry.Register<TestComponent39>();
        componentRegistry.Register<TestComponent40>();
        componentRegistry.Register<TestComponent41>();
        componentRegistry.Register<TestComponent42>();
        componentRegistry.Register<TestComponent43>();
        componentRegistry.Register<TestComponent44>();
        componentRegistry.Register<TestComponent45>();
        componentRegistry.Register<TestComponent46>();
        componentRegistry.Register<TestComponent47>();
        componentRegistry.Register<TestComponent48>();
        componentRegistry.Register<TestComponent49>();
        componentRegistry.Register<TestComponent50>();
        componentRegistry.Register<TestComponent51>();
        componentRegistry.Register<TestComponent52>();
        componentRegistry.Register<TestComponent53>();
        componentRegistry.Register<TestComponent54>();
        componentRegistry.Register<TestComponent55>();
        componentRegistry.Register<TestComponent56>();
        componentRegistry.Register<TestComponent57>();
        componentRegistry.Register<TestComponent58>();
        componentRegistry.Register<TestComponent59>();
        componentRegistry.Register<TestComponent60>();
        componentRegistry.Register<TestComponent61>();
        componentRegistry.Register<TestComponent62>();
        componentRegistry.Register<TestComponent63>();
        componentRegistry.Register<TestComponent64>();

        Assert.Throws<InvalidOperationException>(() => componentRegistry.Register<TestComponent65>());
    }

    [Fact]
    public void GetFlag_ReturnsCorrectFlag()
    {
        var componentRegistry = new ComponentRegistry();
        ulong flag = componentRegistry.Register<TestComponent1>();
        Assert.Equal(flag, componentRegistry.GetFlag<TestComponent1>());
    }

    [Fact]
    public void GetFlag_ThrowsIfNotRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        var ex = Assert.Throws<InvalidOperationException>(() => componentRegistry.GetFlag<TestComponent1>());
        Assert.Contains("not registered", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TryGetFlag_ReturnsTrueAndCorrectFlag_IfRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        ulong expected = componentRegistry.Register<TestComponent1>();
        bool found = componentRegistry.TryGetFlag<TestComponent1>(out ulong flag);
        Assert.True(found);
        Assert.Equal(expected, flag);
    }

    [Fact]
    public void TryGetFlag_ReturnsFalseAndZero_IfNotRegistered()
    {
        var componentRegistry = new ComponentRegistry();
        bool found = componentRegistry.TryGetFlag<TestComponent1>(out ulong flag);
        Assert.False(found);
        Assert.Equal(0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000UL, flag);
    }
}

