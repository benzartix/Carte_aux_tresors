using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Map
    {
        private readonly Cellule[,] terrin;

        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            terrin = new Cellule[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    terrin[x, y] = new Cellule();
        }

        public bool IsInside(Position position)
        {
            return position.X >= 0 && position.X < Width
                && position.Y >= 0 && position.Y < Height;
        }

        public Cellule GetCellule(Position position)
        {
            return terrin[position.X, position.Y];
        }
    }
}
