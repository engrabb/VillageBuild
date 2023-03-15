using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageOfPågar
{
    public class DatabaseConnection
    {
        
        public virtual void Save(Village village)
        {
                 
        }
        public virtual Village Load()
        {
            return new Village();
        }
    }
}
