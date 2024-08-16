using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D03A;
using Eddy.Edifact.Models.D03A.Composites;

namespace Eddy.Edifact.Tests.Models.D03A;

public class SELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEL+4++a+";

		var expected = new SEL_SealNumber()
		{
			TransportUnitSealIdentifier = "4",
			SealIssuer = null,
			SealConditionCode = "a",
			IdentityNumberRange = null,
		};

		var actual = Map.MapObject<SEL_SealNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
