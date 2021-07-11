using Challenge1.Entities;
using System;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Console.WriteLine("Hello! Lets send a robot to Mars!");

            Console.WriteLine("Specify the plateau boundaries");
            char[] boundaries = Console.ReadLine().ToCharArray();

                if (boundaries.Length != 2)
                    throw new Exception("Expected 2 integers to generate bounderies, received " + boundaries.Length);

                if (!int.TryParse(boundaries[0].ToString(), out int xAxis))
                    throw new Exception(String.Format("Expected bounderies to be integers, received {0}", boundaries[0]));

                if(!int.TryParse(boundaries[1].ToString(), out int yAxis))
                    throw new Exception(String.Format("Expected bounderies to be integers, received {0}", boundaries[1]));

                var exploration = new Exploration();

                exploration.BeginExploration(xAxis, yAxis);

                Console.WriteLine("Plateau has been rendered correctly!");
                while (true)
                {
                    Console.WriteLine("Lets deploy a Rover!");

                    Console.WriteLine("Write initial position, type exit to stop the exploration");

                    var initialization = Console.ReadLine();
                    
                    if(initialization == "exit")
                    {
                        break;
                    }
                    
                    var initialPosition = initialization.ToCharArray();

                    if (initialPosition.Length != 3)
                        throw new Exception("Expected 3 parameters to deploy a rover, received " + initialPosition.Length);

                    if (!int.TryParse(initialPosition[0].ToString(), out int xPosition))
                        throw new Exception(String.Format("Expected initial Position to be integers, received {0}", initialPosition[0]));

                    if (!int.TryParse(initialPosition[1].ToString(), out int yPosition))
                        throw new Exception(String.Format("Expected initial Position to be integers, received {0}", initialPosition[1]));

                    var facingPosition = initialPosition[2].ToString();

                    exploration.DeployRover(xPosition, yPosition, facingPosition);

                    Console.WriteLine("Rover Deployed! Type the next instructions");

                    var instructions = Console.ReadLine();

                    exploration.ExecuteInstructions(instructions);

                    Console.WriteLine("Rover has finished his mission!");
                    
                    Console.WriteLine(exploration.ReturnFinalPosition());

                    Console.ReadLine();
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
