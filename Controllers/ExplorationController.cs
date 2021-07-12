using System;
using Challenge1.UseCases;

namespace Challenge1
{
    /// <summary>
    /// This controller shall only make input validations and execute Use Cases.
    /// </summary>
    public class ExplorationController
    {
        /// <summary>
        /// We dont want Main program to manage any use case, we want a public exploration use case to prevent unecessary burden 
        /// </summary>
        public Exploration exploration;

        /// <summary>
        /// We initialize the exploration process using the initial boundaries
        /// </summary>
        /// <param name="boundaries">Two characters string containg the plateau boundaries</param>
        public void Initialize(string boundaries)
        {
            if (boundaries.Length != 2)
                throw new Exception("Expected 2 integers to generate boundaries, received " + boundaries.Length);

            if (!int.TryParse(boundaries[0].ToString(), out int xAxis))
                throw new Exception(string.Format("Expected boundaries to be integers, received {0}", boundaries[0]));

            if (!int.TryParse(boundaries[1].ToString(), out int yAxis))
                throw new Exception(string.Format("Expected boundaries to be integers, received {0}", boundaries[1]));

            var exploration = new Exploration();

            exploration.RenderPlateau(xAxis, yAxis);

            this.exploration =  exploration;

        }

        /// <summary>
        /// Deploy Rover using initial position
        /// </summary>
        /// <param name="initialPosition">3 characters string, first two for rover's initial position and the third for facing direction</param>
        public void DeployRover(string initialPosition)
        {
            if (initialPosition.Length != 3)
                throw new Exception("Expected 3 parameters to deploy a rover, received " + initialPosition.Length);

            if (!int.TryParse(initialPosition[0].ToString(), out int xPosition))
                throw new Exception(string.Format("Expected initial Position to be integers, received {0}", initialPosition[0]));

            if (!int.TryParse(initialPosition[1].ToString(), out int yPosition))
                throw new Exception(string.Format("Expected initial Position to be integers, received {0}", initialPosition[1]));

            // We can safely asume there is an index in the second position because the initial validation for 3 characters passed.
            var facingPosition = initialPosition[2].ToString();

            this.exploration.DeployRover(xPosition, yPosition, facingPosition);
        }

        /// <summary>
        /// Execute a list of instructions provided as an array
        /// </summary>
        /// <param name="instructions">A string with N characters each one representing a different instruction</param>
        public void ExecuteInstructions(string instructions)
        {
            this.exploration.ExecuteInstructions(instructions);
        }

        /// <summary>
        /// Return the final position from the Rover.
        /// </summary>
        /// <returns>A string with three characters, the first two beign the x and y axis and the last one beign the faced direction</returns>
        public string PrintFinalPosition()
        {
            return this.exploration.ReturnFinalPosition();
        }


    }
}
