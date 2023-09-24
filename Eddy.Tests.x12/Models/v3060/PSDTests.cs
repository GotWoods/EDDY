using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSD*2p*hb*2**iK*Sn*ax*d*6";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCode = "2p",
			SampleSelectionMethodCode = "hb",
			SampleFrequencyValuePerUnitOfMeasurementCode = 2,
			CompositeUnitOfMeasure = null,
			SampleDescriptionCode = "iK",
			SampleDirectionCode = "Sn",
			PositionCode = "ax",
			Description = "d",
			SampleSelectionModulus = 6,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "", true)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		//Required fields
		//Test Parameters
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
        {
            subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        }

        if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 6, false)]
	[InlineData(2, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, decimal sampleSelectionModulus, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		//Required fields
		//Test Parameters
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
        {
            subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        }

        if (sampleSelectionModulus > 0) 
			subject.SampleSelectionModulus = sampleSelectionModulus;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
