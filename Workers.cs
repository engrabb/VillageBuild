using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageOfPågar
{
    public class Worker
    {
        public string name = "";
        public string occupation = "";
        public bool hungry = false;
        public int daysHungry = 0;
        public delegate void DoWorkDelegate();
        public bool alive = true;
        DoWorkDelegate woodDelegate;
        DoWorkDelegate metalDelegate;
        DoWorkDelegate foodDelegate;
        DoWorkDelegate buildDelegate;

        public Worker(string name, string occupation, Village village)
        {
            this.name = name;
            this.occupation = occupation;
            woodDelegate = new DoWorkDelegate(village.AddWood);
            metalDelegate = new DoWorkDelegate(village.AddMetal);
            foodDelegate = new DoWorkDelegate(village.AddFood);
            buildDelegate = new DoWorkDelegate(village.Build);

        }
        public void doWork()
        {
            if (hungry == false)
            {


                if (occupation == "W")
                {
                    woodDelegate();
                }
                else if (occupation == "M")
                {
                    metalDelegate();
                }
                else if (occupation == "F")
                {
                    foodDelegate();
                }
                else if (occupation == "B")
                {
                    buildDelegate();
                }
            }

        }

    }
    
}
