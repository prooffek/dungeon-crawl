using System;
using System.Collections.Generic;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {
        private static Random random = new Random();
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }

        /// <summary>
        /// Returns all possible enum values in typed format
        /// </summary>
        /// <returns><see cref="Array"/> of <see cref="{T}"/>s</returns>
        public static IEnumerable<T> GetEnumMembers<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(T);

            if (!enumType.IsEnum) throw new ArgumentException();

            return (T[])Enum.GetValues(enumType);
        }

        internal static bool GetRandomBoolean()
        {
            return Convert.ToBoolean(random.Next(2));
        }
    }
}
