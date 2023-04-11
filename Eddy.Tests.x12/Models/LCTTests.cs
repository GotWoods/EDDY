using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LCTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "LCT*M*6ai*x*x*8*V*8*1*5*M*5*d";

        var expected = new LCT_LogisticsContainerTrackingInformation
        {
            ReferenceIdentification = "M",
            PackagingFormCode = "6ai",
            Description = "x",
            WeightUnitCode = "x",
            UnitWeight = 8,
            MeasurementUnitQualifier = "V",
            Length = 8,
            Width = 1,
            Height = 5,
            VolumeUnitQualifier = "M",
            Volume = 5,
            PalletExchangeCode = "d"
        };

        var actual = Map.MapObject<LCT_LogisticsContainerTrackingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("M", true)]
    public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.PackagingFormCode = "6ai";
        subject.ReferenceIdentification = referenceIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("6ai", true)]
    public void Validation_RequiredPackagingFormCode(string packagingFormCode, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = packagingFormCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("x", 8, true)]
    [InlineData("", 8, false)]
    [InlineData("x", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        subject.WeightUnitCode = weightUnitCode;
        if (unitWeight > 0)
            subject.UnitWeight = unitWeight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, 0, 0, true)]
    [InlineData("V", 8, 0, 0, false)]
    [InlineData("", 8, 0, 0, true)]
    [InlineData("V", 0, 0, 0, true)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_MeasurementUnitQualifier(string measurementUnitQualifier, decimal length, decimal width, decimal height, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        subject.MeasurementUnitQualifier = measurementUnitQualifier;
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
    [InlineData(0, "V", true)]
    [InlineData(8, "", false)]
    public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        if (length > 0)
            subject.Length = length;
        subject.MeasurementUnitQualifier = measurementUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "V", true)]
    [InlineData(1, "", false)]
    public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        if (width > 0)
            subject.Width = width;
        subject.MeasurementUnitQualifier = measurementUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "V", true)]
    [InlineData(5, "", false)]
    public void Validation_ARequiresBHeight(decimal height, string measurementUnitQualifier, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        if (height > 0)
            subject.Height = height;
        subject.MeasurementUnitQualifier = measurementUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("M", 5, true)]
    [InlineData("", 5, false)]
    [InlineData("M", 0, false)]
    public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
    {
        var subject = new LCT_LogisticsContainerTrackingInformation();
        subject.ReferenceIdentification = "M";
        subject.PackagingFormCode = "6ai";
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        if (volume > 0)
            subject.Volume = volume;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}