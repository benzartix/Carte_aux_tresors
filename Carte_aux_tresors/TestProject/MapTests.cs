using Core.Domain;

namespace TestProject
{
    public class MapTests
    {
        [Fact]
        public void Positionvalide()
        {
            var map = new Map(3, 4);

            var position = new Position(1, 2);

            Assert.True(map.IsInside(position));
        }

        [Fact]
        public void PositionNoninvalide()
        {
            var map = new Map(3, 4);

            var position = new Position(3, 4);

            Assert.False(map.IsInside(position));
        }
    }
}