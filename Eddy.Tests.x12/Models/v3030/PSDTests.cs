using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSD*SS*d1*3*41*nR*3v*oc*6*2";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCode = "SS",
			SampleSelectionMethodCode = "d1",
			SampleFrequencyValuePerUnitOfMeasurementCode = 3,
			UnitOrBasisForMeasurementCode = "41",
			SampleDescriptionCode = "nR",
			SampleDirectionCode = "3v",
			SampleLocationCode = "oc",
			Description = "6",
			SampleSelectionModulus = 2,
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "41", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "41", false)]
	public void Validation_AllAreRequiredSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		//Required fields
		//Test Parameters
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0) 
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(3, 2, false)]
	[InlineData(3, 0, true)]
	[InlineData(0, 2, true)]
	public void Validation_OnlyOneOfSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, decimal sampleSelectionModulus, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		//Required fields
		//Test Parameters
        if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
        {
            subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
            subject.UnitOrBasisForMeasurementCode = "AA";
        }

        if (sampleSelectionModulus > 0) 
			subject.SampleSelectionModulus = sampleSelectionModulus;

		

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
