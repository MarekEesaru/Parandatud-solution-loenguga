using System;
using System.Collections.Generic;
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
            return new string (s);
        }
        public static DateTime DateTime(DateTime? min = null, DateTime? max = null)
        {
            var minTicks = min?.Ticks ?? System.DateTime.MinValue.Ticks;
            var maxTicks = max?.Ticks ?? System.DateTime.MaxValue.Ticks;
            var ticks = Int64(minTicks, maxTicks);
            return new DateTime(ticks);;
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
    }
}
