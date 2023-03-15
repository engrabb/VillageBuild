using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VillageOfPågar
{
    public class Buildings
    {
        public string name = "";
        public int woodCost = 0;
        public int metalCost = 0;
        public int daysWorkerOn = 0;
        public int daysToComplete = 0;
        public bool complete = false;

        public Buildings(string name, bool complete)
        {
            this.name = name;
            this.complete = complete;
        }

    }
    class House : Buildings
    {
        public House(string name, bool complete) : base(name, complete)
        {
            woodCost = 5;
            daysToComplete = 3;
            
        }
    }
    class Quarry : Buildings
    {
        public Quarry(string name, bool complete) : base(name, complete)
        {
            woodCost = 3;
            metalCost = 5;
            daysToComplete = 7;
        }
    }
    class Woodmill : Buildings
    {
        public Woodmill(string name, bool complete) : base(name, complete)
        {
            woodCost = 3;
            metalCost = 5;
            daysToComplete = 7;
        }
    }
    class Farm : Buildings
    {
        public Farm(string name, bool complete) : base(name, complete)
        {
            woodCost = 5;
            metalCost = 2;
            daysToComplete = 5;
        }
    }
    class Castle : Buildings
    {
        public Castle(string name, bool complete) : base(name, complete)
        {
            woodCost = 50;
            metalCost = 50;
            daysToComplete = 50;
        }
    }
}
