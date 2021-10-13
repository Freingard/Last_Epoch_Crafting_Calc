using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_Craft_Calculator
{
    class CraftingPoint
    {
        public float probability;
        public int[] affixes;
        public List<int> craftingPathsIndexes;
        public string howToCraftResult;

        public void InitializePoint(int numberOfAffixes)
        {
            craftingPathsIndexes = new List<int>();
            affixes = new int[numberOfAffixes];
        }
    }
}
