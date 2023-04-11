using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AM1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AM1*kS*LX*R*3*3*7";

        var expected = new AM1_InformationalValues
        {
            CodeCategory = "kS",
            ProductServiceIDQualifier = "LX",
            ProductServiceID = "R",
            MonetaryAmount = 3,
            Quantity = 3,
            PercentageAsDecimal = 7
        };

        var actual = Map.MapObject<AM1_InformationalValues>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("kS", true)]
    public void Validatation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
    {
        var subject = new AM1_InformationalValues();
        subject.ProductServiceIDQualifier = "LX";
        subject.ProductServiceID = "R";
        subject.CodeCategory = codeCategory;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("LX", true)]
    public void Validatation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
    {
        var subject = new AM1_InformationalValues();
        subject.CodeCategory = "kS";
        subject.ProductServiceID = "R";
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("R", true)]
    public void Validatation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
    {
        var subject = new AM1_InformationalValues();
        subject.CodeCategory = "kS";
        subject.ProductServiceIDQualifier = "LX";
        subject.ProductServiceID = productServiceID;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}