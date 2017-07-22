using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Acnos.GameLogic
{
    public class MovementPath : IEnumerable<Vector>, IComparable<MovementPath>, IDeepClone<MovementPath>
    {
        private IEnumerable<Vector> _pathParts;

        public MovementPath(IEnumerable<Vector> pathParts)
        {
            _pathParts = pathParts.ToList();
            _stringCalculated = false;
            _sumCalculated = false;
        }

        public IEnumerator<Vector> GetEnumerator()
        {
            return _pathParts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_pathParts).GetEnumerator();
        }

        private string _string;
        private bool _stringCalculated = false;
        public override string ToString()
        {
            if (!_stringCalculated)
            {
                _string = Vector.OrderedVectorsToString(_pathParts);
                _stringCalculated = true;
            }
            return _string;
        }

        public int CompareTo(MovementPath other)
        {
            if (other == null) return 1;
            var leftEnum = _pathParts.GetEnumerator();
            var rightEnum = other.GetEnumerator();
            var leftNext = true;
            var rightNext = true;
            while (leftNext && rightNext)
            {
                leftNext = leftEnum.MoveNext();
                rightNext = rightEnum.MoveNext();
                if (leftNext && !rightNext) return -1;
                if (!leftNext && rightNext) return 1;
                if (!leftNext && !rightNext) return 0;
                var compare = leftEnum.Current.CompareTo(rightEnum.Current);
                if (compare != 0) return compare;
            }
            return 0;
        }

        public MovementPath DeepClone()
        {
            return new MovementPath(new List<Vector>(this._pathParts));
        }

        private Vector _sum;
        private bool _sumCalculated = false;
        public Vector Sum
        {
            get
            {
                if (!_sumCalculated)
                {
                    _sum = _pathParts.Aggregate((accumulator, value) => accumulator += value);
                    _sumCalculated = true;
                }
                return _sum;
            }
        }
    }
}
