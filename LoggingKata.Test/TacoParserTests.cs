using System;
using System.Runtime.InteropServices;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", -84.683302)]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", -85.961342)]
        [InlineData("30.906033,-87.79328,Taco Bell Bay Minett...", -87.79328)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.720804,-85.280165,Taco Bell La Fayett...", 34.720804)]
        [InlineData("33.051273,-85.028938,Taco Bell Lagrang...", 33.051273)]
        [InlineData("33.560223,-86.522897,Taco Bell Leed...",  33.560223)]
        [InlineData("33.702531,-84.168202,Taco Bell Lithoni...", 33.702531)]

    public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
