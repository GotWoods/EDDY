using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*6*2*5*8*TK*4";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			Count = 6,
			Count2 = 2,
			Count3 = 5,
			ConfidenceLimit = 8,
			UnitOrBasisForMeasurementCode = "TK",
			SampleFrequencyValuePerUnitOfMeasurementCode = 4,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TK", 4, true)]
	[InlineData("TK", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SPS_SamplingParametersForSummaryStatistics();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
