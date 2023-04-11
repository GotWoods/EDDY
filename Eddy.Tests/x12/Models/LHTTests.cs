using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LHTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LHT*JjJmlvG5qMspQ76483HLU4gNcfulPH*EZinDVjXJTHXUxtNKeXvKDhwAAbA0D5Uwv8Z1Rdz*AyVI2GNxzFiHQ4jICx8jvhwlH";

        var expected = new LHT_TransborderHazardousRequirements()
        {
            HazardousClassificationCode = "JjJmlvG5qMspQ76483HLU4gNcfulPH",
            HazardousPlacardNotationCode = "EZinDVjXJTHXUxtNKeXvKDhwAAbA0D5Uwv8Z1Rdz",
            HazardousEndorsementCode = "AyVI2GNxzFiHQ4jICx8jvhwlH",
        };

        var actual = Map.MapObject<LHT_TransborderHazardousRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
}