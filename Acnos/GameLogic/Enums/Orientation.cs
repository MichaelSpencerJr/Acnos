namespace Acnos.GameLogic.Enums
{
    /// <summary>
    /// Set of eight possible orientations for a transparent piece which can be rotated in 90
    /// degree increments or flipped backwards.  Notation assumes the natural orientation of
    /// a piece contains the number 1 top, 2 right, 3 down, and 4 left.
    /// </summary>
    public enum Orientation
    {
        /// <summary> Original orientation: 1234 => 1234 </summary>
        Original,

        /// <summary> Flipped left-to-right: 1234 => 1432 </summary>
        Flip,

        /// <summary> Rotated 90 degrees to the right: 1234 => 4123 </summary>
        Right,

        /// <summary> Flipped left-to-right and then rotated 90 degrees to the right: 1234 => 2143 </summary>
        RightFlip,

        /// <summary> Rotated 180 degrees: 1234 => 3412 </summary>
        UpsideDown,

        /// <summary> Flipped left-to-right and then rotated 180 degrees: 1234 => 3214 </summary>
        UpsideDownFlip,

        /// <summary> Rotated 90 degrees to the left: 1234 => 2341 </summary>
        Left,

        /// <summary> Flipped left-to-right and then rotated 90 degrees to the left: 1234 => 4321 </summary>
        LeftFlip
    }
}
