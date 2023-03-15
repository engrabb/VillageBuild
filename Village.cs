using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VillageOfPågar
{
    public class Village
    {

        public static string randomchar = "F M W B";
        public DatabaseConnection dbconnection = new DatabaseConnection();
       
 
        private int food;
        public int Food
        {
            get { return food; }
            set { food = value; }
        }
        private int wood;
        public int Wood
        {
            get { return wood; }
            set { wood = value; }
        }
        private int metal;
        public int Metal
        {
            get { return metal; }
            set { metal = value; }
        }
        private List<Worker> workerList = new List<Worker>();
        public List<Worker> WorkerList
        {
            get { return workerList; }
            set
            {
                workerList = value;
            }
        }
        private List<Buildings> buildingList = new List<Buildings>();
        public List<Buildings> BuildingList
        {
            get { return buildingList; }
            set
            {
                buildingList = value;
            }
        }
        private List<Buildings> buildingProjectList = new List<Buildings>();
        public List<Buildings> BuildingProjectList
        {
            get { return buildingProjectList; }
            set
            {
                buildingProjectList = value;
            }
        }
        private int metalPerDay = 1;
        public int MetalPerDay
        {
            get { return metalPerDay; }
            set
            {
                metalPerDay = value;
            }
        }
        private int woodPerDay = 1;
        public int WoodPerDay
        {
            get { return woodPerDay; }
            set
            {
                woodPerDay = value;
            }
        }
        private int foodPerDay = 5;
        public int FoodPerDay
        {
            get { return foodPerDay; }
            set
            {
                foodPerDay = value;
            }
        }
        private int daysGone = 0;
        public int DaysGone
        {
            get { return daysGone; }
            set
            {
                daysGone = value;
            }
        }
        private int workerBed = 0;
        public int WorkerBed
        {
            get { return workerBed; }
            set
            {
                workerBed = value;
            }
        }
        public int daysToWin = 0;


        public Village()
        {
            this.food = 10;
            this.wood = 0;
            this.metal = 0;
            this.workerBed = 6;
            Buildings firstHouse = new House("House", true);
            Buildings secondHouse = new House("House", true);
            Buildings thirdHouse = new House("House", true);
            buildingList.Add(firstHouse);
            buildingList.Add(secondHouse);
            buildingList.Add(thirdHouse);

        }
        public void AddWorker(string name, string occupation, Village village)
        {
            if (WorkerBed > 0)
            {
                Worker worker = new Worker(name, occupation, village);
                WorkerList.Add(worker);
                WorkerBed--;
            }
            else
                Console.WriteLine("Not enough room for more workers!");
        }
        public void AddProject(string name)
        {
            try
            {
                if (name == "House" && Wood >= 5)
                {
                    Buildings house = new House("House", false);
                    BuildingProjectList.Add(house);
                    Wood -= 5;
                }
                else if (name == "Farm" && Wood >= 5 && Metal >= 2)
                {
                    Buildings farm = new Farm("Farm", false);
                    BuildingProjectList.Add(farm);
                    Wood -= 5;
                    Metal -= 2;
                }
                else if (name == "Quarry" && Wood >= 3 && Metal >= 5)
                {
                    Buildings quarry = new Quarry("Quarry", false);
                    BuildingProjectList.Add(quarry);
                    Wood -= 3;
                    Metal -= 5;
                }
                else if (name == "Woodmill" && Wood >= 3 && Metal >= 5)
                {
                    Buildings woodmill = new Woodmill("Woodmill", false);
                    BuildingProjectList.Add(woodmill);
                    Wood -= 3;
                    Metal -= 5;
                }
                else if (name == "Castle" && Wood >= 50 && Metal >= 50)
                {
                    Buildings castle = new Castle("Castle", false);
                    BuildingProjectList.Add(castle);
                    Wood -= 50;
                    Metal -= 50;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Not enough resources to build that!");
            }

        }
        public void Day()
        {
            DaysGone++;
            FeedWorkers();
            GameOver();
            AddFood();
            AddWood();
            AddMetal();
            for (int i = 0; i < WorkerList.Count; i++)
            {
                WorkerList[i].doWork();

            }


        }
        public void AddFood() => Food += FoodPerDay;
        public void AddMetal() => Metal += MetalPerDay;
        public void AddWood() => Wood += WoodPerDay;
        public void Build()
        {

            try
            {
                BuildingProjectList[0].daysWorkerOn++;
                if (BuildingProjectList[0].daysWorkerOn == BuildingProjectList[0].daysToComplete)
                {
                    BuildingProjectList[0].complete = true;
                    CompleteBuilding();
                    BuildingList.Add(BuildingProjectList[0]);
                    BuildingProjectList.Remove(BuildingProjectList[0]);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("No more projects in line!");
            }


        }
        public void FeedWorkers()
        {
            for (int i = 0; i < WorkerList.Count; i++)
            {
                if (WorkerList[i].daysHungry == 40)
                {
                    WorkerList[i].alive = false;
                    BuryDead();

                }
                else if (Food == 0)
                {
                    WorkerList[i].hungry = true;
                    WorkerList[i].daysHungry += 1;
                    Console.WriteLine(WorkerList[i].name + " has been hungry for: " + WorkerList[i].daysHungry + " days");
                }
                else
                    Food--;
            }
        }
        public void BuryDead()
        {
            try
            {
                for (int i = WorkerList.Count - 1; i >= 0; i--)
                {
                    if (WorkerList[i].alive == false)
                    {

                        WorkerList.RemoveAt(i);
                        Console.WriteLine("The fool has been buried..!");
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("No one has to die today!");
            }
        }
        public void CompleteBuilding()
        {

            try
            {
                if (BuildingProjectList[0].name == "House" && BuildingProjectList[0].complete == true)
                {
                    WorkerBed += 2;

                }
                else if (BuildingProjectList[0].name == "Farm" && BuildingProjectList[0].complete == true)
                {
                    FoodPerDay += 5;

                }
                else if (BuildingProjectList[0].name == "Woodmill" && BuildingProjectList[0].complete == true)
                {
                    WoodPerDay += 2;
                }
                else if (BuildingProjectList[0].name == "Quarry" && BuildingProjectList[0].complete == true)
                {
                    MetalPerDay += 2;
                }
                else if (BuildingProjectList[0].name == "Castle" && BuildingProjectList[0].complete == true)
                {
                    daysToWin = DaysGone;
                    Win();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Nothing to complete you fool!");
            }
        }
        public void Win()
        {
            Console.Clear();
            Console.WriteLine("You won foo! It took you " + daysGone + " days to win!");
            Environment.Exit(1);
        }

        public void GameOver()
        {
            if (WorkerList.Count == 0)
            {
                Console.WriteLine("You have lost the game foo!");
                Environment.Exit(2);
            }
        }

        public void SaveProgress()
        {
            dbconnection.Save(this);
        }
        public void LoadProgress()
        {
            Village V = dbconnection.Load();
            V.food = Food;
            V.wood = Wood;
            V.metal = Metal;
            V.workerList = WorkerList;
            V.buildingList = BuildingList;
            V.buildingProjectList = BuildingProjectList;
            V.metalPerDay = MetalPerDay;
            V.woodPerDay = WoodPerDay;
            V.foodPerDay = FoodPerDay;
            V.workerBed = WorkerBed;
            V.daysGone = DaysGone;
        }
        public Village(int food, int wood, int metal, List<Worker> workerList,
            List<Buildings> buildingList, List<Buildings> buildingProjectList, int metalPerDay,
            int woodPerDay, int foodPerDay, int workerBed, int daysGone)
        {
            this.food = food;
            this.wood = wood;
            this.metal = metal;
            this.workerList = workerList;
            this.buildingList = buildingList;
            this.buildingProjectList = buildingProjectList;
            this.metalPerDay = metalPerDay;
            this.woodPerDay = woodPerDay;
            this.foodPerDay = foodPerDay;
            this.workerBed = workerBed;
            this.daysGone = daysGone;
        
        }


        public Village(DatabaseConnection dbc)
        {
            dbconnection = dbc;
        }
        
        public virtual string AddRandomWorker4()
        {
            Random rand = new Random();

            string delegs = "BFMW";

            int length = 1;

            string random = "";

            for (int i = 0; i < length; i++)
            {
                int delegsLetter = rand.Next(4);
                random = random + delegs.ElementAt(delegsLetter);
            }
            
            return random;
        }
        public virtual void AddWorkerTest(string name, string occupation, Village village)
        {
            if (WorkerBed > 0)
            {
                Worker worker = new Worker(name, occupation, village);
                WorkerList.Add(worker);
                WorkerBed--;
            }
            else
                Console.WriteLine("Not enough room for more workers!");
        }

    }
}

