using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acnos.GameLogic;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Acnos.GameLogic.Enums;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class PathSetTest
    {
        private static string TestEndSquares(PathSet computed, params Vector[] expected)
        {
            var exp = new HashSet<Vector>(expected);
            var found = new HashSet<Vector>();
            var actual = new List<MovementPath>(computed);
            for (var i = actual.Count - 1; i >= 0; i--)
            {
                if (exp.Contains(actual[i].Sum))
                {
                    found.Add(actual[i].Sum);
                    actual.RemoveAt(i);
                }
            }
            var sb = new StringBuilder();
            foreach (var missingExpected in exp.Except(found))
                sb.AppendLine($"Missing moves for expected vector {missingExpected}");
            foreach (var unexpectedActual in actual)
                sb.AppendLine($"Got move {unexpectedActual} which didn't match an expected vector");
            return sb.ToString().Trim();
        }

        private static string TestPaths(PathSet computed, params MovementPath[] expected)
        {
            var exp = new HashSet<MovementPath>(expected);
            var actual = new List<MovementPath>(computed);
            for (var i = actual.Count - 1; i >= 0; i--)
            {
                if (exp.Contains(actual[i]))
                {
                    exp.Remove(actual[i]);
                    actual.RemoveAt(i);
                }
            }
            var sb = new StringBuilder();
            foreach (var missingExpected in exp)
                sb.AppendLine($"Missing expected movement path {missingExpected}");
            foreach (var unexpectedActual in actual)
                sb.AppendLine($"Unexpected movement path {unexpectedActual} found in calculated result");
            return sb.ToString().Trim();
        }

        [TestMethod]
        public void SinglePiece()
        {
            var piece = new Piece(Side.Player1, 5,
                new ShapeOrientation(Shape.Cross, Orientation.LeftFlip),
                new ShapeOrientation(Shape.Crown, Orientation.LeftFlip));

            var pathSet = MoveGenerator.GetPathSet(piece.Shapes);

            var result = TestEndSquares(pathSet,
                new Vector(0, -1),
                new Vector(-2, -1),
                new Vector(-1, 0),
                new Vector(-1, -2),
                new Vector(0, 0),
                new Vector(-2, 0),
                new Vector(-1, 1),
                new Vector(-1, -1),
                new Vector(0, 1),
                new Vector(-2, 1),
                new Vector(-1, 2),
                new Vector(-1, 0)
                );

            Assert.IsTrue(string.IsNullOrEmpty(result), result);
        }
    }
}
