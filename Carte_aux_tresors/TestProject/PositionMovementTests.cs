using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PositionMovementTests
    {
        [Fact]
        public void Move_north_should_decrease_Y()
        {
            var start = new Position(1, 1);

            var result = start.Move(Orientation.Nord);

            Assert.Equal(new Position(1, 0), result);
        }

        [Fact]
        public void Move_south_should_increase_Y()
        {
            var start = new Position(1, 1);

            var result = start.Move(Orientation.Sud);

            Assert.Equal(new Position(1, 2), result);
        }

        [Fact]
        public void Move_east_should_increase_X()
        {
            var start = new Position(1, 1);

            var result = start.Move(Orientation.East);

            Assert.Equal(new Position(2, 1), result);
        }

        [Fact]
        public void Move_west_should_decrease_X()
        {
            var start = new Position(1, 1);

            var result = start.Move(Orientation.Ouest);

            Assert.Equal(new Position(0, 1), result);
        }
    }
}
