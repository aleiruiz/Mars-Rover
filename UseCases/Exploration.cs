using Challenge1.Entities;
using Challenge1.Helpers;
using System;

namespace Challenge1
{
    public class Exploration
    {
        public static Plateau BeginExploration(int xAxis, int yAxis)
        {
            if (xAxis < 0 || yAxis < 0)
                throw new Exception("Invalid plateu boundaries");
            return new Plateau(xAxis, yAxis);
        }

        public static Rover DeployRover(Plateau plateau, int xPosition, int yPosition, string facingPosition)
        {
            if ((xPosition < 0 || xPosition > plateau.xAxis) || (yPosition < 0 || yPosition > plateau.yAxis))
                throw new Exception("Cannot deploy Rover outside of plateu boundaries");
            
            var cardinalDirection = FilterEnum.GetCardinalDirectionFromString(facingPosition);

            return new Rover(plateau, xPosition, yPosition, cardinalDirection);
        }

        public static string ExecuteInstructions(string instructions, Rover rover)
        {

            foreach(char instructionChar in instructions)
            {
                string instruction = instructionChar.ToString();
                switch (instruction)
                {
                    case "M":
                        rover.Move();
                        break;
                    case "L":
                        rover.TurnFacingPosition("L");
                        break;
                    case "R":
                        rover.TurnFacingPosition("R");
                        break;
                    default:
                        throw new Exception("Cannot perform unknown Instruction " + instruction);

                }
            }

            return rover.ReturnCurrentPosition();


        }
    }
}
