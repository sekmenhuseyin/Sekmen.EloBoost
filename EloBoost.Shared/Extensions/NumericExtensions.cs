using System;

namespace EloBoost.Shared.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
        /// Every time you do new Random() it is initialized .
        /// This means that in a tight loop you get the same value lots of times.
        /// You should keep a single Random instance and keep using Next on the same instance.
        /// </summary>
        private static readonly Random Getrandom = new Random();


        /// <summary>
        /// Generates really random number
        /// </summary>
        /// <param name="min">start integer inclusive</param>
        /// <param name="max">end integer exclusive</param>
        /// <returns></returns>
        public static int GetRandomNumber(int min, int max)
        {
            lock (Getrandom) // synchronize
            {
                return Getrandom.Next(min, max);
            }
        }

        /// <summary>
        /// convert to decimal
        /// </summary>
        public static decimal ToDecimal(this object value, decimal defaultValue = 0.0M)
        {
            try { return Convert.ToDecimal(value); }
            catch { return defaultValue; }
        }
        /// <summary>
        /// Convert to double
        /// </summary>
        public static double ToDouble(this object value, double defaultValue = 0.0)
        {
            try { return Convert.ToDouble(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Convert to float
        /// </summary>
        public static float ToFloat(this object value, float defaultValue = 0.0f)
        {
            try { return Convert.ToSingle(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Convert to integer
        /// </summary>
        public static int ToInteger(this object value, int defaultValue = 0)
        {
            try { return Convert.ToInt32(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Convert to long
        /// </summary>
        public static long ToLong(this object value, long defaultValue = 0)
        {
            try { return Convert.ToInt64(value); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// Convert to short
        /// </summary>
        public static short ToShort(this object value, short defaultValue = 0)
        {
            try { return Convert.ToInt16(value); }
            catch { return defaultValue; }
        }
    }
}
