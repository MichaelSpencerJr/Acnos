namespace Acnos.GameLogic.Enums
{
    /// <summary>
    /// Set of shape names, stored internally as single characters
    /// </summary>
    public enum Shape : ushort
    {
        /// <summary>No piece present</summary>
        None = '\0',
        /// <summary>1 arrow, Up-Right</summary>
        Ray = 'A',
        /// <summary>2 arrows, Up + Up-Right</summary>
        Blades = 'B',
        /// <summary>3 arrows, Up + Down-Right + Up-Left</summary>
        Claw = 'C',
        /// <summary>3 arrows, Up + Down-Right + Left</summary>
        Dancer = 'D',
        /// <summary>4 arrows, Up + Up-Right + Down + Up-Left</summary>
        Eagle = 'E',
        /// <summary>3 arrows, Up + Up-Right + Down-Right</summary>
        Finch = 'F',
        /// <summary>4 arrows, Up + Right + Down + Left</summary>
        Cross = 'G',
        /// <summary>2 arrows, Right + Left</summary>
        Diamond = 'I',
        /// <summary>2 arrows, Up + Down-Right</summary>
        Boomerang = 'J',
        /// <summary>4 arrows, Up-Right + Right + Left + Up-Left</summary>
        Hedgehog = 'K',
        /// <summary>2 arrows, Up + Left</summary>
        Corner = 'L',
        /// <summary>3 arrows, Up + Left + Up-Left</summary>
        Talon = 'M',
        /// <summary>3 arrows, Up + Up-Right + Down</summary>
        Corn = 'N',
        /// <summary>Goal piece, no arrows</summary>
        Treasure = 'O',
        /// <summary>3 arrows, Up + Right + Up-Left</summary>
        Tulip = 'P',
        /// <summary>2 arrows, Up-Right + Down-Left</summary>
        Ramp = 'R',
        /// <summary>3 arrows, Up-Right + Down-Left + Up-Left</summary>
        Sickle = 'S',
        /// <summary>3 arrows, Up + Right + Left</summary>
        Hat = 'T',
        /// <summary>2 arrows, Up-Right + Up-Left</summary>
        Peak = 'V',
        /// <summary>3 arrows, Up + Up-Right + Up-Left</summary>
        Crown = 'W',
        /// <summary>4 arrows, Up-Right + Down-Right + Down-Left + Up-Left</summary>
        Mark = 'X',
        /// <summary>3 arrows, Up + Down-Right + Down-Left</summary>
        Tower = 'Y',
        /// <summary>1 arrow, Left</summary>
        Tear = 'Z',
    }
}
