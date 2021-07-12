using System;

namespace Challenge1.Helpers
{
    public class FilterEnum
    {
        /// <summary>
        /// Returns Enum with the Cardinal Direction Enum filtered by a string
        /// </summary>
        /// <param name="cardinalDirection">String to filter the Enum</param>
        /// <returns>Enum Object</returns>
        public static CardinalDirection GetCardinalDirectionFromString(string cardinalDirection)
        {

            switch(cardinalDirection)
            {
                case "N":
                    return CardinalDirection.North;
                case "S":
                    return CardinalDirection.South;
                case "W":
                    return CardinalDirection.West;
                case "E":
                    return CardinalDirection.East;
                default:
                    throw new Exception("Invalid cardinal direction, received " + cardinalDirection);

            }
        }
    }
}
