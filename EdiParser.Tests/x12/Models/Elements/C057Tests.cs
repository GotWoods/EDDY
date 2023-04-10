using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C057Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "*Bt*X";

        var expected = new C057_CommunicationNumberComponent()
        {
            CommunicationNumberQualifier = "Bt",
            CommunicationNumber = "X",
        };

        var actual = Map.MapObject<C057_CommunicationNumberComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        try
        {
            Assert.Equivalent(expected, actual);
        }
        catch
        {
            Assert.Fail(actual.ValidationResult.ToString());
        }
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("Bt", "X", true)]
    [InlineData("", "X", false)]
    [InlineData("Bt", "", false)]
    public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
    {
        var subject = new C057_CommunicationNumberComponent();
        subject.CommunicationNumberQualifier = communicationNumberQualifier;
        subject.CommunicationNumber = communicationNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}