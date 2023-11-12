using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*4*5*6*7*T5*9";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			PopulationSizeCount = 4,
			SampleSizeCount = 5,
			SubgroupSizeCount = 6,
			ConfidenceLimit = 7,
			UnitOrBasisForMeasurementCode = "T5",
			SampleFrequencyValuePerUnitOfMeasurementCode = 9,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("T5", 9, true)]
	[InlineData("T5", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SPS_SamplingParametersForSummaryStatistics();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
