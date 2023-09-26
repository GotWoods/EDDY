using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BCUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCU*K*f*0*k*W*o*SE6oULD1";

		var expected = new BCU_LegalClaimUpdates()
		{
			YesNoConditionOrResponseCode = "K",
			YesNoConditionOrResponseCode2 = "f",
			YesNoConditionOrResponseCode3 = "0",
			YesNoConditionOrResponseCode4 = "k",
			ActionCode = "W",
			ReferenceIdentification = "o",
			Date = "SE6oULD1",
		};

		var actual = Map.MapObject<BCU_LegalClaimUpdates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
