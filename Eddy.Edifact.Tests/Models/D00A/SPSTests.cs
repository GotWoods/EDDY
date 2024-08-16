using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SPS++x+++++";

		var expected = new SPS_SamplingParametersForSummaryStatistics()
		{
			FrequencyDetails = null,
			ConfidencePercent = "x",
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
