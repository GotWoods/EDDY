using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*6*5*9*2**2";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			Count = 6,
			Count2 = 5,
			Count3 = 9,
			ConfidenceLimit = 2,
			CompositeUnitOfMeasure = "",
			SampleFrequencyValuePerUnitOfMeasurementCode = 2,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
