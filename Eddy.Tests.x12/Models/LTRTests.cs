using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LTRTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "LTR*d*I*7**f*A*Y*2*9*P*9*1";

        var expected = new LTR_LaboratoryTestResults
        {
            CodeListQualifierCode = "d",
            IndustryCode = "I",
            MeasurementValue = 7,
            CompositeUnitOfMeasure = null,
            CodeListQualifierCode2 = "f",
            IndustryCode2 = "A",
            ShipmentStatusCode = "Y",
            RangeMinimum = 2,
            RangeMaximum = 9,
            GenderCode = "P",
            RangeMinimum2 = 9,
            RangeMaximum2 = 1
        };

        var actual = Map.MapObject<LTR_LaboratoryTestResults>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("d", true)]
    public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
    {
        var subject = new LTR_LaboratoryTestResults();
        subject.IndustryCode = "I";
        subject.CodeListQualifierCode = codeListQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("I", true)]
    public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
    {
        var subject = new LTR_LaboratoryTestResults();
        subject.CodeListQualifierCode = "d";
        subject.IndustryCode = industryCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "A", true)]
    [InlineData("f", "", false)]
    public void Validation_ARequiresBCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
    {
        var subject = new LTR_LaboratoryTestResults();
        subject.CodeListQualifierCode = "d";
        subject.IndustryCode = "I";
        subject.CodeListQualifierCode2 = codeListQualifierCode2;
        subject.IndustryCode2 = industryCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", 0, 0, true)]
    [InlineData("P", 2, 0, true)]
    [InlineData("P", 0, 2, true)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_GenderCode(string genderCode, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
    {
        var subject = new LTR_LaboratoryTestResults();
        subject.CodeListQualifierCode = "d";
        subject.IndustryCode = "I";
        subject.GenderCode = genderCode;
        if (rangeMinimum > 0)
            subject.RangeMinimum = rangeMinimum;
        if (rangeMaximum > 0)
            subject.RangeMaximum = rangeMaximum;


        
            

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData(0, 0, 0, true)]
    [InlineData(9, 2, 0, true)]
    [InlineData(9, 9, 0, true)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_RangeMinimum2(decimal rangeMinimum2, decimal rangeMinimum, decimal rangeMaximum, bool isValidExpected)
    {
        var subject = new LTR_LaboratoryTestResults();
        subject.CodeListQualifierCode = "d";
        subject.IndustryCode = "I";
        if (rangeMinimum2 > 0)
            subject.RangeMinimum2 = rangeMinimum2;
        if (rangeMinimum > 0)
            subject.RangeMinimum = rangeMinimum;
        if (rangeMaximum > 0)
            subject.RangeMaximum = rangeMaximum;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

}