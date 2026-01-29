using Core.Domain;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ActionServiceTests
    {
        [Fact]
        public void TourneGauche()
        {
            var map = new Map(3, 3);
            var movementService = new MovementService(map);
            var actionService = new ActionService(movementService);

            var adventurer = new Aventurier(
               "LARA",
                new Position(1, 1),
                Orientation.Nord,
                new[] { ActionType.tourneGauche }
            );

            actionService.ExecuteNextAction(adventurer);

            Assert.Equal(Orientation.Ouest, adventurer.Orientation);
        }

        [Fact]
        public void Avancer()
        {
            var map = new Map(3, 3);
            var movementService = new MovementService(map);
            var actionService = new ActionService(movementService);

            var adventurer = new Aventurier(
                "Ahmed",
                new Position(1, 1),
                Orientation.Sud,
                new[] { ActionType.avancer }
            );

            actionService.ExecuteNextAction(adventurer);

            Assert.Equal(new Position(1, 2), adventurer.Position);
        }
    }
}
