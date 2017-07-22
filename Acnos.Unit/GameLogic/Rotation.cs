using Acnos.GameLogic;
using Acnos.GameLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class Rotation
    {
        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_TurnRight()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.Original, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_TurnRight()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.Flip, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_TurnRight()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.Right, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_TurnRight()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_TurnRight()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_TurnRight()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_TurnRight()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.Left, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_TurnRight()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.TurnRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_TurnLeft()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.Original, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_TurnLeft()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.Flip, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_TurnLeft()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.Right, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_TurnLeft()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_TurnLeft()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_TurnLeft()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_TurnLeft()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.Left, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_TurnLeft()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.TurnLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_TurnAround()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.Original, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_TurnAround()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.Flip, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_TurnAround()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.Right, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_TurnAround()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_TurnAround()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_TurnAround()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_TurnAround()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.Left, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_TurnAround()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.TurnAround));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.Original, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.Flip, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.Right, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.Left, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_FlipHorizontal()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.FlipHorizontal));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_FlipVertical()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.Original, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_FlipVertical()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.Flip, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_FlipVertical()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.Right, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_FlipVertical()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_FlipVertical()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_FlipVertical()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_FlipVertical()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.Left, RotateAction.FlipVertical));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_FlipVertical()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.FlipVertical));
        }





        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.Original, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.Flip, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.Right, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.Left, RotateAction.FlipTopLeft));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_FlipTopLeft()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.FlipTopLeft));
        }





        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Original_FlipTopRight()
        {
            Assert.AreEqual(Orientation.RightFlip, Piece.RotateOrientation(Orientation.Original, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Flip_FlipTopRight()
        {
            Assert.AreEqual(Orientation.Right, Piece.RotateOrientation(Orientation.Flip, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Right_FlipTopRight()
        {
            Assert.AreEqual(Orientation.Flip, Piece.RotateOrientation(Orientation.Right, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void RightFlip_FlipTopRight()
        {
            Assert.AreEqual(Orientation.Original, Piece.RotateOrientation(Orientation.RightFlip, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDown_FlipTopRight()
        {
            Assert.AreEqual(Orientation.LeftFlip, Piece.RotateOrientation(Orientation.UpsideDown, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void UpsideDownFlip_FlipTopRight()
        {
            Assert.AreEqual(Orientation.Left, Piece.RotateOrientation(Orientation.UpsideDownFlip, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void Left_FlipTopRight()
        {
            Assert.AreEqual(Orientation.UpsideDownFlip, Piece.RotateOrientation(Orientation.Left, RotateAction.FlipTopRight));
        }

        [TestCategory("GameLogic.Rotation"), TestMethod]
        public void LeftFlip_FlipTopRight()
        {
            Assert.AreEqual(Orientation.UpsideDown, Piece.RotateOrientation(Orientation.LeftFlip, RotateAction.FlipTopRight));
        }

    }
}