
using System;

namespace Challenge1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello! Lets send a robot to Mars!");
                Console.WriteLine("Specify the plateau boundaries");
                var exploration = new ExplorationController();
                exploration.Initialize(Console.ReadLine().ToCharArray());
                Console.WriteLine("Plateau has been rendered correctly!");
                while (true)
                {
                    Console.WriteLine("Lets deploy a Rover!");

                    Console.WriteLine("Write initial position, type exit to stop the exploration");

                    var commands = Console.ReadLine();

                    if (commands == "exit")
                    {
                        break;
                    }

                    var initialPosition = commands.ToCharArray();

                    exploration.DeployRover(initialPosition);

                    Console.WriteLine("Rover Deployed! Type the next instructions");

                    var instructions = Console.ReadLine();

                    exploration.ExecuteInstructions(instructions);

                    Console.WriteLine("Rover has finished his mission!");

                    Console.WriteLine("Final Position: " + exploration.PrintFinalPosition());

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
