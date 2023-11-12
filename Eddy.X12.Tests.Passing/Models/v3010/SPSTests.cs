using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*6*7*7*9*QH*2";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			PopulationSizeCount = 6,
			SampleSizeCount = 7,
			SubgroupSizeCount = 7,
			ConfidenceLimit = 9,
			UnitOfMeasurementCode = "QH",
			SampleFrequencyValuePerUnitOfMeasurementCode = 2,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
