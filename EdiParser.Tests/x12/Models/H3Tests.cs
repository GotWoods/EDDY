using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class H3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "H3*4s**X*9*c";

        var expected = new H3_SpecialHandlingInstructions()
        {
            SpecialHandlingCode = "4s",
            //SpecialHandlingDescription = "CU", //this is exclusive with SpecialHandlingCode
            ProtectiveServiceCode = "X",
            VentInstructionCode = "9",
            TariffApplicationCode = "c",
        };

        var actual = Map.MapObject<H3_SpecialHandlingInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", false)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
    {
        var subject = new H3_SpecialHandlingInstructions();
        subject.SpecialHandlingCode = specialHandlingCode;
        subject.SpecialHandlingDescription = specialHandlingDescription;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
}