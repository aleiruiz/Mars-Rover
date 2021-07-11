using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge1.Helpers
{
    public class FilterEnum
    {
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
