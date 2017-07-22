using System.Collections.Generic;
using System;

namespace Acnos.GameLogic
{
    public class MovementPathComparer : IEqualityComparer<MovementPath>
    {
        private static readonly MovementPathComparer instance = new MovementPathComparer();

        public static MovementPathComparer Instance { get => instance; }

        public bool Equals(MovementPath x, MovementPath y)
        {
            return string.Compare(x.ToString(), y.ToString(), true) == 0;
        }

        public int GetHashCode(MovementPath obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
