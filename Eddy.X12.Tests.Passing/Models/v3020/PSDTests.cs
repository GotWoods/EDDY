using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSD*mT*tZ*9*Pb*Uw*ml*Bz*t";

		var expected = new PSD_PhysicalSampleDescription()
		{
			SampleProcessStatusCode = "mT",
			SampleSelectionMethodCode = "tZ",
			SampleFrequencyValuePerUnitOfMeasurementCode = 9,
			UnitOfMeasurementCode = "Pb",
			SampleDescriptionCode = "Uw",
			SampleDirectionCode = "ml",
			SampleLocationCode = "Bz",
			Description = "t",
		};

		var actual = Map.MapObject<PSD_PhysicalSampleDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Pb", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Pb", false)]
	public void Validation_AllAreRequiredSampleFrequencyValuePerUnitOfMeasurementCode(int sampleFrequencyValuePerUnitOfMeasurementCode, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PSD_PhysicalSampleDescription();
		//Required fields
		//Test Parameters
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0) 
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
