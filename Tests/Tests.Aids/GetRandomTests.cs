using Abc.Aids;
namespace Abc.Tests.Aids;

[TestClass] public sealed class GetRandomTests
{
    private const byte min = byte.MinValue;
    private const byte max = byte.MaxValue;
    private const sbyte smin = sbyte.MinValue;
    private const sbyte smax = sbyte.MaxValue;
    [TestMethod] public void Int8Test() => Assert.AreNotEqual(GetRandom.Int8((sbyte)smin, (sbyte)smax), GetRandom.Int8((sbyte)smin, (sbyte)smax));
    [TestMethod] public void Uint8Test() => Assert.AreNotEqual(GetRandom.Uint8(min, max), GetRandom.Uint8(min, max));
    [TestMethod] public void Int16Test() => Assert.AreNotEqual(GetRandom.Int16(min, max), GetRandom.Int16(min, max));
    [TestMethod] public void Uint16Test() => Assert.AreNotEqual(GetRandom.Uint16(min, max), GetRandom.Uint16(min, max));
    [TestMethod] public void Int32Test() => Assert.AreNotEqual(GetRandom.Int32(min, max), GetRandom.Int32(min, max));
    [TestMethod] public void Uint32Test() => Assert.AreNotEqual(GetRandom.Uint32(min, max), GetRandom.Uint32(min, max));
    [TestMethod] public void Int64Test() => Assert.AreNotEqual(GetRandom.Int64(min, max), GetRandom.Int64(min, max));
    [TestMethod] public void Uint64Test() => Assert.AreNotEqual(GetRandom.Uint64(min, max), GetRandom.Uint64(min, max));
    [TestMethod] public void DoubleTest() => Assert.AreNotEqual(GetRandom.Double(min, max), GetRandom.Double(min, max));
    [TestMethod] public void DecimalTest() => Assert.AreNotEqual(GetRandom.Decimal(min, max), GetRandom.Decimal(min, max));
    [TestMethod] public void StringTest() => Assert.AreNotEqual(GetRandom.String(), GetRandom.String());
    [TestMethod] public void DateTimeTest() => Assert.AreNotEqual(GetRandom.DateTime(), GetRandom.DateTime());
    [TestMethod] public void TimeSpanTest() => Assert.AreNotEqual(GetRandom.TimeSpan(), GetRandom.TimeSpan());
    [TestMethod] public void GuidTest() => Assert.AreNotEqual(GetRandom.Guid(), GetRandom.Guid());
    [TestMethod] public void CharTest() => Assert.AreNotEqual(GetRandom.Char(), GetRandom.Char());
}
