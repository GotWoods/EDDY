using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AT2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AT2*5*c0G*pF*p*3*3*r1M*B*gdDLaxMFMZSJPojszr12y7TLXkap6t*o6cU6*I*18*4*8";

        var expected = new AT2_BillOfLadingLineItemDetail()
        {
            LadingQuantity = 5,
            PackagingFormCode = "c0G",
            WeightQualifier = "pF",
            WeightUnitCode = "p",
            Weight = 3,
            LadingQuantity2 = 3,
            PackagingFormCode2 = "r1M",
            YesNoConditionOrResponseCode = "B",
            CommodityCode = "gdDLaxMFMZSJPojszr12y7TLXkap6t",
            FreightClassCode = "o6cU6",
            YesNoConditionOrResponseCode2 = "I",
            LadingValue = 18,
            VolumeUnitQualifier = "4",
            Volume = 8,
        };

        var actual = Map.MapObject<AT2_BillOfLadingLineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v22", true)]
    [InlineData(0, "v22", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredLadingQuantity(int ladingQuantity, string packagingFormCode, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightQualifier = "pF";
        subject.WeightUnitCode = "p";
        subject.Weight = 3;
        if (ladingQuantity > 0)
            subject.LadingQuantity = ladingQuantity;
        subject.PackagingFormCode = packagingFormCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("pF", true)]
    public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightUnitCode = "p";
        subject.Weight = 3;
        subject.WeightQualifier = weightQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("p", true)]
    public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightQualifier = "pF";
        subject.Weight = 3;
        subject.WeightUnitCode = weightUnitCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(3, true)]
    public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightQualifier = "pF";
        subject.WeightUnitCode = "p";
        if (weight > 0)
            subject.Weight = weight;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v23", true)]
    [InlineData(0, "v23", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredLadingQuantity2(int ladingQuantity2, string packagingFormCode2, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightQualifier = "pF";
        subject.WeightUnitCode = "p";
        subject.Weight = 3;
        if (ladingQuantity2 > 0)
            subject.LadingQuantity2 = ladingQuantity2;
        subject.PackagingFormCode2 = packagingFormCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
    {
        var subject = new AT2_BillOfLadingLineItemDetail();
        subject.WeightQualifier = "pF";
        subject.WeightUnitCode = "p";
        subject.Weight = 3;
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        if (volume > 0)
            subject.Volume = volume;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}