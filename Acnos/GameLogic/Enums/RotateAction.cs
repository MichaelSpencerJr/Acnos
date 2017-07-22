namespace Acnos.GameLogic.Enums
{
    /// <summary>
    /// Indicates a transforming action which either rotates or flips a piece
    /// </summary>
    public enum RotateAction
    {
        None,
        /// <summary> Turns a piece 90 degrees to the right, clockwise </summary>
        TurnRight,

        /// <summary> Turns a piece 180 degrees without flipping it </summary>
        TurnAround,

        /// <summary> Turns a piece 90 degrees to the left, anti-clockwise </summary>
        TurnLeft,

        /// <summary> Flips a piece horizontally, swapping the 
        /// left and right edges of the piece </summary>
        FlipHorizontal,

        /// <summary> Flips a piece around a diagonal from top right to bottom
        /// left, swapping the top/bottom edges with right/left edges</summary>
        FlipTopRight,

        /// <summary> Flips a piece vertically, swapping the
        /// top and bottom edges of the piece </summary>
        FlipVertical,

        /// <summary> Flips a piece around a diagonal from top left to bottom
        /// right, swapping the top/bottom edges with left/right edges</summary>
        FlipTopLeft,
    }
}
