using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSD*0I*WJ*8**QD*W8*2d*n*2";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCode = "0I",
			SampleSelectionMethodCode = "WJ",
			SampleFrequencyValuePerUnitOfMeasurementCode = 8,
			CompositeUnitOfMeasure = null,
			SampleDescriptionCode = "QD",
			SampleDirectionCode = "W8",
			PositionCode = "2d",
			Description = "n",
			SampleSelectionModulus = 2,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(8, "AA", false)]
	public void Validation_AllAreRequiredSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
		subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(8, 2, false)]
	[InlineData(0, 2, true)]
	[InlineData(8, 0, true)]
	public void Validation_OnlyOneOfSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, decimal sampleSelectionModulus, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
		subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		if (sampleSelectionModulus > 0)
		subject.SampleSelectionModulus = sampleSelectionModulus;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
