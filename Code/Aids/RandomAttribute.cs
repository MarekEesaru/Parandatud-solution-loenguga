using System.Runtime.InteropServices;

namespace Abc.Aids;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RandomAttribute : Attribute
{
    public int Min { get; private set; }
    public int Max { get; private set; }
    public RandomAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
    public object CreateValue(Type t)
    {
        t = Nullable.GetUnderlyingType(t) ?? t;
        if (t == typeof(string)) return GetRandom.String((byte)Min, (byte)Max);
        //if (t == typeof(DateTime)) return GetRandom.DateTime(date(Min), date(Max));
        if (t == typeof(double)) return GetRandom.Double(Min, Max);
        if (t == typeof(decimal)) return GetRandom.Decimal(Min, Max);
        if (t == typeof(int)) return GetRandom.Int32(Min, Max);
        return GetRandom.Value(t);
    }
}

