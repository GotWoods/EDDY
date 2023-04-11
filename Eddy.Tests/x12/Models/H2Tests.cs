using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class H2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "H2*I5*x";

        var expected = new H2_AdditionalHazardousMaterialDescription()
        {
            HazardousMaterialDescription = "I5",
            HazardousMaterialClassification = "x",
        };

        var actual = Map.MapObject<H2_AdditionalHazardousMaterialDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredHazardousMaterialDescription(string hazardousMaterialDescription, bool isValidExpected)
    {
        var subject = new H2_AdditionalHazardousMaterialDescription();
        subject.HazardousMaterialDescription = hazardousMaterialDescription;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}