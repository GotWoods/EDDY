using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STS+++++++";

		var expected = new STS_Status()
		{
			StatusType = null,
			StatusEvent = null,
			StatusReason = null,
			StatusReason2 = null,
			StatusReason3 = null,
			StatusReason4 = null,
			StatusReason5 = null,
		};

		var actual = Map.MapObject<STS_Status>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
