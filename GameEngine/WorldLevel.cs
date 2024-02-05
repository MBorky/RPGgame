using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class WorldLevel
    {
        public int Level {  get; private set; }
        public WorldLevel() 
        {
            Level = 1;
        }
        public void WorldLevelUp()
        {
            Level++;
        }
    }
}
