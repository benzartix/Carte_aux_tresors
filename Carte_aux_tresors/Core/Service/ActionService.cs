using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ActionService
    {
        private readonly MovementService _movementService;

        public ActionService(MovementService movementService)
        {
            _movementService = movementService;
        }

        public void ExecuteNextAction(Aventurier adventurer)
        {
            if (!adventurer.HasActions())
                return;

            var action = adventurer.GetNextAction();

            switch (action)
            {
                case ActionType.tourneGauche:
                    adventurer.TurnLeft();
                    break;

                case ActionType.toutneDroite:
                    adventurer.TurnRight();
                    break;

                case ActionType.avancer:
                    _movementService.Movement(adventurer);
                    break;
            }
        }
    }
}
