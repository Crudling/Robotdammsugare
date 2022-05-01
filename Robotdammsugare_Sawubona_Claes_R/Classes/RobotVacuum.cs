using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotdammsugare_Sawubona_Claes_R
{
    public class RobotVacuum
    {
        public Coordinate StartingPosition { get; set; }
        public Coordinate CurrentPosition { get; set; }
        public HouseMap CurrentMap { get; set; }
        public List<Coordinate> CleanedPositions { get; set; }
        public List<Coordinate> UniquePosCleaned { get; set; }

        public RobotVacuum(Coordinate startingPosition, Coordinate currentPosition, HouseMap currentMap, List<Coordinate> cleanedPositions, List<Coordinate> uniquePosCleaned)
        {
            StartingPosition = startingPosition;
            CurrentPosition = currentPosition;
            CurrentMap = currentMap;
            CleanedPositions = cleanedPositions;
            UniquePosCleaned = uniquePosCleaned;
        }


        public void Clean(List<MoveInstruction> moveInstructions)
        {
            if (this.StartingPosition == null || this.CurrentPosition == null || this.CurrentMap == null || moveInstructions == null)
            {
                return;
            }
            try
            {
                this.CleanedPositions.Add(new Coordinate(this.CurrentPosition.XValue, this.CurrentPosition.YValue));

                foreach (var instruction in moveInstructions)
                {
                    switch (instruction.Direction)
                    {
                        case Direction.North:
                            for (int i = 0; i < instruction.NumberOfSteps; i++)
                            {
                                if (this.CurrentPosition.YValue < this.CurrentMap.MaxY)
                                {
                                    this.CurrentPosition.YValue++;
                                    this.CleanedPositions.Add(new Coordinate(this.CurrentPosition.XValue, this.CurrentPosition.YValue));
                                }
                                else
                                {
                                    WriteAlmostCrashed();
                                    return;
                                }
                            }
                            break;
                        case Direction.East:
                            for (int i = 0; i < instruction.NumberOfSteps; i++)
                            {
                                if (this.CurrentPosition.XValue < this.CurrentMap.MaxX)
                                {
                                    this.CurrentPosition.XValue++;
                                    this.CleanedPositions.Add(new Coordinate(this.CurrentPosition.XValue, this.CurrentPosition.YValue));
                                }
                                else
                                {
                                    WriteAlmostCrashed();
                                    return;
                                }
                            }
                            break;
                        case Direction.South:
                            for (int i = 0; i < instruction.NumberOfSteps; i++)
                            {
                                if (this.CurrentPosition.YValue > this.CurrentMap.MinY)
                                {
                                    this.CurrentPosition.YValue--;
                                    this.CleanedPositions.Add(new Coordinate(this.CurrentPosition.XValue, this.CurrentPosition.YValue));
                                }
                                else
                                {
                                    WriteAlmostCrashed();
                                    return;
                                }
                            }
                            break;
                        case Direction.West:
                            for (int i = 0; i < instruction.NumberOfSteps; i++)
                            {
                                if (this.CurrentPosition.XValue > this.CurrentMap.MinX)
                                {
                                    this.CurrentPosition.XValue--;
                                    this.CleanedPositions.Add(new Coordinate(this.CurrentPosition.XValue, this.CurrentPosition.YValue));
                                }
                                else
                                {
                                    WriteAlmostCrashed();
                                    return;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public string GetCleanedAreasAsString()
        {
            string areasCleaned = "";
            foreach (var area in this.CleanedPositions)
            {
                areasCleaned += area.XValue + "," + area.YValue + "; ";
            }
            return areasCleaned;
        }

        public string GetUniqueAreasCleaned()
        {
            var UniqueAreas = GetCleanedAreasAsString().Split(' ').Distinct();

            string uniqueareas = "";
            foreach (var area in UniqueAreas)
            {
                uniqueareas += area + " ";
            }
            
            return uniqueareas;
        }

        private void WriteAlmostCrashed()
        {
            Console.Write("I almost went through the wall! ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aborted!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
