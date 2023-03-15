
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http.Headers;

namespace VillageOfPågar
{
    class Program
    {
        public static void Main(string[] args)
        {
            
                        Village village = new Village();

                        bool run = true;
                        Console.WriteLine("Welcome to the Village of Men");
                        Console.WriteLine("To conquer the world, you have to build a Castle! To build this Castle you need workers and buildings filling different functions");
                        Console.WriteLine("Your workers are dependent on a food supply, which you gain from having workers gathering food and Farms to help increase the supply");
                        Console.WriteLine("To have room for your workers, you need to build Houses. Each house gives you 2 extra beds");
                        Console.WriteLine("Quarry gives you additional metal supply and the Woodmill will give you additional wood!");
                        Console.WriteLine("If you do not feed your workers enough, they will eventually die.. if all your workers die, game over!");
                        Console.WriteLine("Start off by adding workers!");
                        while (run)
                        {
                            Console.WriteLine("1. Add worker. Give him a name, occupation.");
                            Console.WriteLine("2. Add a project!");
                            Console.WriteLine("3. Buildings in wait.");
                            Console.WriteLine("4. Amount of resources.");
                            Console.WriteLine("5. Call it  a day! This function starts the next day, which means your workers start building and gathering!");
                            Console.WriteLine("6. Completed buildings.");
                            Console.WriteLine("7. Save");
                            Console.WriteLine("8. Quit game");

                            string input = Console.ReadLine();

                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("Worker occupation?(W - WoodWorker, F - Food gatherer, M - MetalWorker, B - Builder");
                                    string work = Console.ReadLine();
                                    village.AddWorker("Dude", work, village);
                                    break;

                                case "2":
                                    Console.WriteLine("House costs: 5 wood and takes 3 days to complete!");
                                    Console.WriteLine("Farm costs: 5 wood, 2 metal and takes 5 days to complete!");
                                    Console.WriteLine("Quarry costs: 3 wood, 5 metal and takes 7 days to complete!");
                                    Console.WriteLine("Woodmill costs: 3 wood, 5 metal and takes 7 days to complete!");
                                    Console.WriteLine("Castle costs: 50 wood, 50 metal and takes 50 days to complete!");
                                    Console.WriteLine("Add a project! House/Farm/Quarry/Woodmill/Castle");
                                    string building = Console.ReadLine();
                                    village.AddProject(building);
                                    break;

                                case "3":
                                    for (int i = 0; i < village.BuildingProjectList.Count; i++)
                                    {
                                        int buildingNr = 1;
                                        buildingNr += i;
                                        Console.WriteLine(buildingNr + "." + "Project: " + village.BuildingProjectList[i].name);
                                    }
                                    break;

                                case "4":
                                    Console.WriteLine("Food: " + village.Food + " Wood: " + village.Wood + " Metal: " + village.Metal);
                                    break;

                                case "5":
                                    Console.WriteLine("Day: " + village.DaysGone);
                                    village.Day();
                                    break;

                                case "6":
                                    for (int i = 0; i < village.BuildingList.Count; i++)
                                    {
                                        int buildingNr = 1;
                                        buildingNr += i;
                                        Console.WriteLine(buildingNr + "." + "Project: " + village.BuildingList[i].name);
                                    }
                                    break;
                                case "7":
                                    village.SaveProgress();
                                    break;

                                case "8":
                                    Environment.Exit(0);
                                    break;






                            }


                        }


            
        }
    }
}