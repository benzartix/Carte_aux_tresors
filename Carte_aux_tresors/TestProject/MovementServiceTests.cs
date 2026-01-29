using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace TestProject
{
    public class MovementServiceTests
    {
        [Fact]
        public void Adventurer_cannot_exit_map()
        {
            var map = new Map(3, 3);
            var service = new MovementService(map);

            var adventurer = new Aventurier(
                "LARA",
                new Position(0, 0),
                Orientation.Nord,
                new List<ActionType>()
            );

            service.Movement(adventurer);

            Assert.Equal(new Position(0, 0), adventurer.Position);
        }

        [Fact]
        public void Adventurer_cannot_enter_mountain()
        {
            var map = new Map(3, 3);
            map.GetCellule(new Position(1, 0)).Terrain = TerrainType.Mountagne;

            var service = new MovementService(map);

            var adventurer = new Aventurier(
                            "LARA",
                new Position(1, 1),
                Orientation.Nord,
                new List<ActionType>()
            );

            service.Movement(adventurer);

            Assert.Equal(new Position(1, 1), adventurer.Position);
        }

        [Fact]
        public void Adventurer_can_move_on_plain()
        {
            var map = new Map(3, 3);
            var service = new MovementService(map);

            var adventurer = new Aventurier(
                            "LARA",
                new Position(1, 1),
                Orientation.Nord,
                new List<ActionType>()
            );

            service.Movement(adventurer);

            Assert.Equal(new Position(1, 0), adventurer.Position);
        }
    }
}
