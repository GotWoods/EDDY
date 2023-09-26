using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*Z*e*c*I*H*j*MWY39FOc";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "Z",
			YesNoConditionOrResponseCode2 = "e",
			YesNoConditionOrResponseCode3 = "c",
			YesNoConditionOrResponseCode4 = "I",
			ActionCode = "H",
			ReferenceIdentification = "j",
			Date = "MWY39FOc",
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
