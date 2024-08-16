using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class RODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ROD++";

		var expected = new ROD_RiskObjectType()
		{
			RiskObjectType = null,
			RiskObjectSubType = null,
		};

		var actual = Map.MapObject<ROD_RiskObjectType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
