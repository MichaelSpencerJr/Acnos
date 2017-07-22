using Acnos.GameLogic;
using Acnos.GameLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class RotationActions
    {
        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.Original, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.Flip, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.Right, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.RightFlip, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.UpsideDown, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.Left, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_TurnRight()
        {
            Assert.AreEqual(RotateAction.TurnRight, Piece.GetRotation(Orientation.LeftFlip, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.Original, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.Flip, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.Right, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.RightFlip, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.UpsideDown, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.Left, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_TurnLeft()
        {
            Assert.AreEqual(RotateAction.TurnLeft, Piece.GetRotation(Orientation.LeftFlip, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.Original, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.Flip, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.Right, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.RightFlip, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.UpsideDown, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.Left, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_TurnAround()
        {
            Assert.AreEqual(RotateAction.TurnAround, Piece.GetRotation(Orientation.LeftFlip, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.Original, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.Flip, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.Right, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.RightFlip, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.UpsideDown, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.Left, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_FlipHorizontal()
        {
            Assert.AreEqual(RotateAction.FlipHorizontal, Piece.GetRotation(Orientation.LeftFlip, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.Original, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.Flip, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.Right, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.RightFlip, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.UpsideDown, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.Left, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_FlipVertical()
        {
            Assert.AreEqual(RotateAction.FlipVertical, Piece.GetRotation(Orientation.LeftFlip, Orientation.Left));
        }





        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.Original, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.Flip, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.Right, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.RightFlip, Orientation.UpsideDown));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.UpsideDown, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.Left, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_FlipTopLeft()
        {
            Assert.AreEqual(RotateAction.FlipTopLeft, Piece.GetRotation(Orientation.LeftFlip, Orientation.Original));
        }





        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Original_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.Original, Orientation.RightFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Flip_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.Flip, Orientation.Right));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Right_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.Right, Orientation.Flip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void RightFlip_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.RightFlip, Orientation.Original));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDown_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.UpsideDown, Orientation.LeftFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void UpsideDownFlip_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.UpsideDownFlip, Orientation.Left));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void Left_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.Left, Orientation.UpsideDownFlip));
        }

        [TestCategory("GameLogic.RotationActions"), TestMethod]
        public void LeftFlip_FlipTopRight()
        {
            Assert.AreEqual(RotateAction.FlipTopRight, Piece.GetRotation(Orientation.LeftFlip, Orientation.UpsideDown));
        }

    }
}
