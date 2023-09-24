using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PADTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PAD*o*f5*Rq*84E*2";

        var expected = new PAD_ProductAdjustmentDetail
        {
            AssignedIdentification = "o",
            ProductTransferTypeCode = "f5",
            ChangeOrResponseTypeCode = "Rq",
            PriceMultiplierQualifier = "84E",
            Multiplier = 2
        };

        var actual = Map.MapObject<PAD_ProductAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("o", "f5", true)]
    [InlineData("", "f5", true)]
    [InlineData("o", "", true)]
    public void Validation_AtLeastOneAssignedIdentification(string assignedIdentification, string productTransferTypeCode, bool isValidExpected)
    {
        var subject = new PAD_ProductAdjustmentDetail();
        subject.AssignedIdentification = assignedIdentification;
        subject.ProductTransferTypeCode = productTransferTypeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("84E", 2, true)]
    [InlineData("", 2, false)]
    [InlineData("84E", 0, false)]
    public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
    {
        var subject = new PAD_ProductAdjustmentDetail();
        subject.PriceMultiplierQualifier = priceMultiplierQualifier;
        subject.AssignedIdentification = "AA";
        if (multiplier > 0)
            subject.Multiplier = multiplier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}