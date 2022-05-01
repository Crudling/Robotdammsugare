using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotdammsugare_Sawubona_Claes_R
{
    public static class InputParser
    {
        
        public static HouseMap ParseMap(string input)
        {
            try
            {
                var parsedMapString = input.Split(';').SingleOrDefault(s => s.Contains("M:"));
                if (parsedMapString == null)
                {
                    Console.WriteLine("Could not parse input for map coordinates. Did you forget \"M:\"?");
                    return null;
                }

                var coordinateArray = parsedMapString.Trim(';').Substring(2).Split(',');
                HouseMap map = new HouseMap(int.Parse(coordinateArray[0]), int.Parse(coordinateArray[1]), int.Parse(coordinateArray[2]), int.Parse(coordinateArray[3]));
                return map;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public static Coordinate ParseStartingPos(string input)
        {
            try
            {
                var parsedStartingPosString = input.Split(';').SingleOrDefault(s => s.Contains("S:"));
                if (parsedStartingPosString == null)
                {
                    Console.WriteLine("Could not parse input for robot starting position coordinates. Did you forget \"S:\"?");
                    return null;
                }

                var startingPos = parsedStartingPosString.Trim(';').Substring(2).Split(',');
                Coordinate startingPosition = new Coordinate(int.Parse(startingPos[0]), int.Parse(startingPos[1]));

                return startingPosition;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                
            }
        }

        public static List<MoveInstruction> ParseAndCheckMovementCommands(string input)
        {
            try
            {
                var movementInstructions = input.Split(';').SingleOrDefault(s => s.Contains('[') || s.Contains(']'));
                if (movementInstructions == null)
                {
                    Console.WriteLine("Could not parse input for movement instructions. Did you forget \"[\" or \"]\"?");
                    return null;
                }


                movementInstructions = movementInstructions.Trim('[').Trim(']');
                var movementArray = movementInstructions.Split(',');

                bool CheckOk()
                {
                    foreach (var instruction in movementArray)
                    {
                        var directionLetter = instruction.Substring(0, 1);
                        var noOfMoves = instruction.Substring(1);
                        if ((directionLetter != "N" && directionLetter != "E" && directionLetter != "S" && directionLetter != "W") || !int.TryParse(noOfMoves, out int result))
                        {
                            return false;
                        }
                    }
                    return true;
                }

                if (CheckOk())
                {
                    var movements = new List<MoveInstruction>();
                    foreach (var instruction in movementArray)
                    {
                        switch (instruction.Substring(0,1))
                        {
                            case "N":
                                movements.Add(new MoveInstruction(Direction.North, int.Parse(instruction.Substring(1))));
                                break;
                            case "E":
                                movements.Add(new MoveInstruction(Direction.East, int.Parse(instruction.Substring(1))));
                                break;
                            case "S":
                                movements.Add(new MoveInstruction(Direction.South, int.Parse(instruction.Substring(1))));
                                break;
                            case "W":
                                movements.Add(new MoveInstruction(Direction.West, int.Parse(instruction.Substring(1))));
                                break;
                            default:
                                break;
                        }
                    }
                    return movements;
                }
                else
                {
                    Console.WriteLine("Something is not quite right with the movement instructions.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        //private static List<Coordinate> parseStringToCoordinates(string coordinateString)
        //{
        //    if (string.IsNullOrWhiteSpace(coordinateString)) Console.WriteLine("Could not parse input to valid coordinates or movement instructions. " + "\n" +
        //        "Please follow a format similar to \"M:-10,10,-10,10;S:-5,5;[W5,E5,N4,E3,S2,W1]\"");
        //    try
        //    {
        //        //Removes trailing ; and M:/S: to be able to parse the input for the map or starting pos into indivudal coordinates.
        //        coordinateString = coordinateString.Trim(';');
        //        coordinateString = coordinateString.Substring(2);
        //        var coordinatesArraystrings = coordinateString.Split(',');

        //        //Makes a list of coordinates depending on the amount of values in the input string. Independent of format.  
        //        var coordinatesList = new List<Coordinate>();

        //        for (int i = 0; i < (coordinatesArraystrings.Length) / 2; i++)
        //        {
        //            var coord = new Coordinate();
        //            for (int j = 0; j < coordinatesArraystrings.Length; j++)
        //            {
        //                if (j % 2 == 0)
        //                {
        //                    coord.XValue = int.Parse(coordinatesArraystrings[j]);
        //                }
        //                else
        //                {
        //                    coord.YValue = int.Parse(coordinatesArraystrings[j]);
        //                }
        //            }
        //            coordinatesList.Add(coord);
        //        }

        //        return coordinatesList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //        //lägg in break
        //    }

        //}

    }
}
