using System;

namespace Challenge1
{
    public class Program
    {
        /// <summary>
        /// This Function will be in charge of displaying outputs to the console, it shall not perform any type of business logic.
        /// </summary>
        static void Main()
        {
            try
            {
                Console.WriteLine("Hello! Lets send a robot to Mars!");
                Console.WriteLine("Specify the plateau boundaries");
        
                var exploration = new ExplorationController();

                exploration.Initialize(Console.ReadLine());

                Console.WriteLine("Plateau has been rendered correctly!");
                // This is done to prevent the application to turn off after deploying the first rover, we shall be able to deploy multiple rovers in the same plateau
                while (true)
                {
                    Console.WriteLine("Lets deploy a Rover!");

                    // We ask the user for Rover's initial position.
                    Console.WriteLine("Write initial position");

                    // We deploy Rover in the requested position
                    exploration.DeployRover(Console.ReadLine());

                    // We request Rover's instructions
                    Console.WriteLine("Rover Deployed! Type the next instructions");

                    // We Execute the instructions given
                    exploration.ExecuteInstructions(Console.ReadLine());

                    Console.WriteLine("Rover has finished his mission!");

                    // We Display the final position of Rover before finalizing! 
                    Console.WriteLine("Final Position: " + exploration.PrintFinalPosition());

                    // We let the user see the final output before moving on to the next iteration
                    Console.ReadLine();
                }
            }
            //TODO: Generate an Exception Handler
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
