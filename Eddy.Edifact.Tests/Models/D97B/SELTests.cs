using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class SELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEL+M++f+";

		var expected = new SEL_SealNumber()
		{
			SealNumber = "M",
			SealIssuer = null,
			SealConditionCoded = "f",
			IdentityNumberRange = null,
		};

		var actual = Map.MapObject<SEL_SealNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
