using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Acnos.GameLogic
{
    public class MoveGeneratorEnumerator : IEnumerator<MovementPath>
    {
        private Dictionary<Vector, Dictionary<MovementPath, bool>> _dict;
        private IEnumerator<MovementPath> _currentEnum;
        private int _index;
        private MovementPath current;

        public MoveGeneratorEnumerator(Dictionary<Vector, Dictionary<MovementPath, bool>> dict)
        {
            _dict = dict;
            _index = -1;
            current = default(MovementPath);
            _currentEnum = null;
        }

        public MovementPath Current => current;

        object IEnumerator.Current => current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            //Two more recent language features are used here:

            //_currentEnum.MoveNext() means "get the object at variable _currentEnum and then
            //call its method MoveNext()".  This will throw an exception if _currentEnum is null.
            //_currentEnum?.MoveNext() means "get the object at variable _currentEnum.  If it's
            //null, ignore the next function call and make the resulting value null.  If it isn't
            //null, call its method MoveNext()".
            //This results in a value of type Nullable<bool> a.k.a. "bool?" -- it can be true,
            //false, or null.  If statements require a pure true or false though.

            //The second feature is the null-coalescing operator ??.  This means "if the thing
            //to my left is null, use the value to my right.  If the thing to my left is not
            //null, just preserve its value and ignore the value to my right."
            //So adding "?? false" to a Nullable<bool> says "if the value is true, keep it.
            //If the value is false, keep it.  If the value is null, use false instead."
            if (_currentEnum?.MoveNext() ?? false)
            {
                current = _currentEnum.Current;
                return true;
            }
            while (++_index < _dict.Count)
            {
                var kvp = _dict.ElementAt(_index);
                _currentEnum = kvp.Value?.GetEnumerator();
                if (_currentEnum?.MoveNext() ?? false)
                {
                    current = _currentEnum.Current;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            _index = -1;
            current = default(MovementPath);
            _currentEnum = null;
        }
    }
}
