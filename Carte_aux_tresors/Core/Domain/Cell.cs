using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    //Représenter une case de la carte
    public class Cellule
    {
        public TerrainType Terrain { get; set; } = TerrainType.Plaine;
        public int nbTresors { get; set; } = 0;
    }
}
