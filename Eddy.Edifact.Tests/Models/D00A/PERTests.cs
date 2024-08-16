using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PER+C+";

		var expected = new PER_PeriodRelatedDetails()
		{
			PeriodTypeCodeQualifier = "C",
			PeriodDetail = null,
		};

		var actual = Map.MapObject<PER_PeriodRelatedDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
