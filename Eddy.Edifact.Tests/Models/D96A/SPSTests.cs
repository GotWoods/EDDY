using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SPS++G+++++";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			FrequencyDetails = null,
			ConfidenceLimit = "G",
			SizeDetails = null,
			SizeDetails2 = null,
			SizeDetails3 = null,
			SizeDetails4 = null,
			SizeDetails5 = null,
		};

		var actual = Map.MapObject<SPS_SamplingParametersForSummaryStatistics>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
