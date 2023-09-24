using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*5*7*4*2*Gd*6";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			PopulationSizeCount = 5,
			SampleSizeCount = 7,
			SubgroupSizeCount = 4,
			ConfidenceLimit = 2,
			UnitOfMeasurementCode = "Gd",
			SampleFrequencyValuePerUnitOfMeasurementCode = 6,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Gd", 6, true)]
	[InlineData("Gd", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, int sampleFrequencyValuePerUnitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SPS_SamplingParametersForSummaryStatistics();
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		if (sampleFrequencyValuePerUnitOfMeasurementCode > 0)
			subject.SampleFrequencyValuePerUnitOfMeasurementCode = sampleFrequencyValuePerUnitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
