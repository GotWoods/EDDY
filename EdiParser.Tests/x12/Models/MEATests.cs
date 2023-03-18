using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class MEATests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "MEA*AA*1i*9**9*9*BB**DD*ms*jQ*k09S15D7S4CowaVRPTiyvTt2dIm4c";

        var expected = new MEA_Measurements()
        {
            MeasurementReferenceIDCode = "AA",
            MeasurementQualifier = "1i",
            MeasurementValue = 9,
            //CompositeUnitOfMeasure = ,
            RangeMinimum = 9,
            RangeMaximum = 9,
            MeasurementSignificanceCode = "BB",
            //MeasurementAttributeCode = "C",
            SurfaceLayerPositionCode = "DD",
            MeasurementMethodOrDeviceCode = "ms",
            CodeListQualifierCode = "jQ",
            IndustryCode = "k09S15D7S4CowaVRPTiyvTt2dIm4c",
        };

        var actual = Map.MapObject<MEA_Measurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", "", true)]
    [InlineData(1, "A", "", true)]
    [InlineData(1, "", "B", true)]
    [InlineData(1, "A", "B", true)]
    [InlineData(1, "", "", false)]
    public void Validation_RangeMinimumRequiresUnitOfMeasureOrIndustryCode(decimal rangeMinimum, string compositeUnitOfMeasure, string industryCode, bool isValidExpected)
    {
        var subject = new MEA_Measurements();
        if (rangeMinimum > 0)
            subject.RangeMinimum = rangeMinimum;
        subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;
        subject.IndustryCode = industryCode;
        if (industryCode != "")
            subject.CodeListQualifierCode = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    }

    [Theory]
    [InlineData(0, "", "", true)]
    [InlineData(1, "A", "", true)]
    [InlineData(1, "", "B", true)]
    [InlineData(1, "A", "B", true)]
    [InlineData(1, "", "", false)]
    public void Validation_RangeMaximumRequiresUnitOfMeasureOrIndustryCode(decimal rangeMaximum, string compositeUnitOfMeasure, string industryCode, bool isValidExpected)
    {
        var subject = new MEA_Measurements();
        if (rangeMaximum > 0)
            subject.RangeMaximum = rangeMaximum;
        subject.CompositeUnitOfMeasure = compositeUnitOfMeasure;
        subject.IndustryCode = industryCode;
        if (industryCode != "")
            subject.CodeListQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    }

    [Theory]
    [InlineData("", 0, 0, 0, true)]
    [InlineData("AA", 1, 0, 0, true)]
    [InlineData("AA", 0, 1, 0, true)]
    [InlineData("AA", 0, 0, 1, true)]
    [InlineData("AA", 0, 0, 0, false)]
    public void Validation_MeasurementSignificanceCode(string measurementSignificanceCode, decimal measurementValue, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
    {
        var subject = new MEA_Measurements();
        subject.MeasurementSignificanceCode = measurementSignificanceCode;
        if (measurementValue > 0)
            subject.MeasurementValue = measurementValue;
        if (rangeMinimum > 0)
        {
            subject.RangeMinimum = rangeMinimum;
            subject.CompositeUnitOfMeasure = "A";
        }
        if (rangeMaximum > 0)
        {
            subject.RangeMaximum = rangeMaximum;
            subject.CompositeUnitOfMeasure = "A";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, false)]
    [InlineData("", 1, true)]
    [InlineData("v1", 0, true)]
    public void Validation_OnlyOneOfMeasurementAttributeCode(string measurementAttributeCode, decimal measurementValue, bool isValidExpected)
    {
        var subject = new MEA_Measurements();
        subject.MeasurementAttributeCode = measurementAttributeCode;
        if (measurementValue > 0)
            subject.MeasurementValue = measurementValue;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
    {
        var subject = new MEA_Measurements();
        subject.CodeListQualifierCode = codeListQualifierCode;
        subject.IndustryCode = industryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}