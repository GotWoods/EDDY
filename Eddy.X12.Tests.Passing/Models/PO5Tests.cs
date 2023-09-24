using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PO5*3*4*Mp*1*c*1*i8*5*Kc*7*zz*6*cz*8*uW*5*x*1**124*ti*7*2*kD*G*5*3*Q*1*6*j*1*2*J*c*Z";

        var expected = new PO5_ExpandedItemPhysicalDetails
        {
            Pack = 3,
            Size = 4,
            UnitOrBasisForMeasurementCode = "Mp",
            Volume = 1,
            VolumeUnitQualifier = "c",
            Length = 1,
            UnitOrBasisForMeasurementCode2 = "i8",
            Width = 5,
            UnitOrBasisForMeasurementCode3 = "Kc",
            Height = 7,
            UnitOrBasisForMeasurementCode4 = "zz",
            ItemDepth = 6,
            UnitOrBasisForMeasurementCode5 = "cz",
            InnerPack = 8,
            SurfaceLayerPositionCode = "uW",
            AssignedIdentification = "5",
            AssignedIdentification2 = "x",
            Number = 1,
            CompositeProductWeightBasis = null,
            TareWeight = 124,
            UnitOrBasisForMeasurementCode6 = "ti",
            Quantity = 7,
            PegCode = "2",
            UnitOrBasisForMeasurementCode7 = "kD",
            ReferenceIdentification = "G",
            XPeg = 5,
            YPeg = 3,
            ReferenceIdentification2 = "Q",
            XPeg2 = 1,
            YPeg2 = 6,
            ReferenceIdentification3 = "j",
            XPeg3 = 1,
            YPeg3 = 2,
            UnmarkedNumberOfInnerPacks = "J",
            UnmarkedNumberOfInnerPackLayers = "c",
            UnmarkedNumberOfInnerPacksPerLayer = "Z"
        };

        var actual = Map.MapObject<PO5_ExpandedItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(4, "Mp", true)]
    [InlineData(0, "Mp", false)]
    [InlineData(4, "", false)]
    public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (size > 0)
            subject.Size = size;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "c", true)]
    [InlineData(0, "c", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (volume > 0)
            subject.Volume = volume;
        subject.VolumeUnitQualifier = volumeUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "i8", true)]
    [InlineData(0, "i8", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (length > 0)
            subject.Length = length;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(1, 6, false)]
    [InlineData(0, 6, true)]
    [InlineData(1, 0, true)]
    public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (length > 0)
        {
            subject.Length = length;
            subject.UnitOrBasisForMeasurementCode2 = "AA";
        }
        if (itemDepth > 0)
        {
            subject.ItemDepth = itemDepth;
            subject.UnitOrBasisForMeasurementCode5 = "AA";
        }


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "Kc", true)]
    [InlineData(0, "Kc", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (width > 0)
            subject.Width = width;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(7, "zz", true)]
    [InlineData(0, "zz", false)]
    [InlineData(7, "", false)]
    public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode4, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (height > 0)
            subject.Height = height;
        subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(6, "cz", true)]
    [InlineData(0, "cz", false)]
    [InlineData(6, "", false)]
    public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode5, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;
        subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "5", true)]
    [InlineData("x", "", false)]
    public void Validation_ARequiresBAssignedIdentification2(string assignedIdentification2, string assignedIdentification, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.AssignedIdentification2 = assignedIdentification2;
        subject.AssignedIdentification = assignedIdentification;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(124, "ti", true)]
    [InlineData(0, "ti", false)]
    [InlineData(124, "", false)]
    public void Validation_AllAreRequiredTareWeight(int tareWeight, string unitOrBasisForMeasurementCode6, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (tareWeight > 0)
            subject.TareWeight = tareWeight;
        subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(7, "2", true)]
    [InlineData(0, "2", false)]
    [InlineData(7, "", false)]
    public void Validation_AllAreRequiredQuantity(decimal quantity, string pegCode, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        if (quantity > 0)
            subject.Quantity = quantity;
        subject.PegCode = pegCode;

        if (pegCode != "")
            subject.YPeg = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("2", 3, true)]
    [InlineData("", 3, false)]
    [InlineData("2", 0, false)]
    public void Validation_AllAreRequiredPegCode(string pegCode, decimal yPeg, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.PegCode = pegCode;
        if (yPeg > 0)
            subject.YPeg = yPeg;

        if (pegCode != "")
            subject.Quantity = 1;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "kD", true)]
    [InlineData("G", "", false)]
    public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode7, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.ReferenceIdentification = referenceIdentification;
        subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "kD", true)]
    [InlineData("Q", "", false)]
    public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode7, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.ReferenceIdentification2 = referenceIdentification2;
        subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "kD", true)]
    [InlineData("j", "", false)]
    public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode7, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.ReferenceIdentification3 = referenceIdentification3;
        subject.UnitOrBasisForMeasurementCode7 = unitOrBasisForMeasurementCode7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("c", "Z", true)]
    [InlineData("", "Z", false)]
    [InlineData("c", "", false)]
    public void Validation_AllAreRequiredUnmarkedNumberOfInnerPackLayers(string unmarkedNumberOfInnerPackLayers, string unmarkedNumberOfInnerPacksPerLayer, bool isValidExpected)
    {
        var subject = new PO5_ExpandedItemPhysicalDetails();
        subject.UnmarkedNumberOfInnerPackLayers = unmarkedNumberOfInnerPackLayers;
        subject.UnmarkedNumberOfInnerPacksPerLayer = unmarkedNumberOfInnerPacksPerLayer;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}