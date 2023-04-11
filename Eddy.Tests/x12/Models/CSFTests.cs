using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CSFTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "CSF*AA*8*6";

        var expected = new CSF_ConditionalSamplingFrequency
        {
            CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = "AA"},
            SampleSelectionModulus = 8,
            SampleFrequencyValuePerUnitOfMeasurementCode = 6
        };

        var actual = Map.MapObject<CSF_ConditionalSamplingFrequency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AA", true)]
    public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
    {
        var subject = new CSF_ConditionalSamplingFrequency();
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(8, 6, false)]
    [InlineData(0, 6, true)]
    [InlineData(8, 0, true)]
    public void Validation_OnlyOneOfSampleSelectionModulus(decimal sampleSelectionModulus, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
    {
        var subject = new CSF_ConditionalSamplingFrequency();
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        if (sampleSelectionModulus > 0)
            subject.SampleSelectionModulus = sampleSelectionModulus;
        if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
            subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
}