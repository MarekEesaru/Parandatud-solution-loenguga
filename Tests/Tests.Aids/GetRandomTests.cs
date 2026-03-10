using Abc.Aids;
using Abc.Data.Common;
namespace Abc.Tests.Aids;

[TestClass] public sealed class GetRandomTests
{
    private const byte min = byte.MinValue;
    private const byte max = byte.MaxValue;
    private const sbyte smin = sbyte.MinValue;
    private const sbyte smax = sbyte.MaxValue;
    [TestMethod] public void Int8Test() => Assert.AreNotEqual(GetRandom.Int8((sbyte)smin, (sbyte)smax), GetRandom.Int8((sbyte)smin, (sbyte)smax));
    [TestMethod] public void Uint8Test() => Assert.AreNotEqual(GetRandom.Uint8(0, max), GetRandom.Uint8(0, max));
    [TestMethod] public void Int16Test() => Assert.AreNotEqual(GetRandom.Int16(min, max), GetRandom.Int16(min, max));
    [TestMethod] public void Uint16Test() => Assert.AreNotEqual(GetRandom.Uint16(0, max), GetRandom.Uint16(0, max));
    [TestMethod] public void Int32Test() => Assert.AreNotEqual(GetRandom.Int32(min, max), GetRandom.Int32(min, max));
    [TestMethod] public void Uint32Test() => Assert.AreNotEqual(GetRandom.Uint32(0, max), GetRandom.Uint32(0, max));
    [TestMethod] public void Int64Test() => Assert.AreNotEqual(GetRandom.Int64(min, max), GetRandom.Int64(min, max));
    [TestMethod] public void Uint64Test() => Assert.AreNotEqual(GetRandom.Uint64(0, max), GetRandom.Uint64(0, max));
    [TestMethod] public void DoubleTest() => Assert.AreNotEqual(GetRandom.Double(min, max), GetRandom.Double(min, max));
    [TestMethod] public void DecimalTest() => Assert.AreNotEqual(GetRandom.Decimal(min, max), GetRandom.Decimal(min, max));
    [TestMethod] public void StringTest() => Assert.AreNotEqual(GetRandom.String(), GetRandom.String());
    [TestMethod] public void DateTimeTest()
    {
        var minDate = DateTime.Now.AddYears(-100);
        var maxDate = DateTime.Now.AddYears(100);
        Assert.AreNotEqual(GetRandom.DateTime(minDate, maxDate), GetRandom.DateTime(minDate, maxDate));
    }
    [TestMethod] public void TimeSpanTest()
    {
        var minSpan = TimeSpan.FromTicks(DateTime.Now.AddYears(-100).Ticks);
        var maxSpan = TimeSpan.FromTicks(DateTime.Now.AddYears(-100).Ticks);
        Assert.AreNotEqual(GetRandom.TimeSpan(minSpan, maxSpan), GetRandom.TimeSpan(minSpan, maxSpan));
    }
    [TestMethod] public void GuidTest() => Assert.AreNotEqual(GetRandom.Guid(), GetRandom.Guid());
    [TestMethod] public void CharTest() => Assert.AreNotEqual(GetRandom.Char((char) 0, (char) max), GetRandom.Char((char)0, (char) max));
    [TestMethod] public void FloatTest() => Assert.AreNotEqual(GetRandom.Float(min, max), GetRandom.Float(min, max));
    [TestMethod] public void BoolTest()
    {
        var x = GetRandom.Bool();
        bool y = GetRandom.Bool();
        for (var i = 0; i < 10; i++)
        {
            if (x != y) break;
            y = GetRandom.Bool();
        }
        Assert.AreNotEqual(x, y);
    }
    private class TestClass : NamedEntity { }

       [TestMethod] public void ObjectTest()
       {
           var o1 = GetRandom.Object(typeof(TestClass));
           var o2 = GetRandom.Object(typeof(TestClass));
           foreach (var p in typeof(TestClass).GetProperties())
           {
               if (p.PropertyType.IsArray) continue;
               Assert.AreNotEqual(p.GetValue(o1), p.GetValue(o2));
           }
    }
}
