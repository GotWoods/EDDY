using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEL+h++y+";

		var expected = new SEL_SealNumber()
		{
			SealIdentifier = "h",
			SealIssuer = null,
			SealConditionCode = "y",
			IdentityNumberRange = null,
		};

		var actual = Map.MapObject<SEL_SealNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
