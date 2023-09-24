using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO8Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PO8*o*4*3*Fr*ypt**9*CM*9*LA*1*f2*8*xL*8*Do*9";

        var expected = new PO8_UnmarkedTradeItemPhysicalDetails
        {
            AssignedIdentification = "o",
            Pack = 4,
            Size = 3,
            UnitOrBasisForMeasurementCode = "Fr",
            PackagingCode = "ypt",
            CompositeProductWeightBasis = null,
            GrossVolumePerPack = 9,
            UnitOrBasisForMeasurementCode2 = "CM",
            Length = 9,
            UnitOrBasisForMeasurementCode3 = "LA",
            Width = 1,
            UnitOrBasisForMeasurementCode4 = "f2",
            Height = 8,
            UnitOrBasisForMeasurementCode5 = "xL",
            ItemDepth = 8,
            UnitOrBasisForMeasurementCode6 = "Do",
            InnerPack = 9
        };

        var actual = Map.MapObject<PO8_UnmarkedTradeItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = assignedIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(3, "Fr", true)]
    [InlineData(0, "Fr", false)]
    [InlineData(3, "", false)]
    public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (size > 0)
            subject.Size = size;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "CM", true)]
    [InlineData(0, "CM", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (grossVolumePerPack > 0)
            subject.GrossVolumePerPack = grossVolumePerPack;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "LA", true)]
    [InlineData(0, "LA", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (length > 0)
            subject.Length = length;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(9, 8, false)]
    [InlineData(0, 8, true)]
    [InlineData(9, 0, true)]
    public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (length > 0)
            subject.Length = length;
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "f2", true)]
    [InlineData(0, "f2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode4, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (width > 0)
            subject.Width = width;
        subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "xL", true)]
    [InlineData(0, "xL", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode5, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (height > 0)
            subject.Height = height;
        subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "Do", true)]
    [InlineData(0, "Do", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode6, bool isValidExpected)
    {
        var subject = new PO8_UnmarkedTradeItemPhysicalDetails();
        subject.AssignedIdentification = "o";
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;
        subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}