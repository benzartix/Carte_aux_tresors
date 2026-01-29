using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_aux_tresors.Utilis
{
    public class InputParser
    {
        public ParsedInput Parse(string filePath)
        {
            Map map = null;
            Aventurier aventurier = null;

            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("#"))
                    continue;

                var parts = line.Split(" - ");

                switch (parts[0])
                {
                    case "C":
                        int width = int.Parse(parts[1]);
                        int height = int.Parse(parts[2]);
                        map = new Map(width, height);
                        break;

                    case "M":
                        map.GetCellule(
                            new Position(
                                int.Parse(parts[1]),
                                int.Parse(parts[2])
                            )
                        ).Terrain = TerrainType.Mountagne;
                        break;

                    case "T":
                        map.GetCellule(
                            new Position(
                                int.Parse(parts[1]),
                                int.Parse(parts[2])
                            )
                        ).nbTresors = int.Parse(parts[3]);
                        break;

                    case "A":
                        aventurier = new Aventurier(
                            parts[1],
                            new Position(
                                int.Parse(parts[2]),
                                int.Parse(parts[3])
                            ),
                            ParseOrientation(parts[4]),
                            ParseActions(parts[5])
                        );
                        break;
                }
            }

            return new ParsedInput(map, aventurier);
        }

        private Orientation ParseOrientation(string value)
        {
            switch (value)
            {
                case "N": return Orientation.Nord;
                case "S": return Orientation.Sud;
                case "E": return Orientation.East;
                case "O": return Orientation.Ouest;
                default: throw new InvalidDataException("Orientation inconnue");
            }
        }

        private List<ActionType> ParseActions(string sequence)
        {
            var actions = new List<ActionType>();

            foreach (char c in sequence)
            {
                switch (c)
                {
                    case 'A': actions.Add(ActionType.avancer); break;
                    case 'G': actions.Add(ActionType.tourneGauche); break;
                    case 'D': actions.Add(ActionType.toutneDroite); break;
                }
            }

            return actions;
        }
    }
}