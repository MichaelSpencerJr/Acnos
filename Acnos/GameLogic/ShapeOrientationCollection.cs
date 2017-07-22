using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acnos.GameLogic
{
    /// <summary>
    /// List of ShapeOrientation pairs which implements a modification flag,
    /// so we can tell if outside code has changed this stack of shapes since
    /// last time we checked
    /// </summary>
    public class ShapeOrientationCollection : IList<ShapeOrientation>, IDeepClone<ShapeOrientationCollection>
    {
        public ShapeOrientationCollection(IEnumerable<ShapeOrientation> list, bool modified)
        {
            _list = new List<ShapeOrientation>();
            foreach (var shapeorientation in list)
                _list.Add(shapeorientation);
            Modified = modified;
        }

        internal List<ShapeOrientation> _list;

        public bool Modified { get; set; }

        public ShapeOrientationCollection()
        {
            _list = new List<ShapeOrientation>();
            Modified = false;
        }

        public ShapeOrientation this[int index]
        {
            get { return _list[index]; }
            set
            {
                var mod = (_list[index].Equals(value));
                _list[index] = value;
                Modified = true;
            }
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(ShapeOrientation item)
        {
            _list.Add(item);
            Modified = true;
        }

        public void Clear()
        {
            _list.Clear();
            Modified = true;
        }

        public bool Contains(ShapeOrientation item) => _list.Contains(item);

        public void CopyTo(ShapeOrientation[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ShapeOrientation> GetEnumerator() => _list.GetEnumerator();

        public int IndexOf(ShapeOrientation item) => _list.IndexOf(item);

        public void Insert(int index, ShapeOrientation item)
        {
            _list.Insert(index, item);
            Modified = true;
        }

        public bool Remove(ShapeOrientation item)
        {
            var retval = _list.Remove(item);
            if (retval)
                Modified = true;
            return retval;
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            Modified = true;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_list).GetEnumerator();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var so in _list.OrderBy(so => so.Shape).ThenBy(so => so.Orientation))
            {
                sb.Append('-');
                sb.Append((char)so.Shape);
                sb.Append(Vector.DistinctVectorsToString(Piece.OrientVectors(Piece.GetNonOrientedVectors(so.Shape), so.Orientation)));
            }

            return sb.ToString();

        }

        public ShapeOrientationCollection DeepClone()
        {
            return new ShapeOrientationCollection(_list, Modified);
        }
    }
}
