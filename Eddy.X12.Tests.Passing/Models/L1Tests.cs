using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L1*L*2*Gk*d*c*R*0Kl*V27*A*n*Y*Sx*X*6n*Li*7*e*sR*G*g0N*o*tu";

        var expected = new L1_RateAndCharges()
        {
            LadingLineItemNumber = "L",
            FreightRate = 2,
            RateValueQualifier = "Gk",
            AmountCharged = "d",
            Advances = "c",
            PrepaidAmount = "R",
            RateCombinationPointCode = "0Kl",
            SpecialChargeOrAllowanceCode = "V27",
            RateClassCode = "A",
            EntitlementCode = "n",
            ChargeMethodOfPaymentCode = "Y",
            SpecialChargeDescription = "Sx",
            TariffApplicationCode = "X",
            DeclaredValue = "6n",
            RateValueQualifier2 = "Li",
            LadingLiabilityCode = "7",
            BilledRatedAsQuantity = "e",
            BilledRatedAsQualifier = "sR",
            PercentageAsDecimal = "G",
            CurrencyCode = "g0N",
            Amount = "o",
            LadingValue = "tu",
        };

        var actual = Map.MapObject<L1_RateAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", "", false)]
    [InlineData("a", "b", "c", true)]
    [InlineData("a", "", "", true)]
    [InlineData("", "b", "", true)]
    [InlineData("", "", "c", true)]
    public void Validation_AtLeastOneAmount(string amountCharged, string advances, string prePaidAmount, bool isValidExpected)
    {
        var subject = new L1_RateAndCharges();
        subject.AmountCharged = amountCharged;
        subject.Advances = advances;
        subject.PrepaidAmount = prePaidAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, null, true)]
    [InlineData(5, "AB", true)]
    [InlineData(0, "AB", false)]
    [InlineData(5, null, false)]
    public void Validation_TestFreightRate(decimal freightRate, string rateQualifier, bool isValidExpected)
    {
        var subject = new L1_RateAndCharges();
        subject.AmountCharged = "25"; //needed to pass validation
        if (freightRate > 0)
            subject.FreightRate = freightRate;
        subject.RateValueQualifier = rateQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_RequiredDeclaredValue(string declaredValue, string rateValueQualifier, bool isValidExpected)
    {
        var subject = new L1_RateAndCharges();
        subject.AmountCharged = "25"; //needed to pass validation
        subject.DeclaredValue = declaredValue;
        subject.RateValueQualifier2 = rateValueQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_RequiredBilledRatedAsQuantity(string billedRatedAsQuantity, string billedRatedAsQualifier, bool isValidExpected)
    {
        var subject = new L1_RateAndCharges();
        subject.AmountCharged = "25"; //needed to pass validation
        subject.BilledRatedAsQuantity = billedRatedAsQuantity;
        subject.BilledRatedAsQualifier = billedRatedAsQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}