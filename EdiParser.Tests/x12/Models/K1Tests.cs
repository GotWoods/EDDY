using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class K1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "K1*r*z";

        var expected = new K1_Remarks()
        {
            FreeFormInformation = "r",
            FreeFormInformation2 = "z",
        };

        var actual = Map.MapObject<K1_Remarks>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredFreeFormInformation(string freeFormInformation, bool isValidExpected)
    {
        var subject = new K1_Remarks();
        subject.FreeFormInformation = freeFormInformation;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}

