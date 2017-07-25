using Acnos.GameLogic;
using Acnos.GameLogic.Actions;
using Acnos.GameLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acnos.Unit.GameLogic
{
    [TestClass]
    public class DeepClone
    {
        [TestCategory("DeepClone"), TestMethod]
        public void TestActionPlayer1PlaceArmy()
        {
            var original = new Player1PlaceArmy(
                new ShapeOrientation(Shape.Blades, Orientation.LeftFlip),
                new ShapeOrientation(Shape.Corn, Orientation.Flip),
                new ShapeOrientation(Shape.Crown, Orientation.Left),
                new ShapeOrientation(Shape.Mark, Orientation.Original),
                new ShapeOrientation(Shape.Ramp, Orientation.Right),
                new ShapeOrientation(Shape.Talon, Orientation.RightFlip),
                new ShapeOrientation(Shape.Tower, Orientation.UpsideDown),
                new ShapeOrientation(Shape.Tulip, Orientation.UpsideDownFlip)
                );

            Assert.AreEqual(Shape.Crown, original.FrontRight.Shape);
            Assert.AreEqual(Orientation.Left, original.FrontRight.Orientation);

            var clone = original.DeepClone() as Player1PlaceArmy;

            Assert.IsNotNull(clone);
            Assert.AreEqual(Shape.Crown, clone.FrontRight.Shape);
            Assert.AreEqual(Orientation.Left, clone.FrontRight.Orientation);

            original.FrontRight = new ShapeOrientation(Shape.Diamond, Orientation.UpsideDownFlip);


            Assert.AreEqual(Shape.Diamond, original.FrontRight.Shape);
            Assert.AreEqual(Orientation.UpsideDownFlip, original.FrontRight.Orientation);

            Assert.AreEqual(Shape.Crown, clone.FrontRight.Shape);
            Assert.AreEqual(Orientation.Left, clone.FrontRight.Orientation);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestActionPlayer1Treasure()
        {
            var original = new Player1Treasure(BoardLocation.D2);

            Assert.AreEqual(BoardLocation.D2, original.TreasureLocation);

            var clone = original.DeepClone() as Player1Treasure;

            Assert.IsNotNull(clone);
            Assert.AreEqual(BoardLocation.D2, clone.TreasureLocation);

            original.TreasureLocation = BoardLocation.B2;

            Assert.AreEqual(BoardLocation.B2, original.TreasureLocation);
            Assert.AreEqual(BoardLocation.D2, clone.TreasureLocation);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestActionPlayer2Treasure()
        {
            var original = new Player2Treasure(BoardLocation.D7);

            Assert.AreEqual(BoardLocation.D7, original.TreasureLocation);

            var clone = original.DeepClone() as Player2Treasure;

            Assert.IsNotNull(clone);
            Assert.AreEqual(BoardLocation.D7, clone.TreasureLocation);

            original.TreasureLocation = BoardLocation.B7;

            Assert.AreEqual(BoardLocation.B7, original.TreasureLocation);
            Assert.AreEqual(BoardLocation.D7, clone.TreasureLocation);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestBoardSquare()
        {
            var original = new BoardSquare(BoardLocation.C3, new Piece(Side.Player2, 2, new ShapeOrientationCollection(new[] { new ShapeOrientation(Shape.Blades, Orientation.Original) }, false)));

            Assert.AreEqual(BoardLocation.C3, original.Position);
            Assert.AreEqual(BoardSquareContents.Piece, original.Contents);
            Assert.AreEqual(Side.Player2, original.Piece.Owner);
            Assert.AreEqual(2, original.Piece.StackLimit);
            Assert.AreEqual(1, original.Piece.Shapes.Count);
            Assert.AreEqual(Shape.Blades, original.Piece.Shapes[0].Shape);
            Assert.AreEqual(Orientation.Original, original.Piece.Shapes[0].Orientation);

            var clone = original.DeepClone();

            Assert.IsNotNull(clone);
            Assert.AreEqual(BoardLocation.C3, clone.Position);
            Assert.AreEqual(BoardSquareContents.Piece, clone.Contents);
            Assert.AreEqual(Side.Player2, clone.Piece.Owner);
            Assert.AreEqual(2, clone.Piece.StackLimit);
            Assert.AreEqual(1, clone.Piece.Shapes.Count);
            Assert.AreEqual(Shape.Blades, clone.Piece.Shapes[0].Shape);
            Assert.AreEqual(Orientation.Original, clone.Piece.Shapes[0].Orientation);

            original.Position = BoardLocation.B3;
            Assert.AreEqual(BoardLocation.B3, original.Position);
            Assert.AreEqual(BoardLocation.C3, clone.Position);

            original.Contents = BoardSquareContents.Blockade;
            Assert.AreEqual(BoardSquareContents.Blockade, original.Contents);
            Assert.IsNull(original.Piece);
            Assert.AreEqual(BoardSquareContents.Piece, clone.Contents);
            Assert.AreEqual(Side.Player2, clone.Piece.Owner);
            Assert.AreEqual(2, clone.Piece.StackLimit);
            Assert.AreEqual(1, clone.Piece.Shapes.Count);
            Assert.AreEqual(Shape.Blades, clone.Piece.Shapes[0].Shape);
            Assert.AreEqual(Orientation.Original, clone.Piece.Shapes[0].Orientation);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestGameAction()
        {
            var originalBoard = new GameBoard();
            ActionType originalAction = new Setup();
            var original = new GameAction(GamePhase.None, originalBoard, originalAction);

            Assert.AreEqual(GamePhase.None, original.State);
            Assert.AreSame(originalBoard, original.Board);
            Assert.AreSame(originalAction, original.Action);

            var clone = original.DeepClone();

            Assert.AreEqual(GamePhase.None, clone.State);
            Assert.AreNotSame(originalBoard, clone.Board);
            Assert.AreNotSame(originalAction, clone.Action);

            original.State = GamePhase.Player1PreSetup;

            Assert.AreEqual(GamePhase.Player1PreSetup, original.State);
            Assert.AreEqual(GamePhase.None, clone.State);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestGameBoard()
        {
            GameBoard original;
            GamePhase newPhase;
            Assert.IsTrue(new Setup().PerformAction(GamePhase.None, new GameBoard(), out newPhase, out original));

            Assert.AreEqual(64, original.Squares.Count);
            Assert.AreEqual(BoardSquareContents.Empty, original.Squares[BoardLocation.A1].Contents);

            var originalA1 = original.Squares[BoardLocation.A1];
            var originalC3 = original.Squares[BoardLocation.C3];

            original.Squares[BoardLocation.A1].Piece = new Piece(Side.Player1, 2,
                new ShapeOrientationCollection(new[] { new ShapeOrientation(Shape.Blades, Orientation.Flip) }, false));

            Assert.AreEqual(BoardSquareContents.Piece, originalA1.Contents);
            Assert.AreEqual(Side.Player1, originalA1.Piece.Owner);

            var clone = original.DeepClone();

            Assert.AreNotSame(originalA1, clone.Squares[BoardLocation.A1]);
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestMovementPath()
        {
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestPathSet()
        {
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestPiece()
        {
        }

        [TestCategory("DeepClone"), TestMethod]
        public void TestShapeOrientationCollection()
        {
        }

    }
}
