using Challenge1.Models;
using Challenge1.Helpers;
using System;

namespace Challenge1.UseCases
{
    /// <summary>
    /// This class shall do all the required business logic validations and comunicate with models.
    /// </summary>
    public class Exploration
    {
        /// <summary>
        /// Plateau Object
        /// </summary>
        public Plateau plateau;
        /// <summary>
        /// Rover Object
        /// </summary>
        public Rover rover;

        /// <summary>
        /// Render the initial plateau with the giving boundaries
        /// </summary>
        /// <param name="xAxis">The furthest point to the East</param>
        /// <param name="yAxis">The furthest point to the North</param>
        public void RenderPlateau(int xAxis, int yAxis)
        {
            if (xAxis < 0 || yAxis < 0)
                throw new Exception("Invalid plateu boundaries");
            this.plateau = new Plateau(xAxis, yAxis);
        }

        /// <summary>
        /// Deploys a new rover with the initial positions gived, 
        /// </summary>
        /// <param name="xPosition">Spaces travelled to the East</param>
        /// <param name="yPosition">Spaces travelled to the North</param>
        /// <param name="facingPosition">Position that Rover is facing</param>
        public void DeployRover(int xPosition, int yPosition, string facingPosition)
        {
            if ((xPosition < 0 || xPosition > this.plateau.xAxis) || (yPosition < 0 || yPosition > this.plateau.yAxis))
                throw new Exception("Cannot deploy Rover outside of plateu boundaries");
            
            var cardinalDirection = FilterEnum.GetCardinalDirectionFromString(facingPosition);

            this.rover = new Rover(this.plateau, xPosition, yPosition, cardinalDirection);
        }

        /// <summary>
        /// Execute Gived Instruction 
        /// </summary>
        /// <param name="instructions">A string with each character beign a diferent instruction</param>
        public void ExecuteInstructions(string instructions)
        {

            foreach(char instructionChar in instructions)
            {
                string instruction = instructionChar.ToString().ToUpper();
                switch (instruction)
                {
                    case "M":
                        this.rover.Move();
                        break;
                    case "L":
                    case "R":
                        this.rover.TurnFacingPosition(instruction);
                        break;
                    default:
                        throw new Exception("Cannot perform unknown Instruction " + instruction);

                }
            }
        }

        /// <summary>
        /// Returns the final x y and facing positions 
        /// </summary>
        /// <returns>String with x y and facing positions</returns>
        public string ReturnFinalPosition()
        {
            return this.rover.ReturnCurrentPosition();
        }
    }
}
