using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*v*i*S*P*p*I*r9PUZj3w";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "v",
			YesNoConditionOrResponseCode2 = "i",
			YesNoConditionOrResponseCode3 = "S",
			YesNoConditionOrResponseCode4 = "P",
			ActionCode = "p",
			ReferenceIdentification = "I",
			Date = "r9PUZj3w",
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
