using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilis
{
    using System.IO;

    namespace Core.Utilis
    {
        public class OutputWriter
        {
            public void Write(string filePath, Map map, Aventurier adventurer)
            {
                using var writer = new StreamWriter(filePath);

                // Carte
                writer.WriteLine($"C - {map.Width} - {map.Height}");

                // Montagnes
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        var cell = map.GetCellule(new Position(x, y));
                        if (cell.Terrain == TerrainType.Mountagne)
                        {
                            writer.WriteLine($"M - {x} - {y}");
                        }
                    }
                }

                // Commentaire trésors
                writer.WriteLine("# {T comme Trésor} - {Axe horizontal} - {Axe vertical} - {Nb. de trésors restants}");

                // Trésors restants
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        var cell = map.GetCellule(new Position(x, y));
                        if (cell.nbTresors > 0)
                        {
                            writer.WriteLine($"T - {x} - {y} - {cell.nbTresors}");
                        }
                    }
                }

                // Commentaire aventurier
                writer.WriteLine("# {A comme Aventurier} - {Nom de l’aventurier} - {Axe horizontal} - {Axe vertical} - {Orientation} - {Nb. trésors ramassés}");

                // Aventurier
                writer.WriteLine(
                    $"A - {adventurer.Nom} - {adventurer.Position.X} - {adventurer.Position.Y} - {ToChar(adventurer.Orientation)} - {adventurer.TresorCollect}"
                );
            }

            private char ToChar(Orientation orientation)
            {
                switch (orientation)
                {
                    case Orientation.Nord: return 'N';
                    case Orientation.Sud: return 'S';
                    case Orientation.East: return 'E';
                    case Orientation.Ouest: return 'O';
                    default: return '?';
                }
            }
        }
    }
}
