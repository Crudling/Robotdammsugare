using Robotdammsugare_Sawubona_Claes_R;


while (true)
{
    Console.WriteLine("Input legible commands if you please.");
    var input = Console.ReadLine();

    var robot = new RobotVacuum(InputParser.ParseStartingPos(input), InputParser.ParseStartingPos(input),
                                InputParser.ParseMap(input), new List<Coordinate>(), new List<Coordinate>());

    robot.Clean(InputParser.ParseAndCheckMovementCommands(input));

    Console.WriteLine("All areas cleaned:");
    Console.WriteLine(robot.GetCleanedAreasAsString());
    Console.WriteLine("Unique positions cleaned:");
    Console.WriteLine(robot.GetUniqueAreasCleaned());
    Console.WriteLine();
}

