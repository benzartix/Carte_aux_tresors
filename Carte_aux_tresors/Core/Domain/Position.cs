using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    // Représenter une position sur la carte avec :
    public readonly record struct Position(int X, int Y)
    {
        public Position Move(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Nord:
                    return new Position(X, Y - 1);

                case Orientation.Sud:
                    return new Position(X, Y + 1);

                case Orientation.East:
                    return new Position(X + 1, Y);

                case Orientation.Ouest:
                    return new Position(X - 1, Y);

                default:
                    return this;
            }
        }
    }
}
