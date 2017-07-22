using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Acnos.GameLogic
{
    public class PathSet : IEnumerable<MovementPath>, IDictionary<Vector, Dictionary<MovementPath, bool>>, IDeepClone<PathSet>
    {
        private Dictionary<Vector, Dictionary<MovementPath, bool>> _dict;

        public PathSet() { _dict = new Dictionary<Vector, Dictionary<MovementPath, bool>>(); }

        public PathSet(IEnumerable<MovementPath> paths)
        {
            _dict = new Dictionary<Vector, Dictionary<MovementPath, bool>>();
            foreach (var path in paths)
            {
                if (!_dict.ContainsKey(path.Sum))
                    _dict[path.Sum] = new Dictionary<MovementPath, bool>();
                _dict[path.Sum][path] = true;
            }
        }

        public PathSet(Dictionary<Vector, Dictionary<MovementPath, bool>> dict)
        {
            _dict = dict;
        }

        public Dictionary<MovementPath, bool> this[Vector key] { get => _dict[key]; set => _dict[key] = value; }

        public ICollection<Vector> Keys => _dict.Keys;

        public ICollection<Dictionary<MovementPath, bool>> Values => _dict.Values;

        public int Count => _dict.Count;

        public bool IsReadOnly => false;

        public void Add(Vector key, Dictionary<MovementPath, bool> value)
        {
            _dict.Add(key, value);
        }

        public void Add(KeyValuePair<Vector, Dictionary<MovementPath, bool>> item)
        {
            _dict.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _dict.Clear();
        }

        public bool Contains(KeyValuePair<Vector, Dictionary<MovementPath, bool>> item)
        {
            return _dict.Contains(item);
        }

        public bool ContainsKey(Vector key)
        {
            return _dict.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Vector, Dictionary<MovementPath, bool>>[] array, int arrayIndex)
        {
            var fromArray = _dict.ToArray();
            Array.ConstrainedCopy(fromArray, 0, array, arrayIndex, fromArray.Length);
        }

        public bool Remove(Vector key)
        {
            return _dict.Remove(key);
        }

        public bool Remove(KeyValuePair<Vector, IEnumerable<MovementPath>> item)
        {
            return _dict.ContainsKey(item.Key) && _dict[item.Key].Keys.SequenceEqual(item.Value) && _dict.Remove(item.Key);
        }

        public bool TryGetValue(Vector key, out Dictionary<MovementPath, bool> value)
        {
            return _dict.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var allValues = new Dictionary<MovementPath, bool>();
            foreach (var kvp in _dict)
                if (kvp.Value != null)
                    foreach (var v in kvp.Value)
                        allValues[v.Key] = true;
            return allValues.Keys.GetEnumerator();
        }

        IEnumerator<KeyValuePair<Vector, Dictionary<MovementPath, bool>>> IEnumerable<KeyValuePair<Vector, Dictionary<MovementPath, bool>>>.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        public IEnumerator<MovementPath> GetEnumerator()
        {
            var allValues = new Dictionary<MovementPath, bool>();
            foreach (var kvp in _dict)
                if (kvp.Value != null)
                    foreach (var v in kvp.Value)
                        allValues[v.Key] = true;
            return allValues.Keys.GetEnumerator();
        }

        public bool Remove(KeyValuePair<Vector, Dictionary<MovementPath, bool>> item)
        {
            return _dict.ContainsKey(item.Key) && _dict[item.Key] == item.Value && _dict.Remove(item.Key);
        }

        public PathSet DeepClone()
        {
            var dict = new Dictionary<Vector, Dictionary<MovementPath, bool>>();

            foreach (var kvp in _dict)
                dict[kvp.Key] = new Dictionary<MovementPath, bool>(kvp.Value);

            return new PathSet(dict);
        }
    }
}
