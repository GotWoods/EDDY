using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AT3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AT3*fe16x9B7wbwufNx*Ay*2*Ey*5*KRZ*4";

        var expected = new AT3_BillOfLadingRatesAndCharges()
        {
            AmountCharged = "fe16x9B7wbwufNx",
            FreightRateQualifier = "Ay",
            FreightRate = 2,
            RatedAsQualifier = "Ey",
            Quantity = 5,
            BillOfLadingChargeCode = "KRZ",
            PercentageAsDecimal = 4,
        };

        var actual = Map.MapObject<AT3_BillOfLadingRatesAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("fe16x9B7wbwufNx", true)]
    public void Validatation_RequiredAmountCharged(string amountCharged, bool isValidExpected)
    {
        var subject = new AT3_BillOfLadingRatesAndCharges();
        subject.AmountCharged = amountCharged;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredFreightRateQualifier(string freightRateQualifier, decimal freightRate, bool isValidExpected)
    {
        var subject = new AT3_BillOfLadingRatesAndCharges();
        subject.AmountCharged = "yR86nD4EJACJ1Mc";
        subject.FreightRateQualifier = freightRateQualifier;
        if (freightRate > 0)
            subject.FreightRate = freightRate;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredRatedAsQualifier(string ratedAsQualifier, decimal quantity, bool isValidExpected)
    {
        var subject = new AT3_BillOfLadingRatesAndCharges();
        subject.AmountCharged = "yR86nD4EJACJ1Mc";
        subject.RatedAsQualifier = ratedAsQualifier;
        if (ratedAsQualifier != "")
        {
            subject.FreightRateQualifier = "v2";
            subject.FreightRate = 1;
        }
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBRatedAsQualifier(string ratedAsQualifier, string freightRateQualifier, bool isValidExpected)
    {
        var subject = new AT3_BillOfLadingRatesAndCharges();
        subject.AmountCharged = "yR86nD4EJACJ1Mc";
        subject.RatedAsQualifier = ratedAsQualifier;
        if (ratedAsQualifier != "")
            subject.Quantity = 1;
        subject.FreightRateQualifier = freightRateQualifier;
        if (subject.FreightRateQualifier != "")
            subject.FreightRate = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}