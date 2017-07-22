using System.Collections.Generic;
using System.Linq;

namespace Acnos.GameLogic
{
    public static class MoveGenerator
    {
        private static Dictionary<string, PathSet> _pieceMoves = new Dictionary<string, PathSet>();

        public static PathSet GetPathSet(ShapeOrientationCollection pieceDefinition)
        {
            var pieceLookup = pieceDefinition.ToString();
            if (!_pieceMoves.ContainsKey(pieceLookup))
            {
                _pieceMoves[pieceLookup] = new PathSet(PathGenerator(pieceDefinition).ToArray());
            }
            return _pieceMoves[pieceLookup].DeepClone();
        }

        private static IEnumerable<MovementPath> PathGenerator(ShapeOrientationCollection pieceDefinition)
        {
            foreach (var shapeOrientationSequence in PermuteShapeOrientations(pieceDefinition).ToArray())
            {
                var indices = shapeOrientationSequence.Select(i => 0).ToList();
                indices[0] = -1;
                var pieces = shapeOrientationSequence.Select(so => Piece.OrientVectors(Piece.GetNonOrientedVectors(so.Shape), so.Orientation).ToList()).ToList();
                while (IncrementIndexList(indices, pieces))
                    yield return new MovementPath(pieces.Select((piece, idx) => piece[indices[idx]]).ToArray());
            }
        }

        private static bool IncrementIndexList(List<int> list, List<List<Vector>> pieces)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i]++;
                if (list[i] < pieces[i].Count)
                    return true;
                list[i] = 0;
            }
            return false;
        }

        private static IEnumerable<IList<ShapeOrientation>> PermuteShapeOrientations(IList<ShapeOrientation> original)
        {
            if (original.Count < 2)
            {
                yield return original;
                yield break;
            }
            var count = original.Count;
            var head = original[0];
            foreach (var subPerm in PermuteShapeOrientations(original.Skip(1).ToList()).ToArray())
            {
                yield return new List<ShapeOrientation> { head }.Concat(subPerm).ToList();
                for (var i = 1; i + 1 < count; i++)
                    yield return subPerm.Take(i).Concat(new[] { head }).Concat(subPerm.Skip(i)).ToList();
                yield return subPerm.Concat(new[] { head }).ToList();
            }
        }
    }
}
