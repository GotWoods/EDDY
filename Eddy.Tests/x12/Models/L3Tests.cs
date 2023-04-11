using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "L3*1*Y*k*bb*A*l*h*2iB*7*B*4*I*X*D3*YL";

        var expected = new L3_TotalWeightAndCharges
        {
            Weight = 1,
            WeightQualifier = "Y",
            FreightRate = "k",
            RateValueQualifier = "bb",
            AmountCharged = "A",
            Advances = "l",
            PrepaidAmount = "h",
            SpecialChargeOrAllowanceCode = "2iB",
            Volume = "7",
            VolumeUnitQualifier = "B",
            LadingQuantity = "4",
            WeightUnitCode = "I",
            TariffNumber = "X",
            DeclaredValue = "D3",
            RateValueQualifier2 = "YL"
        };

        var actual = Map.MapObject<L3_TotalWeightAndCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }


    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validatation_RequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
    {
        var subject = new L3_TotalWeightAndCharges();
        if (weight > 0)
            subject.Weight = weight;
        subject.WeightQualifier = weightQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validatation_RequiredFreightRate(string freightRate, string rateValueQualifier, bool isValidExpected)
    {
        var subject = new L3_TotalWeightAndCharges();
        subject.FreightRate = freightRate;
        subject.RateValueQualifier = rateValueQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v", true)]
    [InlineData("", "v", false)]
    [InlineData("v1", "", false)]
    public void Validatation_RequiredVolume(string volume, string volumeUnitQualifier, bool isValidExpected)
    {
        var subject = new L3_TotalWeightAndCharges();
        subject.Volume = volume;
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validatation_RequiredDeclaredValue(string declaredValue, string rateValueQualifier, bool isValidExpected)
    {
        var subject = new L3_TotalWeightAndCharges();
        subject.DeclaredValue = declaredValue;
        subject.RateValueQualifier2 = rateValueQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}