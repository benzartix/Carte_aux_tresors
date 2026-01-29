using Core.Domain;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class TreasureTests
    {
        [Fact]
        public void Adventurer_collects_one_treasure_when_entering_cell()
        {
            var map = new Map(3, 3);
            map.GetCellule(new Position(1, 0)).nbTresors = 2;

            var service = new MovementService(map);

            var adventurer = new Aventurier(
                "LARA",
                new Position(1, 1),
                Orientation.Nord,
                new List<ActionType>()
            );

            service.Movement(adventurer);

            Assert.Equal(1, adventurer.TresorCollect);
            Assert.Equal(1, map.GetCellule(new Position(1, 0)).nbTresors);
        }

        [Fact]
        public void No_treasure_collected_if_cell_is_empty()
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

            Assert.Equal(0, adventurer.TresorCollect);
        }
    }
}
