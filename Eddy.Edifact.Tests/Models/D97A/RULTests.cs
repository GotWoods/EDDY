using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class RULTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RUL+++";

		var expected = new RUL_RuleInformation()
		{
			RuleDetails = null,
			RuleText = null,
			RuleStatus = null,
		};

		var actual = Map.MapObject<RUL_RuleInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
