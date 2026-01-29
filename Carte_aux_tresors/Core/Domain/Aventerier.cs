using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Aventurier
    {
        public string Nom { get; }

        // L’aventurier a :
        // une position + une orientation
        public Position Position { get; private set; }
        public Orientation Orientation { get; private set; }

        public int TresorCollect { get; private set; }

        private readonly List<ActionType> _actions;
        private int index;



        public Aventurier(string name, Position startPosition, Orientation startOrientation, IEnumerable<ActionType> actions)
        {
            Nom = name;

            Position = startPosition;
            Orientation = startOrientation;

            _actions = new List<ActionType>(actions);
            TresorCollect = 0;

        }

        public bool HasActions()
        {
            return index < _actions.Count;
        }

        public ActionType GetNextAction()
        {
            var action = _actions[index];
            index++;
            return action;
        }


        public void TurnLeft()
        {
            switch (Orientation)
            {
                case Orientation.Nord:
                    Orientation = Orientation.Ouest;
                    break;

                case Orientation.Ouest:
                    Orientation = Orientation.Sud;
                    break;

                case Orientation.Sud:
                    Orientation = Orientation.East;
                    break;

                case Orientation.East:
                    Orientation = Orientation.Nord;
                    break;

                default:
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Orientation)
            {
                case Orientation.Nord:
                    Orientation = Orientation.East;
                    break;

                case Orientation.East:
                    Orientation = Orientation.Sud;
                    break;

                case Orientation.Sud:
                    Orientation = Orientation.Ouest;
                    break;

                case Orientation.Ouest:
                    Orientation = Orientation.Nord;
                    break;

                default:
                    break;
            }
        }

        public void MouvementValide()
        {
            Position = Position.Move(Orientation);
        }

        public void CollectTreasure()
        {
            TresorCollect++;
        }
    }
}
