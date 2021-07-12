using Challenge1.Models;
using Challenge1.Helpers;
using System;

namespace Challenge1.UseCases
{
    public class Exploration
    {
        public Plateau plateau;
        public Rover rover;

        public void RenderPlateau(int xAxis, int yAxis)
        {
            if (xAxis < 0 || yAxis < 0)
                throw new Exception("Invalid plateu boundaries");
            this.plateau = new Plateau(xAxis, yAxis);
        }

        public void DeployRover(int xPosition, int yPosition, string facingPosition)
        {
            if ((xPosition < 0 || xPosition > this.plateau.xAxis) || (yPosition < 0 || yPosition > this.plateau.yAxis))
                throw new Exception("Cannot deploy Rover outside of plateu boundaries");
            
            var cardinalDirection = FilterEnum.GetCardinalDirectionFromString(facingPosition);

            this.rover = new Rover(this.plateau, xPosition, yPosition, cardinalDirection);
        }

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

        public string ReturnFinalPosition()
        {
            return this.rover.ReturnCurrentPosition();
        }
    }
}
