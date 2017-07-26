using Acnos.GameLogic;
using Acnos.GameLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class Symmetry
    {
        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Test_Blades()
        {
            var t = TestSymmetry(new ShapeOrientationCollection(new[] { new ShapeOrientation(Shape.Ray, Orientation.Original), new ShapeOrientation(Shape.Ray, Orientation.Right) }, true));
            var uniqueHashSet = new HashSet<string>();
            var values = new Dictionary<int, List<string>>();
            foreach (var a in "AZRIBJVLTPYSDWNMCFXEKG")
                foreach (var b in " AZRIBJVLTPYSDWNMCFXEKG")
                    foreach (var c in " " /*" AZRIBJVLTPYSDWNMCFXEKG*/)
                        for (var o1 = Orientation.Original; o1 <= Orientation.LeftFlip; o1++)
                            for (var o2 = Orientation.Original; o2 <= Orientation.LeftFlip; o2++)
                            {
                                if (b == ' ' && o1 != Orientation.Original) continue;
                                if (c == ' ' && o2 != Orientation.Original) continue;
                                var so = new List<ShapeOrientation>
                                {
                                    new ShapeOrientation((Shape)a, Orientation.Original)
                                };
                                if (b != ' ')
                                    so.Add(new ShapeOrientation((Shape)b, o1));
                                if (c != ' ')
                                    so.Add(new ShapeOrientation((Shape)c, o2));
                                var soc = new ShapeOrientationCollection(so, true);
                                if (!uniqueHashSet.Add(soc.ToString())) continue;
                    var idx = TestSymmetry(soc);
                    if (!values.ContainsKey(idx))
                        values[idx] = new List<string>();
                    values[idx].Add(soc.ToString());
                }
            Assert.AreEqual(1, values.Count);
        }

        public int TestSymmetry(ShapeOrientationCollection col)
        {
            var rawUniques = RotationGenerator.GetUniqueOrientations(col).ToArray();
            Orientation[] uniques = EliminateDupes(rawUniques);
            var retval = 0;
            foreach (var orientation in uniques)
                retval |= (1 << (int)orientation);
            return retval;
        }

        private Orientation[] EliminateDupes(Orientation[] rawUniques)
        {
            if (rawUniques.Length == 1 || rawUniques.Length == 8) return rawUniques;
            var done = false;
            var retval = new List<Orientation>(rawUniques);
            //while (!done)
            {
                done = true;
                var eliminated = new List<Orientation>();
                for (var o = Orientation.Flip; o <= Orientation.LeftFlip; o++)
                    if (!retval.Contains(o))
                        eliminated.Add(o);
                var elimRotations = new List<RotateAction>();
                foreach (var o in eliminated)
                    elimRotations.Add(Piece.GetRotation(Orientation.Original, o));
                foreach (var o in new[] { Orientation.UpsideDown, Orientation.Right, Orientation.Left, Orientation.Flip, Orientation.UpsideDownFlip, Orientation.RightFlip, Orientation.LeftFlip })
                {
                    if (!retval.Contains(o)) continue;
                    foreach (var r in elimRotations)
                    {
                        var target = Piece.RotateOrientation(o, r);
                        if (target == Orientation.Original) continue;
                        if (retval.Contains(target))
                        {
                            retval.Remove(target);
                        }
                    }
                }
            }
            return retval.ToArray();
        }

        public int TestSinglePiece(Shape shape, Orientation orientation = Orientation.Original)
        {
            return TestSymmetry(new ShapeOrientationCollection(new[] { new ShapeOrientation(shape, orientation) }, false));
        }
    }
}
