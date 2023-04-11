using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C037Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "U*0";

        var expected = new C037_TaxFieldIdentification()
        {
            TaxInformationIdentificationNumber = "U",
            ApplicationErrorConditionCode = "0",
        };

        var actual = Map.MapObject<C037_TaxFieldIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("U", true)]
    public void Validatation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
    {
        var subject = new C037_TaxFieldIdentification();
        subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}