using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SPS*4*9*2*5**4";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			Count = 4,
			Count2 = 9,
			Count3 = 2,
			ConfidenceLimit = 5,
			CompositeUnitOfMeasure = null,
			SampleFrequencyValuePerUnitOfMeasurementCode = 4,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
