using System;

namespace Challenge1.Models
{
    public class Rover
    {
        /// <summary>
        /// X Axis position
        /// </summary>
        private int xPosition { get; set; }

        /// <summary>
        /// Y Axis position
        /// </summary>
        private int yPosition { get; set; }

        /// <summary>
        /// Plateu object
        /// </summary>
        private Plateau plateau { get; set; }

        private CardinalDirection cardinalDirection { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plateau">The target plateau</param>
        /// <param name="xPosition">The x position inside the plateau's cardinal map</param>
        /// <param name="yPosition">The y position inside the plateau's cardinal map</param>
        public Rover(Plateau plateau, int xPosition, int yPosition, CardinalDirection cardinalDirection)
        {
            this.plateau = plateau;
            this.xPosition = xPosition; 
            this.yPosition = yPosition;
            this.cardinalDirection = cardinalDirection;
        }

        /// <summary>
        /// Return Current Position
        /// </summary>
        /// <returns>Formated string with x y and facin positions</returns>
        public string ReturnCurrentPosition()
        {
            return String.Format("{0}{1}{2}", this.xPosition, this.yPosition, cardinalDirection.ToString().ToCharArray()[0]);
        }

        /// <summary>
        /// Turn facing position
        /// </summary>
        /// <param name="side">Side to be turned to</param>
        public void TurnFacingPosition(string side)
        {
            switch (this.cardinalDirection)
            {
                case CardinalDirection.North:
                    this.cardinalDirection = side == "L" ? CardinalDirection.West : CardinalDirection.East;
                    break;
                case CardinalDirection.South:
                    this.cardinalDirection = side == "L" ? CardinalDirection.East : CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    this.cardinalDirection = side == "L" ? CardinalDirection.North : CardinalDirection.South;
                    break;
                case CardinalDirection.West:
                    this.cardinalDirection = side == "L" ? CardinalDirection.South : CardinalDirection.North;
                    break;
            }
        }
       
        /// <summary>
        /// Move towards facing position
        /// </summary>
        public void Move()
        {
            switch (this.cardinalDirection)
            {
                case CardinalDirection.North:
                    ValidateNextPosition("Y", Actions.Add);
                    this.yPosition++;
                    break;
                case CardinalDirection.South:
                    ValidateNextPosition("Y", Actions.Substract);
                    this.yPosition--;
                    break;
                case CardinalDirection.East:
                    ValidateNextPosition("X", Actions.Add);
                    this.xPosition++;
                    break;
                case CardinalDirection.West:
                    ValidateNextPosition("X", Actions.Substract);
                    this.xPosition--;
                    break;
            }
        }
        
        /// <summary>
        /// Validate if next move is possible
        /// </summary>
        /// <param name="axis">Target Axis</param>
        /// <param name="action">Action to be Performed</param>
        /// <returns>Boolean value that determines if a move action can be done.</returns>
        public bool ValidateNextPosition(string axis, Actions action)
        {
            if (axis == "Y")
            {
                if (action == Actions.Add)
                {
                    if (plateau.yAxis >= (yPosition + 1))
                        return true;
                    throw new Exception("Rovers cant move out of bounds, tried to move outside the y axis");
                }
                else if (action == Actions.Substract)
                {
                    if (yPosition > 0)
                        return true;
                    throw new Exception("Rovers cant move out of bounds, tried to move outside the y axis");
                }
            }
            else if (axis == "X")
            {
                if (action == Actions.Add)
                {
                    if (plateau.xAxis >= (xPosition + 1))
                        return true;
                    throw new Exception("Rovers cant move out of bounds, tried to move outside the y axis");
                }
                else if (action == Actions.Substract)
                {
                    if (xPosition > 0)
                        return true;
                    throw new Exception("Rovers cant move out of bounds, tried to move outside the y axis");
                }
            }
            throw new Exception("Move validation received invalid axis");
        }
    }
}
