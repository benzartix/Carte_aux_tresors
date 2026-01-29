using Carte_aux_tresors.Utilis;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class InputParserTests
    {
        [Fact]
        public void Parser_should_create_map_and_adventurer()
        {
            var filePath = "test.txt";

            File.WriteAllLines(filePath, new[]
            {
            "C - 3 - 4",
            "M - 1 - 0",
            "T - 0 - 3 - 2",
            "A - Ahmed - 1 - 1 - S - AAD"
        });

            var parser = new InputParser();
            var result = parser.Parse(filePath);

            Assert.NotNull(result.Map);
            Assert.NotNull(result.aventurier);
            Assert.Equal(3, result.Map.Width);
            Assert.Equal(4, result.Map.Height);
            Assert.Equal(new Position(1, 1), result.aventurier.Position);
        }
    }
}