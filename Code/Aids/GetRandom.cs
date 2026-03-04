using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Aids
{
    public static class GetRandom
    {
        private static readonly Random r = Random.Shared;
        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (sbyte)r.Next(min, max);
        }
        public static byte Uint8(byte min = byte.MinValue, byte max = byte.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (byte)r.Next(min, max);
        }
        public static short Int16(short min = short.MinValue, short max = short.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (short)r.Next(min, max);
        }
        public static ushort Uint16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (ushort)r.Next(min, max);
        }
        public static int Int32(int min = int.MinValue, int max = int.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.Next(min, max);
        }
        public static uint Uint32(uint min = uint.MinValue, uint max = uint.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (uint)r.Next((int)min, (int)max);
        }
        public static long Int64(long min = long.MinValue, long max = long.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.NextInt64(min, max);
        }
        public static ulong Uint64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (ulong)r.NextInt64((long)min, (long)max);
        }
        public static double Double(double min = double.MinValue, double max = double.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return r.NextDouble() * (max - min) + min;
        }
        public static decimal Decimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            var nextDouble = r.NextDouble();
            var range = max - min;
            var scaled = (decimal)nextDouble * range;
            return min + scaled;
        }
        public static float Float(float min = float.MinValue, float max = float.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (float)(r.NextDouble() * (max - min) + min);
        }
        public static char Char(char min = char.MinValue, char max = char.MaxValue)
        {
            if (min == max) return min;
            if (min > max) (min, max) = (max, min);
            return (char)r.Next(min, max);
        }
        public static bool Bool() => r.Next(2) == 0;
        public static string String(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                sb.Append(chars[r.Next(chars.Length)]);
            return sb.ToString();
        }
        public static System.DateTime DateTime(System.DateTime? min = null, System.DateTime? max = null)
        {
            var minValue = min ?? System.DateTime.MinValue;
            var maxValue = max ?? System.DateTime.MaxValue;
            if (minValue == maxValue) return minValue;
            if (minValue > maxValue) (minValue, maxValue) = (maxValue, minValue);
            var range = maxValue - minValue;
            var randomTicks = (long)(r.NextDouble() * range.Ticks);
            return minValue.AddTicks(randomTicks);
        }
        public static System.Guid Guid() => System.Guid.NewGuid();
        public static System.TimeSpan TimeSpan(System.TimeSpan? min = null, System.TimeSpan? max = null)
        {
            var minValue = min ?? System.TimeSpan.Zero;
            var maxValue = max ?? System.TimeSpan.MaxValue;
            if (minValue == maxValue) return minValue;
            if (minValue > maxValue) (minValue, maxValue) = (maxValue, minValue);
            var range = maxValue - minValue;
            var randomTicks = (long)(r.NextDouble() * range.Ticks);
            return minValue.Add(System.TimeSpan.FromTicks(randomTicks));
        }
    }
}
