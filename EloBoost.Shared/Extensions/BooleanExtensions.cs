using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EloBoost.Shared.Extensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts objects to boolean
        /// </summary>
        public static bool ToBool(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if null or empty
        /// </summary>
        public static bool IsNullEmpty(this object value)
        {
            if (value == null) return true;
            if (value == DBNull.Value) return true;
            if (value.ToString().Trim() == string.Empty) return true;
            return false;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()
                    .GetName();
            }
            catch (Exception)
            {
                return enumValue.ToString();
            }
        }
    }
}
