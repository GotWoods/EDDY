using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class TD1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "TD1*fq9*9*m*I*D*j*9*9N*9*nG";

        var expected = new TD1_CarrierDetailsQuantityAndWeight()
        {
            PackagingCode = "fq9",
            LadingQuantity = 9,
            CommodityCodeQualifier = "m",
            CommodityCode = "I",
            LadingDescription = "D",
            WeightQualifier = "j",
            Weight = 9,
            UnitOrBasisForMeasurementCode = "9N",
            Volume = 9,
            UnitOrBasisForMeasurementCode2 = "nG",
        };

        var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 1, true)]
    [InlineData("v1", 0, false)]
    public void Validation_ARequiresBPackagingCode(string packagingCode, int ladingQuantity, bool isValidExpected)
    {
        var subject = new TD1_CarrierDetailsQuantityAndWeight();
        subject.PackagingCode = packagingCode;
        if (ladingQuantity > 0)
            subject.LadingQuantity = ladingQuantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
    {
        var subject = new TD1_CarrierDetailsQuantityAndWeight();
        subject.CommodityCodeQualifier = commodityCodeQualifier;
        subject.CommodityCode = commodityCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 1, true)]
    [InlineData("v1", 0, false)]
    public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
    {
        var subject = new TD1_CarrierDetailsQuantityAndWeight();
        subject.WeightQualifier = weightQualifier;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new TD1_CarrierDetailsQuantityAndWeight();
        if (weight > 0)
            subject.Weight = weight;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new TD1_CarrierDetailsQuantityAndWeight();
        if (volume > 0)
            subject.Volume = volume;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}