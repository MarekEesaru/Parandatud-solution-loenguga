using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Abc.Aids
{
    public static class GetRandom
    {
        private static readonly Random r = Random.Shared;
        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) => (sbyte)Int32(min, max);
        public static byte Uint8(byte min = byte.MinValue, byte max = byte.MaxValue) => (byte)Int32(min, max);
        public static short Int16(short min = short.MinValue, short max = short.MaxValue) => (short)Int32(min, max);
        public static ushort Uint16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue) => (ushort)Int32(min, max);

        public static int Int32(int min = int.MinValue, int max = int.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.Next(min, max);
        }
        public static uint Uint32(uint min = uint.MinValue, uint max = uint.MaxValue) => (uint)Int64(min, max);
        public static long Int64(long min = long.MinValue, long max = long.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.NextInt64(min, max);
        }
        public static ulong Uint64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) => (ulong)Double(min, max);
        public static double Double(double min = double.MinValue, double max = double.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.NextDouble() * (max - min) + min;
        }
        public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) => (decimal)Double((double)min, (double)max);

        public static float Float(float min = float.MinValue, float max = float.MaxValue) => (ulong)Double(min, max);
        public static char Char(char min, char max) => (char)Uint16(min, max);
        public static bool Bool() => r.Next(2) == 0;
        public static string String(byte minLength = byte.MinValue, byte maxLength = byte.MaxValue)
        {
            var length = Uint8(minLength, maxLength);
            var s = new char[length];
            for (var i = 0; i < length; i++) s[i] = Char('a', 'z');
            return new string(s);
        }
        public static DateTime DateTime(DateTime? min = null, DateTime? max = null)
        {
            var minTicks = min?.Ticks ?? System.DateTime.MinValue.Ticks;
            var maxTicks = max?.Ticks ?? System.DateTime.MaxValue.Ticks;
            var ticks = Int64(minTicks, maxTicks);
            return new DateTime(ticks); ;
        }
        public static System.Guid Guid()
        {
            Span<byte> buffer = stackalloc byte[16];
            r.NextBytes(buffer);
            return new Guid(buffer);
        }
        public static TimeSpan TimeSpan(TimeSpan? min = null, TimeSpan? max = null)
        {
            var minTicks = min?.Ticks ?? System.TimeSpan.MinValue.Ticks;
            var maxTicks = max?.Ticks ?? System.TimeSpan.MaxValue.Ticks;
            var ticks = Int64(minTicks, maxTicks);
            return new TimeSpan(ticks); ;
        }
        public static object Object(Type t)
        {
            var x = Nullable.GetUnderlyingType(t);
            if (x is not null) t = x;
            var o = Activator.CreateInstance(t);
            foreach (var p in t.GetProperties())
            {
                if (!p.CanWrite) continue;
                if (p.PropertyType.IsArray) continue;
                var v = IsClass(p) ? Object(p.PropertyType) : Value(p.PropertyType);
                p.SetValue(o, v);
            }
            return o;
        }
        private static bool IsClass(PropertyInfo p) => p.PropertyType.IsClass && p.PropertyType != typeof(string);
        private static object Value(Type t)
        {
            var x = Nullable.GetUnderlyingType(t);
            if (x is not null) t = x;
            if (t == typeof(sbyte)) return Int8();
            if (t == typeof(byte)) return Uint8();
            if (t == typeof(short)) return Int16();
            if (t == typeof(ushort)) return Uint16();
            if (t == typeof(int)) return Int32();
            if (t == typeof(uint)) return Uint32();
            if (t == typeof(long)) return Int64();
            if (t == typeof(ulong)) return Uint64();
            if (t == typeof(float)) return Float();
            if (t == typeof(double)) return Double();
            if (t == typeof(decimal)) return Decimal();
            if (t == typeof(char)) return Char((char)0, char.MaxValue);
            if (t == typeof(bool)) return Bool();
            if (t == typeof(string)) return String();
            if (t == typeof(DateTime)) return DateTime();
            if (t == typeof(TimeSpan)) return TimeSpan();
            if (t == typeof(Guid)) return Guid();
            throw new NotSupportedException($"Type {t} is not supported.");
        }
    }
}
