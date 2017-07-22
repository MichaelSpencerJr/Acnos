using Acnos.GameLogic.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Acnos.GameLogic
{
    public static class RotationGenerator
    {
        public static IEnumerable<Orientation> GetUniqueOrientations(ShapeOrientationCollection pieceDefinition)
        {
            yield return Orientation.Original;

            for (var targetOrientation = Orientation.Flip; targetOrientation <= Orientation.LeftFlip; targetOrientation++)
            {
                var targetRotation = Piece.GetRotation(Orientation.Original, targetOrientation);
                //For each adjusted orientation I'll try to map oriented paths to 
                //original paths and see if the orientation is equivalent or not.
                var originalPathSet = MoveGenerator.GetPathSet(pieceDefinition);
                var adjustedShape = new ShapeOrientationCollection(pieceDefinition.Select(so => new ShapeOrientation(so.Shape, Piece.RotateOrientation(so.Orientation, targetRotation))).ToArray(), true);
                var adjustedPathSet = MoveGenerator.GetPathSet(adjustedShape);

                var mismatch = false;

                while (originalPathSet.Count > 0 && adjustedPathSet.Count > 0)
                {
                    var nextVector = originalPathSet.Keys.First();
                    var nextVectorPaths = originalPathSet[nextVector];
                    if (!adjustedPathSet.ContainsKey(nextVector))
                    {
                        yield return targetOrientation;
                        break;
                    }
                    var adjustedVectorPaths = adjustedPathSet[nextVector];
                    if (nextVectorPaths.Count != adjustedVectorPaths.Count)
                    {
                        mismatch = true;
                    }
                    else
                        foreach (var path in nextVectorPaths.Keys)
                        {
                            if (!adjustedVectorPaths.Any(x => x.Key.ToString() == path.ToString()))
                            {
                                mismatch = true;
                                break;
                            }
                        }
                    if (mismatch)
                    {
                        yield return targetOrientation;
                        break;
                    }
                    originalPathSet.Remove(nextVector);
                    adjustedPathSet.Remove(nextVector);
                }
            }
        }
    }
}
