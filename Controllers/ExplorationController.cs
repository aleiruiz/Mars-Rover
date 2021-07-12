using System;
using Challenge1.UseCases;

namespace Challenge1
{
    public class ExplorationController
    {
        public Exploration exploration;
        public void Initialize(char[] boundaries)
        {
            if (boundaries.Length != 2)
                throw new Exception("Expected 2 integers to generate boundaries, received " + boundaries.Length);

            if (!int.TryParse(boundaries[0].ToString(), out int xAxis))
                throw new Exception(String.Format("Expected boundaries to be integers, received {0}", boundaries[0]));

            if (!int.TryParse(boundaries[1].ToString(), out int yAxis))
                throw new Exception(String.Format("Expected boundaries to be integers, received {0}", boundaries[1]));

            var exploration = new Exploration();

            exploration.RenderPlateau(xAxis, yAxis);

            this.exploration =  exploration;

        }

        public void DeployRover(char[] initialPosition)
        {
            if (initialPosition.Length != 3)
                throw new Exception("Expected 3 parameters to deploy a rover, received " + initialPosition.Length);

            if (!int.TryParse(initialPosition[0].ToString(), out int xPosition))
                throw new Exception(String.Format("Expected initial Position to be integers, received {0}", initialPosition[0]));

            if (!int.TryParse(initialPosition[1].ToString(), out int yPosition))
                throw new Exception(String.Format("Expected initial Position to be integers, received {0}", initialPosition[1]));

            var facingPosition = initialPosition[2].ToString();

            this.exploration.DeployRover(xPosition, yPosition, facingPosition);
        }

        public void ExecuteInstructions(string instructions)
        {
            this.exploration.ExecuteInstructions(instructions);
        }

        public string PrintFinalPosition()
        {
            return this.exploration.ReturnFinalPosition();
        }


    }
}
