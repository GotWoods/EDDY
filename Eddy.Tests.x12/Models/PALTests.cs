using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PALTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PAL*y*2*1*8*4*rT*8*5*5*rS*9*1l*6*r8*d*4*E*7*S*T";

        var expected = new PAL_PalletTypeAndLoadCharacteristics
        {
            PalletTypeCode = "y",
            PalletTiers = 2,
            PalletBlocks = 1,
            Pack = 8,
            UnitWeight = 4,
            UnitOrBasisForMeasurementCode = "rT",
            Length = 8,
            Width = 5,
            Height = 5,
            UnitOrBasisForMeasurementCode2 = "rS",
            GrossWeightPerPack = 9,
            UnitOrBasisForMeasurementCode3 = "1l",
            GrossVolumePerPack = 6,
            UnitOrBasisForMeasurementCode4 = "r8",
            PalletExchangeCode = "d",
            InnerPack = 4,
            PalletStructureCode = "E",
            Quantity = 7,
            YesNoConditionOrResponseCode = "S",
            Description = "T"
        };

        var actual = Map.MapObject<PAL_PalletTypeAndLoadCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(4, "rT", true)]
    [InlineData(0, "rT", false)]
    [InlineData(4, "", false)]
    public void Validation_AllAreRequiredUnitWeight(decimal unitWeight, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (unitWeight > 0)
            subject.UnitWeight = unitWeight;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "rS", true)]
    [InlineData(8, "", false)]
    public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (length > 0)
            subject.Length = length;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        if (unitOrBasisForMeasurementCode2 != "")
            subject.Width = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "rS", true)]
    [InlineData(5, "", false)]
    public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (width > 0)
            subject.Width = width;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        if (unitOrBasisForMeasurementCode2 != "")
            subject.Length = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "rS", true)]
    [InlineData(5, "", false)]
    public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (height > 0)
            subject.Height = height;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        if (unitOrBasisForMeasurementCode2 != "")
            subject.Width = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", 0, 0, 0, true)]
    [InlineData("rS", 8, 0, 0, true)]
    [InlineData("rS", 0, 8, 0, true)]
    [InlineData("rS", 0, 0, 8, true)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal length, decimal width, decimal height, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        if (length > 0)
            subject.Length = length;
        if (width > 0)
            subject.Width = width;
        if (height > 0)
            subject.Height = height;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "1l", true)]
    [InlineData(0, "1l", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (grossWeightPerPack > 0)
            subject.GrossWeightPerPack = grossWeightPerPack;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(6, "r8", true)]
    [InlineData(0, "r8", false)]
    [InlineData(6, "", false)]
    public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
    {
        var subject = new PAL_PalletTypeAndLoadCharacteristics();
        if (grossVolumePerPack > 0)
            subject.GrossVolumePerPack = grossVolumePerPack;
        subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}