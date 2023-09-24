using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FTHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FTH*b*u*s*fY";

		var expected = new FTH_FirstTimeHomeBuyer()
		{
			YesNoConditionOrResponseCode = "b",
			YesNoConditionOrResponseCode2 = "u",
			TypeOfResidenceCode = "s",
			TypeOfAccountCode = "fY",
		};

		var actual = Map.MapObject<FTH_FirstTimeHomeBuyer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FTH_FirstTimeHomeBuyer();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
