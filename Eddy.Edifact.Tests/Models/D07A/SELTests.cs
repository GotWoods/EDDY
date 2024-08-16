using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D07A;
using Eddy.Edifact.Models.D07A.Composites;

namespace Eddy.Edifact.Tests.Models.D07A;

public class SELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEL+m++X++D";

		var expected = new SEL_SealNumber()
		{
			TransportUnitSealIdentifier = "m",
			SealIssuer = null,
			SealConditionCode = "X",
			IdentityNumberRange = null,
			SealTypeCode = "D",
		};

		var actual = Map.MapObject<SEL_SealNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
