using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ATHTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ATH*n0*EcKWMpLl*5*8*wIMW2zHu";

        var expected = new ATH_ResourceAuthorization
        {
            ResourceAuthorizationCode = "n0",
            Date = "EcKWMpLl",
            Quantity = 5,
            Quantity2 = 8,
            Date2 = "wIMW2zHu"
        };

        var actual = Map.MapObject<ATH_ResourceAuthorization>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("n0", true)]
    public void Validation_RequiredResourceAuthorizationCode(string resourceAuthorizationCode, bool isValidExpected)
    {
        var subject = new ATH_ResourceAuthorization();
        subject.ResourceAuthorizationCode = resourceAuthorizationCode;
        subject.Date = "20000101";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("EcKWMpLl", 5, true)]
    [InlineData("", 5, true)]
    [InlineData("EcKWMpLl", 0, true)]
    public void Validation_AtLeastOneDate(string date, decimal quantity, bool isValidExpected)
    {
        var subject = new ATH_ResourceAuthorization();
        subject.ResourceAuthorizationCode = "n0";
        subject.Date = date;
        if (quantity > 0)
        {
            subject.Quantity = quantity;
            subject.Date2 = "20000101";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "wIMW2zHu", true)]
    [InlineData(5, "", false)]
    public void Validation_ARequiresBQuantity(decimal quantity, string date2, bool isValidExpected)
    {
        var subject = new ATH_ResourceAuthorization();
        subject.ResourceAuthorizationCode = "n0";
        subject.Date = "20000101";
        if (quantity > 0)
            subject.Quantity = quantity;
        subject.Date2 = date2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "wIMW2zHu", true)]
    [InlineData(8, "", false)]
    public void Validation_ARequiresBQuantity2(decimal quantity2, string date2, bool isValidExpected)
    {
        var subject = new ATH_ResourceAuthorization();
        subject.ResourceAuthorizationCode = "n0";
        subject.Date = "20000101";
        if (quantity2 > 0)
            subject.Quantity2 = quantity2;
        subject.Date2 = date2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}