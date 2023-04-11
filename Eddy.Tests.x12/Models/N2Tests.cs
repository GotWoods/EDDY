using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "N2*D*g";

        var expected = new N2_AdditionalNameInformation()
        {
            Name = "D",
            Name2 = "g",
        };

        var actual = Map.MapObject<N2_AdditionalNameInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredName(string name, bool isValidExpected)
    {
        var subject = new N2_AdditionalNameInformation();
        subject.Name = name;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}