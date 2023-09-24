using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G61Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "G61*12*NAME";

        var expected = new G61_Contact()
        {
            ContactFunctionCode = "12",
            Name = "NAME"
        };

        var actual = Map.MapObject<G61_Contact>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("12", "NAME", true)]
    [InlineData(null, "NAME", false)]
    [InlineData("12", null, false)]
    public void Validation_RequiredFields(string functionCode, string name, bool isValidExpected)
    {
        var subject = new G61_Contact();
        subject.ContactFunctionCode = functionCode;
        subject.Name = name;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }


    [Theory]
    [InlineData("12", "555-555-5555", true)]
    [InlineData(null, null, true)]
    [InlineData(null, "555-555-5555", false)]
    [InlineData("12", null, false)]
    public void Validation_CommunicationNumber(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
    {
        var subject = new G61_Contact();
        subject.ContactFunctionCode = "12";
        subject.Name = "name";

        subject.CommunicationNumberQualifier = communicationNumberQualifier;
        subject.CommunicationNumber = communicationNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}