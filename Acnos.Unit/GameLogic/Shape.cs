using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acnos.GameLogic;
using Acnos.GameLogic.Enums;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class ShapeTests
    {
        private void TestSimpleShape(Shape shape, string movements)
        {
            Assert.AreEqual(movements, Vector.DistinctVectorsToString(Piece.GetNonOrientedVectors(shape)));
            Assert.AreEqual(movements, new ShapeOrientationCollection(new[] { new ShapeOrientation(shape, Orientation.Original) }, true).ToString().Substring(2));
        }

        private void TestOrientedShape(Shape shape, Orientation orientation, string movements)
        {
            Assert.AreEqual(movements, Vector.DistinctVectorsToString(Piece.OrientVectors(Piece.GetNonOrientedVectors(shape), orientation)));
            Assert.AreEqual(movements, new ShapeOrientationCollection(new[] { new ShapeOrientation(shape, orientation) }, true).ToString().Substring(2));
        }

        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_None()
        {
            TestSimpleShape(Shape.None, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Ray()
        {
            TestSimpleShape(Shape.Ray, "2");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Blades()
        {
            TestSimpleShape(Shape.Blades, "12");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Claw()
        {
            TestSimpleShape(Shape.Claw, "148");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Dancer()
        {
            TestSimpleShape(Shape.Dancer, "147");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Eagle()
        {
            TestSimpleShape(Shape.Eagle, "1258");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Finch()
        {
            TestSimpleShape(Shape.Finch, "124");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Cross()
        {
            TestSimpleShape(Shape.Cross, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Diamond()
        {
            TestSimpleShape(Shape.Diamond, "37");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Boomerang()
        {
            TestSimpleShape(Shape.Boomerang, "14");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Hedgehog()
        {
            TestSimpleShape(Shape.Hedgehog, "2378");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Corner()
        {
            TestSimpleShape(Shape.Corner, "17");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Talon()
        {
            TestSimpleShape(Shape.Talon, "178");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Corn()
        {
            TestSimpleShape(Shape.Corn, "125");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Treasure()
        {
            TestSimpleShape(Shape.Treasure, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Tulip()
        {
            TestSimpleShape(Shape.Tulip, "138");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Ramp()
        {
            TestSimpleShape(Shape.Ramp, "26");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Sickle()
        {
            TestSimpleShape(Shape.Sickle, "268");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Hat()
        {
            TestSimpleShape(Shape.Hat, "137");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Peak()
        {
            TestSimpleShape(Shape.Peak, "28");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Crown()
        {
            TestSimpleShape(Shape.Crown, "128");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Mark()
        {
            TestSimpleShape(Shape.Mark, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Tower()
        {
            TestSimpleShape(Shape.Tower, "146");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Define_Tear()
        {
            TestSimpleShape(Shape.Tear, "1");
        }

        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_Original()
        {
            TestOrientedShape(Shape.Ray, Orientation.Original, "2");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_Original()
        {
            TestOrientedShape(Shape.Blades, Orientation.Original, "12");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_Original()
        {
            TestOrientedShape(Shape.Claw, Orientation.Original, "148");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_Original()
        {
            TestOrientedShape(Shape.Dancer, Orientation.Original, "147");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_Original()
        {
            TestOrientedShape(Shape.Eagle, Orientation.Original, "1258");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_Original()
        {
            TestOrientedShape(Shape.Finch, Orientation.Original, "124");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_Original()
        {
            TestOrientedShape(Shape.Cross, Orientation.Original, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_Original()
        {
            TestOrientedShape(Shape.Diamond, Orientation.Original, "37");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_Original()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.Original, "14");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_Original()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.Original, "2378");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_Original()
        {
            TestOrientedShape(Shape.Corner, Orientation.Original, "17");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_Original()
        {
            TestOrientedShape(Shape.Talon, Orientation.Original, "178");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_Original()
        {
            TestOrientedShape(Shape.Corn, Orientation.Original, "125");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_Original()
        {
            TestOrientedShape(Shape.Treasure, Orientation.Original, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_Original()
        {
            TestOrientedShape(Shape.Tulip, Orientation.Original, "138");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_Original()
        {
            TestOrientedShape(Shape.Ramp, Orientation.Original, "26");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_Original()
        {
            TestOrientedShape(Shape.Sickle, Orientation.Original, "268");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_Original()
        {
            TestOrientedShape(Shape.Hat, Orientation.Original, "137");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_Original()
        {
            TestOrientedShape(Shape.Peak, Orientation.Original, "28");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_Original()
        {
            TestOrientedShape(Shape.Crown, Orientation.Original, "128");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_Original()
        {
            TestOrientedShape(Shape.Mark, Orientation.Original, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_Original()
        {
            TestOrientedShape(Shape.Tower, Orientation.Original, "146");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_Original()
        {
            TestOrientedShape(Shape.Tear, Orientation.Original, "1");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_Flip()
        {
            TestOrientedShape(Shape.Ray, Orientation.Flip, "8");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_Flip()
        {
            TestOrientedShape(Shape.Blades, Orientation.Flip, "18");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_Flip()
        {
            TestOrientedShape(Shape.Claw, Orientation.Flip, "126");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_Flip()
        {
            TestOrientedShape(Shape.Dancer, Orientation.Flip, "136");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_Flip()
        {
            TestOrientedShape(Shape.Eagle, Orientation.Flip, "1258");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_Flip()
        {
            TestOrientedShape(Shape.Finch, Orientation.Flip, "168");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_Flip()
        {
            TestOrientedShape(Shape.Cross, Orientation.Flip, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_Flip()
        {
            TestOrientedShape(Shape.Diamond, Orientation.Flip, "37");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_Flip()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.Flip, "16");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_Flip()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.Flip, "2378");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_Flip()
        {
            TestOrientedShape(Shape.Corner, Orientation.Flip, "13");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_Flip()
        {
            TestOrientedShape(Shape.Talon, Orientation.Flip, "123");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_Flip()
        {
            TestOrientedShape(Shape.Corn, Orientation.Flip, "158");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_Flip()
        {
            TestOrientedShape(Shape.Treasure, Orientation.Flip, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_Flip()
        {
            TestOrientedShape(Shape.Tulip, Orientation.Flip, "127");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_Flip()
        {
            TestOrientedShape(Shape.Ramp, Orientation.Flip, "48");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_Flip()
        {
            TestOrientedShape(Shape.Sickle, Orientation.Flip, "248");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_Flip()
        {
            TestOrientedShape(Shape.Hat, Orientation.Flip, "137");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_Flip()
        {
            TestOrientedShape(Shape.Peak, Orientation.Flip, "28");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_Flip()
        {
            TestOrientedShape(Shape.Crown, Orientation.Flip, "128");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_Flip()
        {
            TestOrientedShape(Shape.Mark, Orientation.Flip, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_Flip()
        {
            TestOrientedShape(Shape.Tower, Orientation.Flip, "146");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_Flip()
        {
            TestOrientedShape(Shape.Tear, Orientation.Flip, "1");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_Right()
        {
            TestOrientedShape(Shape.Ray, Orientation.Right, "8");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_Right()
        {
            TestOrientedShape(Shape.Blades, Orientation.Right, "78");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_Right()
        {
            TestOrientedShape(Shape.Claw, Orientation.Right, "267");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_Right()
        {
            TestOrientedShape(Shape.Dancer, Orientation.Right, "257");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_Right()
        {
            TestOrientedShape(Shape.Eagle, Orientation.Right, "3678");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_Right()
        {
            TestOrientedShape(Shape.Finch, Orientation.Right, "278");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_Right()
        {
            TestOrientedShape(Shape.Cross, Orientation.Right, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_Right()
        {
            TestOrientedShape(Shape.Diamond, Orientation.Right, "15");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_Right()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.Right, "27");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_Right()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.Right, "1568");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_Right()
        {
            TestOrientedShape(Shape.Corner, Orientation.Right, "57");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_Right()
        {
            TestOrientedShape(Shape.Talon, Orientation.Right, "567");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_Right()
        {
            TestOrientedShape(Shape.Corn, Orientation.Right, "378");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_Right()
        {
            TestOrientedShape(Shape.Treasure, Orientation.Right, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_Right()
        {
            TestOrientedShape(Shape.Tulip, Orientation.Right, "167");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_Right()
        {
            TestOrientedShape(Shape.Ramp, Orientation.Right, "48");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_Right()
        {
            TestOrientedShape(Shape.Sickle, Orientation.Right, "468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_Right()
        {
            TestOrientedShape(Shape.Hat, Orientation.Right, "157");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_Right()
        {
            TestOrientedShape(Shape.Peak, Orientation.Right, "68");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_Right()
        {
            TestOrientedShape(Shape.Crown, Orientation.Right, "678");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_Right()
        {
            TestOrientedShape(Shape.Mark, Orientation.Right, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_Right()
        {
            TestOrientedShape(Shape.Tower, Orientation.Right, "247");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_Right()
        {
            TestOrientedShape(Shape.Tear, Orientation.Right, "7");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_RightFlip()
        {
            TestOrientedShape(Shape.Ray, Orientation.RightFlip, "2");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_RightFlip()
        {
            TestOrientedShape(Shape.Blades, Orientation.RightFlip, "23");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_RightFlip()
        {
            TestOrientedShape(Shape.Claw, Orientation.RightFlip, "348");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_RightFlip()
        {
            TestOrientedShape(Shape.Dancer, Orientation.RightFlip, "358");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_RightFlip()
        {
            TestOrientedShape(Shape.Eagle, Orientation.RightFlip, "2347");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_RightFlip()
        {
            TestOrientedShape(Shape.Finch, Orientation.RightFlip, "238");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_RightFlip()
        {
            TestOrientedShape(Shape.Cross, Orientation.RightFlip, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_RightFlip()
        {
            TestOrientedShape(Shape.Diamond, Orientation.RightFlip, "15");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_RightFlip()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.RightFlip, "38");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_RightFlip()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.RightFlip, "1245");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_RightFlip()
        {
            TestOrientedShape(Shape.Corner, Orientation.RightFlip, "35");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_RightFlip()
        {
            TestOrientedShape(Shape.Talon, Orientation.RightFlip, "345");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_RightFlip()
        {
            TestOrientedShape(Shape.Corn, Orientation.RightFlip, "237");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_RightFlip()
        {
            TestOrientedShape(Shape.Treasure, Orientation.RightFlip, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_RightFlip()
        {
            TestOrientedShape(Shape.Tulip, Orientation.RightFlip, "134");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_RightFlip()
        {
            TestOrientedShape(Shape.Ramp, Orientation.RightFlip, "26");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_RightFlip()
        {
            TestOrientedShape(Shape.Sickle, Orientation.RightFlip, "246");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_RightFlip()
        {
            TestOrientedShape(Shape.Hat, Orientation.RightFlip, "135");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_RightFlip()
        {
            TestOrientedShape(Shape.Peak, Orientation.RightFlip, "24");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_RightFlip()
        {
            TestOrientedShape(Shape.Crown, Orientation.RightFlip, "234");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_RightFlip()
        {
            TestOrientedShape(Shape.Mark, Orientation.RightFlip, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_RightFlip()
        {
            TestOrientedShape(Shape.Tower, Orientation.RightFlip, "368");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_RightFlip()
        {
            TestOrientedShape(Shape.Tear, Orientation.RightFlip, "3");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_UpsideDown()
        {
            TestOrientedShape(Shape.Ray, Orientation.UpsideDown, "6");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_UpsideDown()
        {
            TestOrientedShape(Shape.Blades, Orientation.UpsideDown, "56");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_UpsideDown()
        {
            TestOrientedShape(Shape.Claw, Orientation.UpsideDown, "458");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_UpsideDown()
        {
            TestOrientedShape(Shape.Dancer, Orientation.UpsideDown, "358");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_UpsideDown()
        {
            TestOrientedShape(Shape.Eagle, Orientation.UpsideDown, "1456");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_UpsideDown()
        {
            TestOrientedShape(Shape.Finch, Orientation.UpsideDown, "568");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_UpsideDown()
        {
            TestOrientedShape(Shape.Cross, Orientation.UpsideDown, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_UpsideDown()
        {
            TestOrientedShape(Shape.Diamond, Orientation.UpsideDown, "37");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_UpsideDown()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.UpsideDown, "58");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_UpsideDown()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.UpsideDown, "3467");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_UpsideDown()
        {
            TestOrientedShape(Shape.Corner, Orientation.UpsideDown, "35");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_UpsideDown()
        {
            TestOrientedShape(Shape.Talon, Orientation.UpsideDown, "345");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_UpsideDown()
        {
            TestOrientedShape(Shape.Corn, Orientation.UpsideDown, "156");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_UpsideDown()
        {
            TestOrientedShape(Shape.Treasure, Orientation.UpsideDown, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_UpsideDown()
        {
            TestOrientedShape(Shape.Tulip, Orientation.UpsideDown, "457");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_UpsideDown()
        {
            TestOrientedShape(Shape.Ramp, Orientation.UpsideDown, "26");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_UpsideDown()
        {
            TestOrientedShape(Shape.Sickle, Orientation.UpsideDown, "246");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_UpsideDown()
        {
            TestOrientedShape(Shape.Hat, Orientation.UpsideDown, "357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_UpsideDown()
        {
            TestOrientedShape(Shape.Peak, Orientation.UpsideDown, "46");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_UpsideDown()
        {
            TestOrientedShape(Shape.Crown, Orientation.UpsideDown, "456");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_UpsideDown()
        {
            TestOrientedShape(Shape.Mark, Orientation.UpsideDown, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_UpsideDown()
        {
            TestOrientedShape(Shape.Tower, Orientation.UpsideDown, "258");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_UpsideDown()
        {
            TestOrientedShape(Shape.Tear, Orientation.UpsideDown, "5");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Ray, Orientation.UpsideDownFlip, "4");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Blades, Orientation.UpsideDownFlip, "45");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Claw, Orientation.UpsideDownFlip, "256");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Dancer, Orientation.UpsideDownFlip, "257");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Eagle, Orientation.UpsideDownFlip, "1456");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Finch, Orientation.UpsideDownFlip, "245");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Cross, Orientation.UpsideDownFlip, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Diamond, Orientation.UpsideDownFlip, "37");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.UpsideDownFlip, "25");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.UpsideDownFlip, "3467");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Corner, Orientation.UpsideDownFlip, "57");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Talon, Orientation.UpsideDownFlip, "567");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Corn, Orientation.UpsideDownFlip, "145");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Treasure, Orientation.UpsideDownFlip, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Tulip, Orientation.UpsideDownFlip, "356");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Ramp, Orientation.UpsideDownFlip, "48");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Sickle, Orientation.UpsideDownFlip, "468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Hat, Orientation.UpsideDownFlip, "357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Peak, Orientation.UpsideDownFlip, "46");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Crown, Orientation.UpsideDownFlip, "456");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Mark, Orientation.UpsideDownFlip, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Tower, Orientation.UpsideDownFlip, "258");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_UpsideDownFlip()
        {
            TestOrientedShape(Shape.Tear, Orientation.UpsideDownFlip, "5");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_Left()
        {
            TestOrientedShape(Shape.Ray, Orientation.Left, "4");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_Left()
        {
            TestOrientedShape(Shape.Blades, Orientation.Left, "34");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_Left()
        {
            TestOrientedShape(Shape.Claw, Orientation.Left, "236");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_Left()
        {
            TestOrientedShape(Shape.Dancer, Orientation.Left, "136");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_Left()
        {
            TestOrientedShape(Shape.Eagle, Orientation.Left, "2347");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_Left()
        {
            TestOrientedShape(Shape.Finch, Orientation.Left, "346");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_Left()
        {
            TestOrientedShape(Shape.Cross, Orientation.Left, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_Left()
        {
            TestOrientedShape(Shape.Diamond, Orientation.Left, "15");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_Left()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.Left, "36");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_Left()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.Left, "1245");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_Left()
        {
            TestOrientedShape(Shape.Corner, Orientation.Left, "13");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_Left()
        {
            TestOrientedShape(Shape.Talon, Orientation.Left, "123");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_Left()
        {
            TestOrientedShape(Shape.Corn, Orientation.Left, "347");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_Left()
        {
            TestOrientedShape(Shape.Treasure, Orientation.Left, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_Left()
        {
            TestOrientedShape(Shape.Tulip, Orientation.Left, "235");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_Left()
        {
            TestOrientedShape(Shape.Ramp, Orientation.Left, "48");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_Left()
        {
            TestOrientedShape(Shape.Sickle, Orientation.Left, "248");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_Left()
        {
            TestOrientedShape(Shape.Hat, Orientation.Left, "135");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_Left()
        {
            TestOrientedShape(Shape.Peak, Orientation.Left, "24");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_Left()
        {
            TestOrientedShape(Shape.Crown, Orientation.Left, "234");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_Left()
        {
            TestOrientedShape(Shape.Mark, Orientation.Left, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_Left()
        {
            TestOrientedShape(Shape.Tower, Orientation.Left, "368");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_Left()
        {
            TestOrientedShape(Shape.Tear, Orientation.Left, "3");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ray_LeftFlip()
        {
            TestOrientedShape(Shape.Ray, Orientation.LeftFlip, "6");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Blades_LeftFlip()
        {
            TestOrientedShape(Shape.Blades, Orientation.LeftFlip, "67");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Claw_LeftFlip()
        {
            TestOrientedShape(Shape.Claw, Orientation.LeftFlip, "478");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Dancer_LeftFlip()
        {
            TestOrientedShape(Shape.Dancer, Orientation.LeftFlip, "147");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Eagle_LeftFlip()
        {
            TestOrientedShape(Shape.Eagle, Orientation.LeftFlip, "3678");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Finch_LeftFlip()
        {
            TestOrientedShape(Shape.Finch, Orientation.LeftFlip, "467");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Cross_LeftFlip()
        {
            TestOrientedShape(Shape.Cross, Orientation.LeftFlip, "1357");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Diamond_LeftFlip()
        {
            TestOrientedShape(Shape.Diamond, Orientation.LeftFlip, "15");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Boomerang_LeftFlip()
        {
            TestOrientedShape(Shape.Boomerang, Orientation.LeftFlip, "47");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hedgehog_LeftFlip()
        {
            TestOrientedShape(Shape.Hedgehog, Orientation.LeftFlip, "1568");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corner_LeftFlip()
        {
            TestOrientedShape(Shape.Corner, Orientation.LeftFlip, "17");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Talon_LeftFlip()
        {
            TestOrientedShape(Shape.Talon, Orientation.LeftFlip, "178");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Corn_LeftFlip()
        {
            TestOrientedShape(Shape.Corn, Orientation.LeftFlip, "367");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Treasure_LeftFlip()
        {
            TestOrientedShape(Shape.Treasure, Orientation.LeftFlip, "");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tulip_LeftFlip()
        {
            TestOrientedShape(Shape.Tulip, Orientation.LeftFlip, "578");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Ramp_LeftFlip()
        {
            TestOrientedShape(Shape.Ramp, Orientation.LeftFlip, "26");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Sickle_LeftFlip()
        {
            TestOrientedShape(Shape.Sickle, Orientation.LeftFlip, "268");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Hat_LeftFlip()
        {
            TestOrientedShape(Shape.Hat, Orientation.LeftFlip, "157");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Peak_LeftFlip()
        {
            TestOrientedShape(Shape.Peak, Orientation.LeftFlip, "68");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Crown_LeftFlip()
        {
            TestOrientedShape(Shape.Crown, Orientation.LeftFlip, "678");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Mark_LeftFlip()
        {
            TestOrientedShape(Shape.Mark, Orientation.LeftFlip, "2468");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tower_LeftFlip()
        {
            TestOrientedShape(Shape.Tower, Orientation.LeftFlip, "247");
        }


        [TestCategory("GameLogic.ShapeTests"), TestMethod]
        public void Orient_Tear_LeftFlip()
        {
            TestOrientedShape(Shape.Tear, Orientation.LeftFlip, "7");
        }

    }
}
