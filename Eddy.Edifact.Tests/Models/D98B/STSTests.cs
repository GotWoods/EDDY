using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class STSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STS+++++++";

		var expected = new STS_Status()
		{
			StatusCategory = null,
			Status = null,
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
