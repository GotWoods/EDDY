using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AWDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AWD*AB>CA>1*1**dOU";

        var expected = new AWD_AmountWithDescription
        {
            AmountQualifyingDescription = new C007_AmountQualifyingDescription
            {
                AmountQualifierCode = "AB",
                AmountQualifierCode2 = "CA",
                ValueDetailCode = "1"
            },
            MonetaryAmount = 1,
            //FreeFormInformation = "9",
            CurrencyCode = "dOU"
        };

        var actual = Map.MapObject<AWD_AmountWithDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    //TODO: composites
    // [Theory]
    // [InlineData("", false)]
    // [InlineData("", true)]
    // public void Validatation_RequiredAmountQualifyingDescription(C007_AmountQualifyingDescription amountQualifyingDescription, bool isValidExpected)
    // {
    // 	var subject = new AWD_AmountWithDescription();
    // 	subject.AmountQualifyingDescription = amountQualifyingDescription;
    // 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    // }

    [Theory]
    [InlineData(0, "", false)]
    [InlineData(0, "9", true)]
    [InlineData(1, "", true)]
    public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, string freeFormInformation, bool isValidExpected)
    {
        var subject = new AWD_AmountWithDescription();
        //subject.AmountQualifyingDescription = "";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        subject.FreeFormInformation = freeFormInformation;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(1, "9", false)]
    [InlineData(0, "9", true)]
    [InlineData(1, "", true)]
    public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, string freeFormInformation, bool isValidExpected)
    {
        var subject = new AWD_AmountWithDescription();
        //subject.AmountQualifyingDescription = "";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        subject.FreeFormInformation = freeFormInformation;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
}